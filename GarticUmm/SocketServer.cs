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

        public bool isRunning = false;
        private TcpListener server;

        private List<HandleClient> clients = new List<HandleClient>();
        public int connectionCount = 0;

        public SocketServer()
        {
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
                        clients.Add(h_client);

                        // Send message at HandleClient.ClientThreadHandler
                        Console.WriteLine(h_client.ID + " Player had been joined.");
                    }
                    catch 
                    {
                        Console.WriteLine("-- TCP Accept Exception --");
                    }
                }
            }
            catch
            {
                // 이미 서버가 실행중일 경우
                Console.WriteLine("-- Server Start Exception --");
                OnRunFail("Server already running.");
            }

            Console.WriteLine("Server thread is terminated");
        }

        public void ServerStop()
        {
            for (int i = 0; i < clients.Count; i++)
            {
                clients[i]?.StopClient();
            }

            isRunning = false;
            server.Stop();
        }

        private void onReceiveHandler(ResClass res, HandleClient target) // 다음 참가자에게 그림을 보내기 위해 현재 client 값을 받게함.
        {
            if (res.Code == 4000 || res.Code == 1000)
            {
                foreach (var client in clients)
                {
                    try
                    {
                        client.StreamWriter.WriteLine(res.Code.ToString() + "," + res.Message); // 메시지의 종류를 구분하기 위해 앞에 이벤트코드를 붙임
                    }
                    catch
                    {
                        Console.WriteLine("-- onReceive Handler Exception --");
                    }
                }
            }
            else if (res.Code == 5000)
            {
                try
                {
                    int index = clients.IndexOf(target);
                    
                    // 마지막 참가자면 첫번째 참가자에게 그림을 보냄
                    if (index == clients.Count - 1)
                        clients[0].StreamWriter.WriteLine(res.Code.ToString() + "," + res.Message);
                    else
                        clients[index + 1].StreamWriter.WriteLine(res.Code.ToString() + "," + res.Message);
                }
                catch
                {
                    Console.WriteLine("-- onReceive Handler Exception --");
                }
            }
        }

        private void onDisconnectHandler(HandleClient target)
        {
            clients.Remove(target);
            target.StopClient();

            onReceiveHandler(new ResClass(1000, target.ID+ " Player had been left."), target);
            Console.WriteLine(target.ID + " Player had been left.");
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

                OnReceived(new ResClass(1000, clientID + " Player had been joined."), this);

                while (isConnected)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine("[IN] {0}: {1}", clientID, str);
                    // 연결이 끊긴 경우에만 null값이 들어옴
                    if (str == null) break;

                    string pattern = "\\d+";
                    Regex reg = new Regex(pattern);

                    string temp = str.Substring(0, str.IndexOf(','));
                    string code = reg.Match(temp).Value;
                    string strData = str.Substring(str.IndexOf(',') + 1).Trim();
               
                    if (OnReceived != null)
                    {    
                        OnReceived(new ResClass(int.Parse(code), clientID + " > " + strData), this); 
                        Console.WriteLine("[OUT] {0}: {1}", clientID, strData);
                    }
                }
            }
            catch
            {
                Console.WriteLine("-- Client Thread Handler Exception --");
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
