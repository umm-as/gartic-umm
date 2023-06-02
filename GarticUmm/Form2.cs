using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using SharedObject;
using UmmTimerNS;

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

        UmmTimer timer;

        bool isServer;
        SocketServer socketServer;
        SocketClient socketClient;

        bool refreshflag = true;

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

            this.isServer = isServer;
        }
        

        private void GUGameForm_Load(object sender, EventArgs e)
        {
            panel.Enabled = false; //그림 그릴 때가 아니면 panel을 잠금
            timer = new UmmTimer();
            timer.EventHandler += TimerHandler;

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

            socketClient = new SocketClient(isServer);
            socketClient.OnRunFail += (string msg) =>
            {
                GUGameForm_FormClosed(null, null);
                MessageBox.Show(msg);
                return;
            };
            socketClient.OnReceived += GetResponseHandler;
            socketClient.Connect();
        }

        private void GUGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer?.TimerStop();
            socketClient?.Disconnect();
            if (isServer)
                socketServer?.ServerStop();
        }

        private void AddDrawingHistory(Pen pen, Point pointFrom, Point pointDest)
        {
            history.addHistory(pen, pointFrom, pointDest);
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
                history.clearHistory();
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

        private void TimerHandler(UmmTimer.TimerType type, int count) //타이머 호출
        {
            switch (type) //각각 상태에서 Label 및 상태 변경
            {
                case UmmTimer.TimerType.Check:
                    LabelStatus.Text = "Check the picture...";
                    break;
                case UmmTimer.TimerType.Ready:
                    LabelStatus.Text = "Ready...";
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        history.clearHistory();
                        panel.Refresh();
                    }));
                    break;
                case UmmTimer.TimerType.Drawing:
                    LabelStatus.Text = "Drawing...";
                    panel.Enabled = true; //그림 그릴 때 만 panel을 열어둠
                    eraserbtn.Enabled = true;
                    break;
            }
            LabelTimer.Text = count.ToString();

            if(type == UmmTimer.TimerType.TurnEnd) //턴이 끝났을 때
            {
                socketClient.SendPaint(history.toCSVString());
                refreshflag = false;
                panel.Enabled = false;
                eraserbtn.Enabled = false;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            socketClient.SendMessage(MessageSend.Text);
            MessageSend.Clear();
        }
        private void MessageSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                socketClient.SendMessage(MessageSend.Text);
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

            if (res.Code == 4000 || res.Code == 3000 || res.Code == 3001)
            {
                MessageLog.Invoke((MethodInvoker) delegate
                    {
                        MessageLog.AppendText(res.Message + Environment.NewLine);
                        MessageLog.ScrollToCaret();
                    });
            }

            if (res.Code == 5000)
            {
                this.Invoke((MethodInvoker)(delegate ()
                {
                    history.loadHistory(DrawLineHistroy.toList(res.Message));
                    panel.Refresh();

                    timer.TimerStart(false);
                }));
            }

            if(res.Code == 2004)
            {
                if(res.Message == Constant.GAME_START)
                {
                    GUWordForm wordForm = new GUWordForm();
                    wordForm.DataPass += (string data) =>
                    {
                        this.Invoke((MethodInvoker)(delegate ()
                        {
                            this.Testlabel.Text = data;
                        }));

                        socketClient.SendEvent(3004, data);

                        wordForm.Close();
                    };;
                    wordForm.ShowDialog();
                    return;
                }

                if (res.Message == Constant.START_DRAW_OWN_IMAGE_STAGE)
                {
                    MessageBox.Show("Draw image in 30 second\nfor simply explane your present!");
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        timer.TimerStart(true);
                    })); // 제시어 그림 그릴 때 타이머 시작
                    return;
                }

                if (res.Message == Constant.GAME_END)
                {
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        timer.TimerStop();
                    }));
                    GUWordForm wordForm = new GUWordForm();
                    wordForm.label1.Text = "Look at the picture and enter the correct answer!";
                    wordForm.DataPass += (string data) =>
                    {
                        this.Invoke((MethodInvoker)(delegate ()
                        {
                            this.Testlabel.Text = data;
                        }));
                        wordForm.Close();
                    };;
                    wordForm.ShowDialog();
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        history.clearHistory();
                        panel.Refresh();
                    }));
                    return;
                }
            }

            if(res.Code == 2002)
            {
                if (res.Message == Constant.ERROR_NOT_ENOUGH_PLAYER)
                {
                    MessageBox.Show("You can't start a game until\nyou have at least three players!");
                    return;
                }

                if (res.Message == Constant.ERROR_ALREADY_GAME_IS_RUNNING)
                {
                    MessageBox.Show("Game is already running!");
                    return;
                }
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (refreshflag == false)
            {
                refreshflag = true;
                return;
            }
            drawFromHistory();

        }
    }
}