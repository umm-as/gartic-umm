using System;
using MetroFramework.Forms;

namespace GarticUmm
{
    
    public partial class GUFinishForm : MetroForm
    {
        public delegate void WordEventHandler(string present, int imageIdx);
        public event WordEventHandler OnChoosed;

        private string[] presents; // 제시어
        private string present;
        private int presentCnt = 0;
        private int imageIdx; // 현재 그림 인덱스 0이면 왼쪽으로 더이상 넘길 수 없고 present의 크기-2이면 오른쪽으로 넘기지 않음

        public GUFinishForm(string[] presents)
        {
            InitializeComponent();
            this.presents = presents;
        }

        private void GUFinishForm_Load(object sender, EventArgs e)
        {
            present = "";
            imageIdx = 0;
            this.btnPicLeft.Enabled = false;
            this.btnPicRight.Enabled = false;

            foreach (string present in presents)
            {
                if (present != null)
                {
                    Words.Items.Add(present);
                    presentCnt++;
                }
            }
        }

        private void btnPicLeft_Click(object sender, EventArgs e)
        {
            imageIdx--;

            btnDisabler();

            OnChoosed(present, imageIdx);
        }

        private void btnPicRight_Click(object sender, EventArgs e)
        {
            imageIdx++;
            
            btnDisabler();

            OnChoosed(present, imageIdx);
        }

        private void btnDisabler()
        {
            if (imageIdx == 0)
            {
                this.btnPicLeft.Enabled = false;
            } 
            else
            {
                this.btnPicLeft.Enabled = true;
            }

            if (imageIdx == presentCnt - 2)
            {
                this.btnPicRight.Enabled = false;
            }
            else
            {
                this.btnPicRight.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Words_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Words.SelectedIndex >= 0)
            {
                present = Words.SelectedItem as string;
                imageIdx = 0;
                this.btnPicLeft.Enabled = false;
                this.btnPicRight.Enabled = true;
                OnChoosed(present, imageIdx);
            }
        }

        private void GUFinishForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            OnChoosed("", -1);
        }
    }
}
