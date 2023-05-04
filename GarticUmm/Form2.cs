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
        Color color = Color.Black;// 펜 색 저장하는 변수 색깔 바꿀 때 이거 써주세요@@@@@
        int pen_thick = 5; // 펜굵기 저장하는 변수
        public GUGameForm()
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // 그림판 초기 상태: 펜굵기 제일 얇음, 펜 색상 검정, 얇은 펜, 검은색 버튼 눌린 상태
            pen = new Pen(color, pen_thick);
            this.thinbtn.Pushed = true;
            this.blackbtn.Pushed = true;
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
            if (e.Button == thinbtn)
            {
                this.thinbtn.Pushed = true;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = false;
                pen_thick = 5;
                pen = new Pen(color, pen_thick);
            }
            if (e.Button == middlebtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = true;
                this.thickbtn.Pushed = false;
                pen_thick = 10;
                pen = new Pen(color, pen_thick);
            }
            if (e.Button == thickbtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = true;
                pen_thick = 30;
                pen = new Pen(color, pen_thick);
            }
            if(e.Button == eraserbtn)
            {
                Set_initial();
                panel.Refresh();
            }

        }
        private void Set_initial()
        {
            this.thinbtn.Pushed = true;
            this.middlebtn.Pushed = false;
            this.thickbtn.Pushed = false;
            this.redbtn.Pushed = false;
            this.yellowbtn.Pushed = false;
            this.greenbtn.Pushed = false;
            this.bluebtn.Pushed = false;
            this.purplebtn.Pushed = false;
            this.blackbtn.Pushed = true;
            pen_thick = 5;
            color = Color.Black;
            pen = new Pen(color, pen_thick);
        }
    }
}
