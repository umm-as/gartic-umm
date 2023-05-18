using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedObject;

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
                Console.WriteLine("-- Server Start Exception --");
            }

            Console.WriteLine("Server thread is terminated");
        }

        public void ServerStop()
        {
            foreach(var client in clients)
            {
                client.StopClient();
            }

            isRunning = false;
            server.Stop();
        }

        private void onReceiveHandler(ResClass res)
        {
            foreach (var client in clients)
            {
                try
                {
                    client.StreamWriter.WriteLine(res.Message);
                    client.StreamWriter.Flush();
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

        public delegate void ReceivedHandler(ResClass res);
        public event ReceivedHandler OnReceived;

        public delegate void DisconnectHandler(HandleClient target);
        public event DisconnectHandler OnDisconnect;

        private void ClientThreadHandler()
        {
            try
            {
                stream = clientSocket.GetStream();

                reader = new StreamReader(stream, Constant.UTF8);
                writer = new StreamWriter(stream, Constant.UTF8);

                while (true)
                {
                    string str = reader.ReadLine();

                    if (!isConnected) break;

                    Console.WriteLine("[IN] {0}: {1}", clientID, str);

                    if (OnReceived != null)
                    {
                        OnReceived(new ResClass(1000, str));
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
