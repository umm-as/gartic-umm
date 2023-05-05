using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;


namespace GarticUmm
{
    
    public partial class GUGameForm : MetroForm
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        Color color = Color.Black;// 펜 색 저장하는 변수 색깔 바꿀 때 이거 써주세요@@@@@
        int pen_thick = 5; // 펜굵기 저장하는 변수
        private DrawLineHistroy history = new DrawLineHistroy();

        private void AddDrawingHistory(Pen pen, Point pointFrom, Point pointDest)
        {
            history.addHistory(pen, pointFrom, pointDest);
        }

        private void ClearDrawingHistory()
        {
            history.clearHistory();
        }

        public GUGameForm()
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            // 그림판 초기 상태: 펜굵기 제일 얇음, 펜 색상 검정, 얇은 펜, 검은색 버튼 눌린 상태
            pen = new Pen(color, pen_thick);
            this.thinbtn.Pushed = true;
            this.blackbtn.Pushed = true;

            // For develop - Woong
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Text (*.txt)|*.txt";
            saveFileDialog1.Filter = "Text (*.txt)|*.txt";
            saveFileDialog1.FileName = "*.txt";
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving && x != -1 && y != -1)
            {
                AddDrawingHistory(pen, new Point(x, y), e.Location);
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

        // For develop - Woong
        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ClearDrawingHistory();

                // load
                Stream stream = openFileDialog1.OpenFile();
                StreamReader sr = new StreamReader(stream);
                string csv = sr.ReadToEnd();
                sr.Close();
                stream.Close();
                // deserialize drawing history
                history.loadHistory(DrawLineHistroy.toList(csv));
                // drawing
                foreach (var line in history.getHistory())
                {
                    Pen penHistory = new Pen(line.getColor(), line.getWidth());
                    g.DrawLine(penHistory, new Point(line.FromX, line.FromY), new Point(line.DestX, line.DestY));
                }
            }
        }
        // For develop - Woong
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // serialize drawing history
                string csv = history.toCSVString();
                // save
                Stream stream = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(stream);
                sw.Write(csv);
                sw.Close();
                stream.Close();
            }
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
