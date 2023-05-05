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
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;

        public GUGameForm()
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving && x!= -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;

        }

        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == redbtn)
            {
                this.redbtn.Pushed = true;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;

                pen.Color = Color.Red;
            }
            else if (e.Button == yellowbtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = true;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;

                pen.Color = Color.Yellow;
            }
            else if (e.Button == greenbtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = true;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;

                pen.Color = Color.Green;
            }
            else if (e.Button == bluebtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = true;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;

                pen.Color = Color.Blue;
            }
            else if (e.Button == purplebtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = true;
                this.blackbtn.Pushed = false;

                pen.Color = Color.Purple;
            }
            else if (e.Button == blackbtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = true;

                pen.Color = Color.Black;
            }
        }
    }
}
