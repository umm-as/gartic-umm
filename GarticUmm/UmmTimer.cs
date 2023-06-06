using System;
using System.Windows.Forms;

namespace UmmTimerNS
{
    class UmmTimer
    {
        private Timer timer; //초기상태 초기화
        private int count;
        private bool isOwnImage; // 제시어의 그림인지 확인
        private TimerType state;

        public enum TimerType //확인단계, 준비단계, 그리는단계, 턴 종료별 시간 선언
        {
            Check = 5,
            Ready = 3,
            Drawing = 6,
            TurnEnd = -1,
            Terminate = -2,
        }

        public delegate void TimerEventHandler(TimerType type, int count);
        public event TimerEventHandler EventHandler; //GuGameForm이벤트 핸들러

        public UmmTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerTick);
        }

        private void TimerTick(object s, EventArgs e)
        {
            count--;

            if (state == TimerType.Check && count < 0) //최초의 Check상태가 끝났을 때
            {
                count = (int)TimerType.Ready;
                state = TimerType.Ready;
            }
            else if (state == TimerType.Ready && count < 0) //Ready상태가 끝났을 때
            {
                count = (int)TimerType.Drawing;
                state = TimerType.Drawing;
            }
            else if (state == TimerType.Drawing && count < 0) //Drawing상태가 끝났을 때
            {
                timer.Stop();
                state = TimerType.TurnEnd;
            }

            EventHandler(state, count);
        }

        public void TimerStart(bool isOwnImage)
        {
            this.isOwnImage = isOwnImage;

            if (isOwnImage) // 제시어 그림 그릴 때는 check단계 생략
            {
                count = (int)TimerType.Ready;
                state = TimerType.Ready;
            }
            else
            { 
                count = (int)TimerType.Check;
                state = TimerType.Check;
            }
            timer.Start();
        }

        public void TimerStop()
        {
            timer.Stop();
            state = TimerType.Terminate;
            EventHandler(state, (int)state);
        }
        
        public void TimerReset()
        {
            timer.Stop();
            count= 0;
            state = TimerType.Check;
        }
    }
}
