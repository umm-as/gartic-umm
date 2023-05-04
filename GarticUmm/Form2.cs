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
using System.Timers;


namespace GarticUmm
{    
    public partial class GUGameForm : MetroForm
    {
        int duration = 10;// 최초 실행시 사진 확인 시간 10초로 초기화
        DateTime dt;    
        public GUGameForm()
        {
            InitializeComponent();
            dt = new DateTime(); //현재 시간 초기화
            timer1.Interval = 1000; //1초마다 Tick 실행
            timer1.Enabled = true;
        }
        int[] times = { 10, 3, 30 }; //한 턴에 사용 되는 시간들의 배열, 사진 확인 10초, 준비 3초, 그리는 시간 30초
        int index = 0;// 배열의 인덱스
        private void timer1_Tick(object sender, EventArgs e)
        {            
            duration--; //남은 시간을 1초마다 감소
            if(duration < 0)
            {
                index++;//배열 인덱스 증가
                if(index >= times.Length)//진행 중인 카운트다운들이 다 끝났을 때
                {
                    timer1.Enabled=false;
                    MessageBox.Show("Turn End"); //임시로 메시지 박스 표현, 한 턴 끝
                    return;
                }
                switch (index)//각 시간마다 LabelStatus 변경
                {
                    case 0:
                        LabelStatus.Text = " ";
                        break;
                    case 1:
                        LabelStatus.Text = "Ready...";
                        break;
                    case 2:
                        LabelStatus.Text = "Drawing..";
                        break;
                }
                duration = times[index];//다음 카운트다운 시간 설정
                dt = new DateTime();
           
            }          
            LabelTimer.Text = dt.AddSeconds(duration).ToString("ss");//남은 시간을 LabelTimer에 표현          
        }
    }                
}

