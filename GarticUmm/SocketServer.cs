using System;
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
    internal class SocketServer
    {
        private Thread serverThread;
        private bool isRunning = false;
        private TcpListener server;
        private int connectionCount = 0;

        private HandleClient serverOwner;

        private static PersonQueue<HandleClient> readyQueue;
        private static PersonQueue<HandleClient> playQueue;
        private int readyPlayers;
        private bool isOnGame;


        public SocketServer()
        {
            readyQueue = new PersonQueue<HandleClient>();
            playQueue = new PersonQueue<HandleClient>();
            readyPlayers = 0;
            isOnGame = false;

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
                    /**
                     * TODO: 그림 받기
                     * 그림은 HashMap을 이용해서 구현.
                     * key는 제시어가 될 것.
                     * value는 그림이 직렬화된 문자열의 배열 형태가 될 것.
                     * 
                     * imageList = {
                     *   "제시어 1": [그림1_1, 그림1_2]
                     *   "제시어 2": [그림2_1, 그림2_2]
                     *   "제시어 3": [그림3_1, 그림3_2]
                     * }
                     * 
                     * 그림을 받을 때 마다 readyPlayers의 값이 증가,
                     * readyPlayers == playQueue.Size와 같아지면 모든 플레이어의 그림이 수집되었다는 뜻.
                     * 
                     * turn = 1 에 제시어를 정하고 그림을 그림 -> 제출
                     * 모든 플레이어의 그림 수집이 완료된 후
                     * imageList["제시어 1"][turn - 1] 그림을 다음 사람에게 전달
                     * turn++
                     */
                }
                catch
                {
                    Console.WriteLine("-- onReceive Handler Exception --");
                }

                return;
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
                    Console.WriteLine("[IN] {0}: {1}", clientID, str);
                    // 연결이 끊긴 경우에만 null값이 들어옴
                    if (str == null) break;

                    ResClass res = ResClass.Parse(str);

                    if (OnReceived == null) continue;

                    if (res.Code == 4000)
                    {
                        OnReceived(new ResClass(res.Code, clientID + " > " + res.Message), this);
                        Console.WriteLine("[OUT] {0}: {1}", clientID, res.Message);
                    }

                    if (res.Code == 2004)
                    {
                        OnReceived(ResClass.Parse(str), this);
                        Console.WriteLine("Game start event");
                    }
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
