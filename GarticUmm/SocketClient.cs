using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedObject;

namespace GarticUmm
{
    internal class SocketClient
    {
        TcpClient clientSocket;
        Thread recieveThread;
        private bool isConnected = false;

        public SocketClient()
        {
            clientSocket = new TcpClient();
        }

        public delegate void ReceivedHandler(string res);
        public event ReceivedHandler OnReceived;

        public void Connect()
        {
            try
            {
                clientSocket.Connect(Constant.LOCALHOST, Constant.PORT);

                recieveThread = new Thread(RecieveMessage);
                recieveThread.IsBackground = true;
                recieveThread.Start();

                isConnected = true;
            }
            catch
            {
                // 서버가 개방되지 않았는데 접속할 경우
                Console.WriteLine("-- Connect Exception --");
            }
        }

        public void Disconnect()
        {
            isConnected = false;
            clientSocket.Close();
        }

        private void RecieveMessage()
        {
            NetworkStream stream = clientSocket.GetStream();
            StreamReader reader = new StreamReader(stream);

            while(isConnected)
            {
                try
                {
                    string res = reader.ReadLine();

                    if (!isConnected) break;

                    OnReceived(res);
                }
                catch
                {
                    Console.WriteLine("-- Recieve Message Exception --");
                }
            }

            Console.WriteLine("Client Receive Message thread is terminated");
        }

        public void SendMessage(string message)
        {
            if (!isConnected) return;

            NetworkStream stream = clientSocket.GetStream();
            StreamWriter writer = new StreamWriter(stream, Constant.UTF8);

            writer.WriteLine(message);
            writer.Flush();
        }
    }
}
