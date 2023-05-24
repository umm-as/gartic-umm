using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.IO;
using SharedObject;
using System.Threading;
using System.Collections.Generic;

namespace GarticUmm
{
    public partial class GUGameForm : MetroForm
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        SolidBrush brush;
        private DrawLineHistroy history = new DrawLineHistroy();

        bool isServer;
        SocketServer socketServer;
        SocketClient socketClient;

        public GUGameForm(bool isServer)
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 그림판 초기 상태: 펜굵기 제일 얇음, 펜 색상 검정, 얇은 펜, 검은색 버튼 눌린 상태
            pen = new Pen(Color.Black, 5);
            brush = new SolidBrush(Color.Black);
            this.thinbtn.Pushed = true;
            this.blackbtn.Pushed = true;

            // For develop - Woong
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "Text (*.txt)|*.txt";
            saveFileDialog1.Filter = "Text (*.txt)|*.txt";
            saveFileDialog1.FileName = "*.txt";

            // For develop TCP - Woong
            this.isServer = isServer;

            if (isServer)
            {
                socketServer = new SocketServer();
                socketServer.OnRunFail += (string msg) =>
                {
                    GUGameForm_FormClosed(null, null);
                    MessageBox.Show(msg);
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        this.Close();
                    }));
                };
            }

            socketClient = new SocketClient();
            socketClient.OnRunFail += (string msg) =>
            {
                GUGameForm_FormClosed(null, null);
                MessageBox.Show(msg);
                return;
            };
            socketClient.OnReceived += GetResponseHandler;
            socketClient.Connect();
        }
        

        private void GUGameForm_Load(object sender, EventArgs e)
        {
            UpdateCountdown(); // 타이머설정 및 타이머 따라 상태 변화
        }

        private void GUGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            socketClient?.Disconnect();
            if (isServer)
                socketServer?.ServerStop();
        }

        private void UpdateCountdown()
        {
            int count = 10; // 최초 실행시 그림 확인 시간 10초로 초기화
            int[] times = { 10, 3, 30 }; // 한 천에 사용되는 시간들, 최초 확인시간 10초, 그릴 준비 3초, 그리는 시간 30초
            int index = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1초마다 실행
            timer.Tick += (s, e) =>
            {
                count--; // 카운트 다운 시작
                if (count < 0)
                {
                    index++; // 최초 10초가 다 지나면 배열 인덱스 증가
                    if (index >= times.Length) // 턴이 모두 실행 됐을 때
                    {
                        timer.Stop(); // 타이머 동작 중지 후 턴 종료 메세지 박스
                        MessageBox.Show("Turn End");
                        return;
                    }

                    switch(index)
                    {
                        case 0: // 최초 상태
                            LabelStatus.Text = " ";
                            break;
                        case 1: // 준비 단계
                            LabelStatus.Text = "Ready...";
                            break;
                        case 2: // 그리는 단계
                            LabelStatus.Text = "Drawing...";
                            break;
                    }

                    count = times[index]; // 다음 시간 대입
                }

                LabelTimer.Text = count.ToString();
            };
            timer.Start();
        }

        private void AddDrawingHistory(Pen pen, Point pointFrom, Point pointDest)
        {
            history.addHistory(pen, pointFrom, pointDest);
        }

        private void ClearDrawingHistory()
        {
            history.clearHistory();
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
                g.FillEllipse(brush, x - (float)pen.Width / 2f, y - (float)pen.Width / 2f, (float)pen.Width, (float)pen.Width);
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
                drawFromHistory();
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

        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == thinbtn)
            {
                this.thinbtn.Pushed = true;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = false;

                pen.Width = 5;
            }
            else if (e.Button == middlebtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = true;
                this.thickbtn.Pushed = false;

                pen.Width = 10;
            }
            else if (e.Button == thickbtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = true;

                pen.Width = 30;
            }

            else if(e.Button == eraserbtn)
            {
                Set_initial();
                ClearDrawingHistory();
                panel.Refresh();  
            }
            
            else if (e.Button == redbtn)
            {
                this.redbtn.Pushed = true;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;
                this.whitebtn.Pushed = false;

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
                this.whitebtn.Pushed = false;

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
                this.whitebtn.Pushed = false;

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
                this.whitebtn.Pushed = false;

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
                this.whitebtn.Pushed = false;

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
                this.whitebtn.Pushed = false;

                pen.Color = Color.Black;
            }
            else if (e.Button == whitebtn)
            {
                this.redbtn.Pushed = false;
                this.greenbtn.Pushed = false;
                this.bluebtn.Pushed = false;
                this.yellowbtn.Pushed = false;
                this.purplebtn.Pushed = false;
                this.blackbtn.Pushed = false;
                this.whitebtn.Pushed = true;

                pen.Color = Color.White;
            }
            
            brush.Color = pen.Color;
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
            this.whitebtn.Pushed = false;

            pen.Width = 5;
            pen.Color = Color.Black;
            brush.Color = Color.Black;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            drawFromHistory();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            socketClient.SendMessage("4000," + MessageSend.Text);
            MessageSend.Clear();
        }
        private void MessageSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                socketClient.SendMessage("4000," + MessageSend.Text);
                MessageSend.Clear();
            }
        }

        private void GetResponseHandler(ResClass res)
        {
            if (res.Code == 1001)
            {
                GUGameForm_FormClosed(null, null);
                MessageBox.Show(res.Message);
                this?.Invoke((MethodInvoker)(delegate ()
                {
                    this?.Close();
                }));
                return;
            }

            if (MessageLog.InvokeRequired)
            {
                MessageLog.BeginInvoke(new MethodInvoker(delegate
                {
                    MessageLog.AppendText(Environment.NewLine + res.Message);
                    MessageLog.ScrollToCaret();
                }));
            }
            else
            {
                MessageLog.AppendText(Environment.NewLine  + res.Message);
                MessageLog.ScrollToCaret();
            }
        }
        
        //제시어 입력창 생성 및 저장(임시)
        private List<string> words;//WordForm에서 입력받은 제시어 저장할 리스트
        private void btnWord_Click(object sender, EventArgs e)
        {
            GUWordForm wordForm = new GUWordForm();
            wordForm.DataPass += new GUWordForm.DataPassEventHandler(ReciveWord);
            wordForm.ShowDialog();
        }
        public void ReciveWord(string data)//WordForm에서 받아온 제시어 저장 및 출력
        {
            words = new List<string>();
            words.Add(data);
            Testlabel.Text = data;
        }

        private void sendPaint(DrawLineHistroy histroy)
        {
            socketClient.SendMessage("5000," + histroy.toCSVString());
        }
    }
}