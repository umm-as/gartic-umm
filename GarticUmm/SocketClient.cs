using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool isServer;

        public SocketClient(bool isServer)
        {
            clientSocket = new TcpClient();
            this.isServer = isServer;
        }

        public delegate void RunFailHandler(string msg);
        public event RunFailHandler OnRunFail;
        public delegate void ReceivedHandler(ResClass res);
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
                OnRunFail("Server is not opened.");
                Disconnect();
            }
        }

        public void Disconnect()
        {
            isConnected = false;
            clientSocket?.Close();
        }

        private void RecieveMessage()
        {
            NetworkStream stream = clientSocket?.GetStream();
            if (stream == null) return;

            StreamReader reader = new StreamReader(stream);

            while(isConnected)
            {
                try
                {
                    string res = reader.ReadLine();

                    // 연결이 끊긴 경우에만 null값이 들어옴
                    if (res == null) {
                        OnReceived(new ResClass(1001, "Disconnected from Server."));
                        Disconnect();
                        break;
                    }

                    if (!isConnected) break;

                    ResClass resData = ResClass.Parse(res);

                    OnReceived(resData);
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
            // message를 ,를 기준으로 code와 msg로 나누어 msg를 보낼수 있게 함
            //string splitmsg = message.Substring(message.IndexOf(',') + 1).Trim();
            //string splitcode = message.Substring(0, message.IndexOf(','));

            NetworkStream stream = clientSocket.GetStream();
            StreamWriter writer = new StreamWriter(stream, Constant.UTF8) { AutoFlush = true };
            if (message.StartsWith("/"))
            {
                if (!isServer)
                {
                    OnReceived(new ResClass(4000, "[System]\nYou don't have permission to use '/' command."));
                    return;
                }

                if (message == "/start")
                {
                    writer.WriteLine("2004," + Constant.GAME_START);
                    return;
                }
                
                if (message == "/?")
                {
                    OnReceived(new ResClass(4000, "[System]\n- /start : Start game."));
                    return;
                }

                // 해당하는 명령어가 존재하지 않을 때
                OnReceived(new ResClass(4000, "[System]\nType '/?' to learn the command."));
                return;
            }

            writer.WriteLine("4000," + message);
        }
    }
}
