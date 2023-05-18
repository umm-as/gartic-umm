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
        private TcpClient client;

        private List<HandleClient> clients = new List<HandleClient>();
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
                        clients.Add(h_client);
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
            foreach (var client in clients)
            {
                try
                {
                    client.StreamWriter.WriteLine(res.Message);
                    client.StreamWriter.Flush();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex);
                }
            }
        }

        private void onDisconnectHandler(HandleClient target)
        {
            clients.Remove(target);
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
        private TcpClient clientSocket;
        private int clientID;

        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public void startClient(TcpClient clientSocket, int clientID) { 
            this.clientSocket = clientSocket;
            this.clientID = clientID;

            Thread t_handler = new Thread(clientThread);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        public delegate void ReceivedHandler(ResClass res);
        public event ReceivedHandler OnReceived;

        public delegate void DisconnectHandler(HandleClient target);
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
                    string str = reader.ReadLine();
                    Console.WriteLine("[IN] {0}: {1}", clientID, str);

                    //writer.WriteLine(str);
                    //writer.Flush();

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
                    OnDisconnect(this);
                }
            }
        }

        public StreamWriter StreamWriter
        {
            get { return this.writer; }
        }
    }
}
