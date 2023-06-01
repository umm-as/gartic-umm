using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SharedObject;
using UmmQueue;

namespace GarticUmm
{
    enum Stage
    {
        Pending,
        SetPresent,
        DrawOwnImage,
        DrawImage,
        CheckImage,
    }

    internal class SocketServer
    {
        private Thread serverThread;
        private bool isRunning = false;
        private TcpListener server;
        private int connectionCount = 0;

        private HandleClient serverOwner;

        private static PersonQueue<HandleClient> readyQueue;
        private static PersonQueue<HandleClient> playQueue;
        private Stage stage;
        private int readyPlayers;
        private bool isOnGame;

        private Dictionary<string, List<string>> imageMap;


        public SocketServer()
        {
            readyQueue = new PersonQueue<HandleClient>();
            playQueue = new PersonQueue<HandleClient>();
            stage = Stage.Pending;
            readyPlayers = 0;
            isOnGame = false;

            imageMap = new Dictionary<string, List<string>>();

            serverThread = new Thread(ServerStart);
            serverThread.IsBackground = true;
            serverThread.Start();

            Console.WriteLine("Server is running");
        }

        public delegate void RunFailHandler(string msg);
        public event RunFailHandler OnRunFail;

        // Run on thread
        private void ServerStart()
        {
            try
            {
                server = new TcpListener(Constant.LOCALHOST, Constant.PORT);
                server.Start();

                isRunning = true;

                while (isRunning)
                {
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        connectionCount++;

                        HandleClient h_client = new HandleClient();
                        h_client.OnReceived += onReceiveHandler;
                        h_client.OnDisconnect += onDisconnectHandler;
                        h_client.StartClient(client, connectionCount);
                        readyQueue.Enqueue(h_client);

                        if (serverOwner == null)
                        {
                            serverOwner = h_client;
                        }

                        // Send message at HandleClient.ClientThreadHandler
                        Console.WriteLine(h_client.ID + " Player had been joined.");
                    }
                    catch 
                    {
                        Console.WriteLine("-- TCP Accept Exception --");
                    }
                }
            }
            catch (Exception ex)
            {
                // 이미 서버가 실행중일 경우
                Console.WriteLine("-- Server Start Exception --");
                Console.WriteLine(ex.StackTrace);
                OnRunFail("Server already running.");
            }

            Console.WriteLine("Server thread is terminated");
        }

        public void ServerStop()
        {
            while (playQueue.Size > 0)
            {
                playQueue.Dequeue().StopClient();
            }

            while (readyQueue.Size > 0)
            {
                readyQueue.Dequeue().StopClient();
            }

            serverOwner = null;
            isRunning = false;
            server.Stop();
        }

        private void onReceiveHandler(ResClass res, HandleClient target)
        {
            if(res.Code == 1000 || res.Code == 4000 || res.Code == 3000 || res.Code == 3001)
            {
                foreach (var client in readyQueue)
                {
                    try
                    {
                        client.StreamWriter.WriteLine(res.Code.ToString() + "," + res.Message);
                    }
                    catch
                    {
                        Console.WriteLine("-- onReceive Handler Exception --");
                    }
                }
                foreach (var client in playQueue)
                {
                    try
                    {
                        client.StreamWriter.WriteLine(res.Code.ToString() + "," + res.Message);
                    }
                    catch
                    {
                        Console.WriteLine("-- onReceive Handler Exception --");
                    }
                }

                return;
            }
            
            if(res.Code == 5000)
            {
                try
                {

                }
                catch
                {
                    Console.WriteLine("-- onReceive Handler Exception --");
                }

                return;
            }

            if (res.Code == 3003)
            {
                if (res.Message == Constant.END_DRAW_IMAGE_STAGE)
                {
                    return;
                }

                if (res.Message == Constant.END_CHECK_IMAGE_STAGE)
                {
                    return;
                }
            }

            // 제시어 입력이 들어왔을 때
            if (res.Code == 3004)
            {
                playQueue.SetPresent(target, res.Message);
                imageMap.Add(res.Message, new List<string>());
                readyPlayers++;

                // 전부 제시어 입력을 완료했을 때
                if (readyPlayers == playQueue.Size)
                {
                    // 다음 스테이지로 전환
                    stage = Stage.DrawOwnImage;
                    readyPlayers = 0;

                    foreach (var client in playQueue)
                    {
                        client.StreamWriter.WriteLine("2004," + Constant.START_DRAW_OWN_IMAGE_STAGE);
                    }

                    foreach (var present in imageMap.Keys)
                    {
                        Console.WriteLine(present);
                    }
                }
            }

            if (res.Code == 2004)
            {
                if (res.Message == Constant.GAME_START)
                {
                    if (isOnGame)
                    {
                        serverOwner.StreamWriter.WriteLine("2002," + Constant.ERROR_ALREADY_GAME_IS_RUNNING);

                        return;
                    }

                    if(readyQueue.Size < 3)
                    {
                        serverOwner.StreamWriter.WriteLine("2002," + Constant.ERROR_NOT_ENOUGH_PLAYER);

                        return;
                    }

                    isOnGame = true;
                    while(readyQueue.Size > 0)
                    {
                        playQueue.Enqueue(readyQueue.Dequeue());
                    }
                    foreach(HandleClient client in playQueue)
                    {
                        client.StreamWriter.WriteLine("2004," + Constant.GAME_START);
                    }
                }
            }
        }

        private void onDisconnectHandler(HandleClient target)
        {
            readyQueue.Pop(target);
            playQueue.Pop(target);
            target.StopClient();

            Console.WriteLine(target.ID + " Player had been left.");
            onReceiveHandler(new ResClass(3001, target.ID+ " Player had been left."), target);
            target = null;
        }
    }

    class HandleClient
    {
        private Thread clientThread;
        private TcpClient clientSocket;
        private int clientID;
        private bool isConnected;

        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public void StartClient(TcpClient clientSocket, int clientID) { 
            this.clientSocket = clientSocket;
            this.clientID = clientID;

            isConnected = true;
            clientThread = new Thread(ClientThreadHandler);
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        public void StopClient()
        {
            isConnected = false;
            clientSocket?.Close();
        }

        public delegate void ReceivedHandler(ResClass res, HandleClient target);
        public event ReceivedHandler OnReceived;

        public delegate void DisconnectHandler(HandleClient target);
        public event DisconnectHandler OnDisconnect;

        private void ClientThreadHandler()
        {
            try
            {
                stream = clientSocket.GetStream();

                reader = new StreamReader(stream, Constant.UTF8);
                writer = new StreamWriter(stream, Constant.UTF8) { AutoFlush = true };

                OnReceived(new ResClass(3000, clientID + " Player had been joined."), this);

                while (isConnected)
                {
                    string str = reader.ReadLine();

                    // 연결이 끊긴 경우에만 null값이 들어옴
                    if (str == null) break;

                    ResClass res = ResClass.Parse(str);

                    if (OnReceived == null) continue;

                    // 채팅은 문자열을 가공을 해주고 넘김
                    if (res.Code == 4000)
                    {
                        OnReceived(new ResClass(res.Code, clientID + " > " + res.Message), this);
                        continue;
                    }

                    OnReceived(res, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- Client Thread Handler Exception --");
                Console.WriteLine(ex.StackTrace);
            }

            OnDisconnect(this);
            Console.WriteLine("Client handler thread is terminated");
        }

        public StreamWriter StreamWriter
        {
            get { return this.writer; }
        }

        public int ID
        {
            get { return this.clientID; }
        }
    }
}
