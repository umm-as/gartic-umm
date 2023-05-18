using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SharedObject;

namespace GarticUmm
{
    internal class SocketClient
    {
        TcpClient clientSocket;
        private bool isConnected = false;

        public SocketClient()
        {
            clientSocket = new TcpClient();
        }

        public void Connect()
        {
            try
            {
                Console.WriteLine("Connection requrest");
                clientSocket.Connect(Constant.LOCALHOST, Constant.PORT);
                isConnected = true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
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
