using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using MetroFramework.Forms;
using SharedObject;
using UmmTimerNS;
using static GarticUmm.GUFinishForm;

namespace GarticUmm
{
    public partial class GUGameForm : MetroForm
    {
        // Panel 관련 변수
        private Graphics g; // 이 변수를 이용해서 panel에 그림을 그림
        private int x = -1; // 직선 시작점의 x좌표 저장
        private int y = -1; // 직선 시작점의 y좌표 저장
        private bool isMouseDown = false; // 마우스가 내려가 있는지 파악
        private Pen pen; // 직선 그릴 때 필요한 객체
        private SolidBrush brush; // 점 찍을 때 필요한 객체
        private DrawLineHistroy history = new DrawLineHistroy(); // 선 정보를 보관할 객체
        private bool refreshflag = true; // panel 새로고침 방지할 플래그

        // Timer 객체
        private UmmTimer timer;

        // TCP 소켓통신 관련 객체
        private string ipAddress;
        private bool isServer; // 이 클라이언트가 서버의 역할도 하는지 파악
        private SocketServer socketServer; // 서버 소켓 객체
        private SocketClient socketClient; // 클라이언트 소켓 객체

        // 결과 컨트롤러 창 객체
        private GUFinishForm resultControllerForm;

        // Initializer
        public GUGameForm(bool isServer, string ipAddress = "127.0.0.1")
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 그림판 초기 상태: 펜굵기 제일 얇음, 펜 색상 검정, 얇은 펜, 검은색 버튼 눌린 상태
            pen = new Pen(Color.Black, 5);
            brush = new SolidBrush(Color.Black);
            this.thinbtn.Pushed = true;
            this.blackbtn.Pushed = true;

            this.ipAddress = ipAddress;
            this.isServer = isServer;
        }
        
        // Form2가 로드 완료되었을 때
        private void GUGameForm_Load(object sender, EventArgs e)
        {
            panel.Enabled = false; //그림 그릴 때가 아니면 panel을 잠금

            // Timer 초기화
            timer = new UmmTimer();
            timer.EventHandler += TimerHandler;

            // Create Server로 접속한 클라이언트의 경우
            // 서버 소켓도 활성화함
            if (isServer)
            {
                // 서버 주소를 표시합니다.
                MessageLog.AppendText("Game room has been created at the address below!" + Environment.NewLine);
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipAddress = ip.ToString();
                        MessageLog.AppendText(ipAddress + Environment.NewLine);
                        MessageLog.ScrollToCaret();

                        break;
                    }
                }

                socketServer = new SocketServer(ipAddress);
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

            // 클라이언트 소켓 활성화
            socketClient = new SocketClient(isServer, ipAddress);
            socketClient.OnRunFail += (string msg) =>
            {
                GUGameForm_FormClosed(null, null);
                MessageBox.Show(msg);
                return;
            };
            socketClient.OnReceived += GetResponseHandler;
            socketClient.Connect(); // 서버에 연결
        }

        // 게임 창을 닫을 때
        private void GUGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer?.TimerStop();
            socketClient?.Disconnect();
            if (isServer)
                socketServer?.ServerStop();
        }

        // panel을 업데이트 해야하는 상황에서 자동 호출
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (refreshflag == false)
            {
                refreshflag = true;
                return;
            }
            DrawFromHistory();
        }

        // 그리기 시작할 때
        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X;
            y = e.Y;
        }

        // 그릴 때
        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown && x != -1 && y != -1)
            {
                AddDrawingHistory(pen, new Point(x, y), e.Location); // 각 포인트를 저장함
                g.DrawLine(pen, new Point(x, y), e.Location); // 각 포인트를 화면에 그림 - 선분
                g.FillEllipse(brush, x - (float)pen.Width / 2f, y - (float)pen.Width / 2f, (float)pen.Width, (float)pen.Width); // 각 포인트를 화면에 그림 - 점
                // 시작 포인트 업데이트
                x = e.X;
                y = e.Y;
            }
        }

        // 그리기 끝났을 때
        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            x = -1;
            y = -1;
        }

        // history 객체에 포인트를 추가하는 메서드
        private void AddDrawingHistory(Pen pen, Point pointFrom, Point pointDest)
        {
            history.addHistory(pen, pointFrom, pointDest);
        }

        // history 객체에 들어있는 선분을 그리는 메서드
        private void DrawFromHistory()
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

        // 그리기 도구의 버튼들을 제어하는 메서드
        private void toolBar2_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            // 얇은 굵기
            if (e.Button == thinbtn)
            {
                this.thinbtn.Pushed = true;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = false;

                pen.Width = 5;
            }
            // 중간 굵기
            else if (e.Button == middlebtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = true;
                this.thickbtn.Pushed = false;

                pen.Width = 10;
            }
            // 두꺼운 굵기
            else if (e.Button == thickbtn)
            {
                this.thinbtn.Pushed = false;
                this.middlebtn.Pushed = false;
                this.thickbtn.Pushed = true;

                pen.Width = 30;
            }
            // 지우개 버튼
            else if(e.Button == eraserbtn)
            {
                ResetTools();
                history.clearHistory();
                panel.Refresh();  
            }
            // 빨강 색 버튼
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
            // 노랑 색 버튼
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
            // 초록 색 버튼
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
            // 파랑 색 버튼
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
            // 보라 색 버튼
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
            // 검정 색 버튼
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
            // 하양 색 버튼
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

        // 그리기 도구를 기본값으로 초기화하는 함수
        private void ResetTools()
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

        // Timer 객체의 이벤트 핸들러
        // 1초마다 호출되어 이벤트를 처리함
        private void TimerHandler(UmmTimer.TimerType type, int count) //타이머 호출
        {
            //각각 상태에서 Label 및 상태 변경
            switch (type)
            {
                // 이전 플레이어가 그린 이미지 확인 단계
                case UmmTimer.TimerType.Check:
                    LabelStatus.Text = "Check the picture...";
                    break;
                // 그림 그리기 전 준비 단계
                case UmmTimer.TimerType.Ready:
                    LabelStatus.Text = "Ready...";
                    // panel 지움
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        history.clearHistory();
                        panel.Refresh();
                    }));
                    break;
                // 그림 그리는 단계
                case UmmTimer.TimerType.Drawing:
                    LabelStatus.Text = "Drawing...";
                    panel.Enabled = true; //그림 그릴 때 만 panel을 열어둠
                    eraserbtn.Enabled = true;
                    break;
            }
            LabelTimer.Text = count.ToString(); // 화면에 보여주는 시간 업데이트

            // 턴이 끝났을 때 - 그림 그리는 단계가 종료되었을 때
            if (type == UmmTimer.TimerType.TurnEnd)
            {
                socketClient.SendPaint(history.toCSVString()); // 서버로 그린 그림을 보냄
                refreshflag = false;
                panel.Enabled = false;
                eraserbtn.Enabled = false;
            }

            // 게임이 도중에 중단되었을 때
            if (type == UmmTimer.TimerType.Terminate) 
            {
                panel.Enabled = false;
            }
        }

        // 채팅창에서 메세지를 보낼 때
        private void SendButton_Click(object sender, EventArgs e)
        {
            if (MessageSend.Text == "" || MessageSend.Text == null) return;

            socketClient.SendMessage(MessageSend.Text);
            MessageSend.Clear();
        }
        private void MessageSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (MessageSend.Text == "" || MessageSend.Text == null) return;

            if (e.KeyCode == Keys.Enter)
            {
                socketClient.SendMessage(MessageSend.Text);
                MessageSend.Clear();
            }
        }

        // 서버로부터 들어온 요청을 처리하는 핸들러
        private void GetResponseHandler(ResClass res)
        {
            // 치명적인 에러가 발생한 경우
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

            // 채팅, 클라이언트의 접속/접속해제 가 발생한 경우
            if (res.Code == 4000 || res.Code == 3000 || res.Code == 3001)
            {
                MessageLog.Invoke((MethodInvoker) delegate ()
                {
                    MessageLog.AppendText(res.Message + Environment.NewLine);
                    MessageLog.ScrollToCaret();
                });
            }

            // 게임진행 중 그림이 들어온 경우
            if (res.Code == 5000)
            {
                this.Invoke((MethodInvoker)(delegate ()
                {
                    history.loadHistory(DrawLineHistroy.toList(res.Message));
                    panel.Refresh();

                    // 그림이 들어왔으니, 타이머를 다시 실행
                    // isOwnImage = false
                    timer.TimerStart(false);
                }));
            }

            // 게임진행 단계가 변경되는 경우
            if(res.Code == 2004)
            {
                // 게임이 시작한 경우
                if(res.Message == Constant.GAME_START)
                {
                    resultControllerForm?.Close(); // 게임결과 컨트롤러 창이 열려있다면 닫음

                    // 제시어를 입력받는 창을 열음
                    GUWordForm wordForm = new GUWordForm();
                    wordForm.DataPass += (string data) =>
                    {
                        // For Develop
                        this.Invoke((MethodInvoker)(delegate ()
                        {
                            this.Testlabel.Text = data;
                        }));

                        socketClient.SendEvent(3004, data); // 제시어를 입력했다는 이벤트를 서버로 보냄

                        wordForm.Close();
                    };
                    wordForm.ShowDialog();
                    return;
                }

                // 본인이 설정한 제시어를 설명하는 단계인 경우
                if (res.Message == Constant.START_DRAW_OWN_IMAGE_STAGE)
                {
                    MessageBox.Show("Draw image in 30 second\nfor simply explain your present!");
                    // 제시어 그림 그릴 때 타이머 시작
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        timer.TimerStart(true);
                    }));
                    return;
                }

                // 그림을 맞추는 단계인 경우
                if (res.Message == Constant.ENTER_ANSWER)
                {
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        timer.TimerStop();
                    }));

                    // 정답을 입력받는 창을 열음 (제시어 입력과 동일한 Form3)
                    GUWordForm wordForm = new GUWordForm();
                    wordForm.label1.Text = "Look at the picture\nand enter your answer!";
                    wordForm.DataPass += (string data) =>
                    {
                        this.Invoke((MethodInvoker)(delegate ()
                        {
                            this.Testlabel.Text = data;
                        }));

                        socketClient.SendEvent(3005, data); // 제시어 답변을 입력했다는 이벤트를 서버로 보냄

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

            // 서버 동작에서 에러가 있는 경우
            if(res.Code == 2002)
            {
                // 플레이어 수가 3명 이하인 상태에서 게임을 시작하려 한 경우
                if (res.Message == Constant.ERROR_NOT_ENOUGH_PLAYER)
                {
                    MessageBox.Show("You can't start a game until\nyou have at least three players!");
                    return;
                }

                // 게임이 이미 진행 중인데 또 게임을 시작하려 한 경우
                if (res.Message == Constant.ERROR_ALREADY_GAME_IS_RUNNING)
                {
                    MessageBox.Show("Game is already running!");
                    return;
                }
                
                // 게임이 진행 중에 플레이어가 나간 경우
                if (res.Message == Constant.ERROR_PLAYER_LEFT_WHILE_GAME_IS_RUNNING)
                {
                    this.Invoke((MethodInvoker)(delegate ()
                    {
                        timer.TimerStop();
                        history.clearHistory();
                        panel.Refresh();
                    }));
                    MessageBox.Show("The game stopped because someone left.");
                    return;
                }
            }

            // 제시어 답변까지 종료된 후 Form4을 열어야 하는 경우
            if (res.Code == 2005)
            {
                string[] presents = res.Message.Split(',');

                resultControllerForm = new GUFinishForm(presents);
                resultControllerForm.Owner = this;
                resultControllerForm.OnChoosed += new WordEventHandler((string present, int imageIdx) => {
                    // Form4 가 자의든 타의든 닫힌 경우
                    if (imageIdx == -1)
                    {
                        this.Invoke((MethodInvoker)(delegate ()
                        {
                            history.clearHistory();
                            panel.Refresh();
                        }));

                        return;
                    }

                    socketClient.SendEvent(3006, present + "," + imageIdx.ToString()); // 서버에 선택한 이미지 요청
                });
                this.Invoke((MethodInvoker)(delegate ()
                {
                    resultControllerForm.Show();
                }));

                return;
            }

            // 게임종료 후 서버에서 요청한 이미지를 보낸 경우
            if (res.Code == 2006)
            {
                string[] resData = res.Message.Split('/');
                string answer = resData[0];
                string image = resData[1];

                this.Invoke((MethodInvoker)(delegate ()
                {
                    resultControllerForm?.SetAnswer(answer);
                    history.loadHistory(DrawLineHistroy.toList(image));
                    panel.Refresh();
                }));
            }
        }
    }
}