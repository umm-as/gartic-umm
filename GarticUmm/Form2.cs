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


namespace GarticUmm
{
    
    public partial class GUGameForm : MetroForm
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        const int PORT = 2002;
        private Thread m_ThReader;

        public bool m_bConnected = false;
        public GUGameForm()
        {
            InitializeComponent();
        }
    }
}
