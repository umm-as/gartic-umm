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
        public NetworkStream stream;
        public StreamReader reader;
        public StreamWriter writer;
        private Thread serverThread;

        public bool isRunning = false;
        private TcpListener server;
        private TcpClient client;

        public int connectionCount = 0;

        public SocketServer()
        {
            serverThread = new Thread(ServerStart);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        ~SocketServer()
        {
            serverThread.Abort();
            ServerStop();
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
                        client = server.AcceptTcpClient();
                        Console.WriteLine("Connection accepted");
                        connectionCount++;

                        HandleClient h_client = new HandleClient();
                        h_client.OnReceived += onReceiveHandler;
                        h_client.OnDisconnect += onDisconnectHandler;
                        h_client.startClient(client, connectionCount);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void onReceiveHandler(ResClass res)
        {
            Console.WriteLine(res.Message);
        }

        private void onDisconnectHandler()
        {
            connectionCount--;
        }

        private void ServerStop()
        {
            if (server != null)
            {
                server.Stop();
                server = null;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }
        }
    }

    class HandleClient
    {
        TcpClient clientSocket;
        int clientID;

        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        public void startClient(TcpClient clientSocket, int clientID) { 
            this.clientSocket = clientSocket;
            this.clientID = clientID;

            Thread t_handler = new Thread(clientThread);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        public delegate void ReceivedHandler(ResClass res);
        public event ReceivedHandler OnReceived;

        public delegate void DisconnectHandler();
        public event DisconnectHandler OnDisconnect;

        private void clientThread()
        {
            try
            {
                stream = clientSocket.GetStream();

                reader = new StreamReader(stream, Constant.UTF8);
                writer = new StreamWriter(stream, Constant.UTF8);

                while (true)
                {
                    Console.WriteLine("1");
                    string str = reader.ReadLine();
                    Console.WriteLine("[IN] {0}: {1}", clientID, str);

                    Console.WriteLine("2");

                    writer.WriteLine(str);
                    writer.Flush();

                    if (OnReceived != null)
                    {
                        OnReceived(new ResClass(1000, str));
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);

                if (clientSocket != null)
                {
                    clientSocket.Close();
                    reader.Close();
                    writer.Close();
                    stream.Close();
                }

                if (OnDisconnect != null)
                {
                    OnDisconnect();
                }
            }
        }
    }
}
