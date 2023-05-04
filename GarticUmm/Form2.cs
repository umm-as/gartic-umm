using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;


namespace GarticUmm
{
    
    public partial class GUGameForm : MetroForm
    {
        public NetworkStream m_Stream; //네트워크 스트림
        public StreamReader m_Read; //읽기
        public StreamWriter m_Write; //쓰기
        const int PORT = 2002; //포트번호
        private Thread m_ThReader; //읽기쓰레드
        private TcpClient client;
        private TcpListener m_TcpListener;//서버 작동 리스너
        private Thread m_thServer; //서버 플래그

        public bool m_bConnected = false; //서버 접속 플래그
        public GUGameForm()
        {
            InitializeComponent();
            IPAddress[] local_ip = Dns.GetHostAddresses(Dns.GetHostName());
        }
    }
}
