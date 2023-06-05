using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace GarticUmm
{
    
    public partial class GUFinishForm : MetroForm
    {
        SocketClient socketClient;

        Pen pen;
        SolidBrush brush;
        Graphics g;
        int x = -1;
        int y = -1;
        private DrawLineHistroy history = new DrawLineHistroy();
        
        private string[] presents; // 제시어
        private int currentPaintIndex = 0; // 현재 그림 인덱스 0이면 왼쪽으로 더이상 넘길 수 없고 present의 크기-1이면 오른쪽으로 넘기지 않음
        //

        public GUFinishForm(SocketClient socketClient)
        {
            InitializeComponent();
            this.socketClient = socketClient;
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void btnPicLeft_Click(object sender, EventArgs e)
        {
            if(currentPaintIndex == 0)
                btnPicLeft.Enabled = false;

            if(currentPaintIndex > 0)
            {
                currentPaintIndex--;
                this.Invoke((MethodInvoker)(delegate ()
                {
                    history.clearHistory();
                    panel.Refresh();
                    //history.loadHistory(DrawLineHistroy.toList());
                    drawFromHistory();

                }));
            }
        }

        private void btnPicRight_Click(object sender, EventArgs e)
        {
            if(currentPaintIndex > 0)
                btnPicRight.Enabled = false;

            if( currentPaintIndex <= 0)
            {
                currentPaintIndex++;
                this.Invoke((MethodInvoker)(delegate ()
                {
                    history.clearHistory();
                    panel.Refresh();
                    //history.loadHistory(DrawLineHistroy.toList();
                    drawFromHistory();

                }));
            }
        }

        private void GUFinishForm_Load(object sender, EventArgs e)
        {

            foreach (string present in presents)
            {
                Wordlist.Items.Add(present);
            }
        }

        private void drawFromHistory()
        {
            Pen penHistory = new Pen(Color.Black, 1);
            SolidBrush brushHistory = new SolidBrush(Color.Black);
            foreach (var line in history.getHistory())
            {
                penHistory.Color = line.getColor();
                penHistory.Width = line.getWidth();
                brushHistory.Color = line.getColor();
                g.DrawLine(penHistory, new Point(line.FromX, line.FromY), new Point(line.DestX, line.DestY));
                g.FillEllipse(brushHistory, line.FromX - (float)penHistory.Width / 2f, line.FromY - (float)penHistory.Width / 2f, (float)penHistory.Width, (float)penHistory.Width);
            }
        }

        private void Words_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
