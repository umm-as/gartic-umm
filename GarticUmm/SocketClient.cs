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

        ~SocketClient()
        {
            recieveThread.Abort();
        }

        public delegate void ReceivedHandler(string res);
        public event ReceivedHandler OnReceived;

        public void Connect()
        {
            try
            {
                Console.WriteLine("Connection requrest");
                clientSocket.Connect(Constant.LOCALHOST, Constant.PORT);

                recieveThread = new Thread(RecieveMessage);
                recieveThread.IsBackground = true;
                recieveThread.Start();

                isConnected = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void RecieveMessage()
        {
            NetworkStream stream = clientSocket.GetStream();
            StreamReader reader = new StreamReader(stream);

            while(isConnected)
            {
                string res = reader.ReadLine();
                OnReceived(res);
            }
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
