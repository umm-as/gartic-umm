using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;


namespace GarticUmm
{
    public partial class GUGameForm : MetroForm
    {
       
        public GUGameForm()
        {
            InitializeComponent();           
        }

        private void GUGameForm_Load(object sender, EventArgs e)
        {
            
            UpdateCountdown();//타이머설정 및 타이머 따라 상태 변화
        }
        private void UpdateCountdown()
        {
            int count = 10;//최초 실행시 그림 확인 시간 10초로 초기화
            int[] times = { 10, 3, 30 };//한 천에 사용되는 시간들, 최초 확인시간 10초, 그릴 준비 3초, 그리는 시간 30초
            int index = 0;
            Timer timer = new Timer();
            timer.Interval = 1000;//1초마다 실행
            timer.Tick += (s, e) =>
            {
                count--;//카운트 다운 시작
               if(count <0)
                {
                    index++; //최초 10초가 다 지나면 배열 인덱스 증가
                    if(index >= times.Length)//턴이 모두 실행 됐을 때
                    {
                        timer.Stop(); //타이머 동작 중지 후 턴 종료 메세지 박스
                        MessageBox.Show("Turn End");
                        return;
                    }
                    switch(index)
                    {
                        case 0://최초 상태
                            LabelStatus.Text = " ";
                            break;
                        case 1://준비 단계
                            LabelStatus.Text = "Ready...";
                            break;
                        case 2://그리는 단계
                            LabelStatus.Text = "Drawing...";
                            break;
                    }
                    count = times[index];//다음 시간 대입
                }
               LabelTimer.Text = count.ToString();  
                
            };
            timer.Start();
                

        }
    }
}