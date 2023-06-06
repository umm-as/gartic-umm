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
        public delegate void WordEventHandler(string current_word, int current_pic_index);
        public event WordEventHandler Finished;

        private string[] presents; // 제시어
        private int currentPaintIndex; // 현재 그림 인덱스 0이면 왼쪽으로 더이상 넘길 수 없고 present의 크기-1이면 오른쪽으로 넘기지 않음
        private string currentWord;
        int i = 0;
        //

        public GUFinishForm(string[] image_key)
        {
            InitializeComponent();
            this.btnPicLeft.Enabled = false;
            presents = new string[image_key.Length];
            presents = image_key;
        }

        private void btnPicLeft_Click(object sender, EventArgs e)
        {
            if(currentPaintIndex == 0)
                btnPicLeft.Enabled = false;

            if(currentPaintIndex > 0)
            {
                btnPicRight.Enabled = true;
                currentPaintIndex--;
                Finished(currentWord, currentPaintIndex);
            }
        }

        private void btnPicRight_Click(object sender, EventArgs e)
        {
            if(currentPaintIndex == i-2)
                btnPicRight.Enabled = false;

            if( currentPaintIndex < i-2)
            {
                btnPicLeft.Enabled=true;
                currentPaintIndex++;
                Finished(currentWord, currentPaintIndex);
            }
        }

        private void GUFinishForm_Load(object sender, EventArgs e)
        {
            
            currentPaintIndex = 0;
            currentWord = "";
            // TODO: get presents from server
            // and parse to list
            foreach (string present in presents)
            {
                if(present != null)
                {
                    Words.Items.Add(present);
                    i++;
                }
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
                this.currentWord = Words.SelectedItem as string;
            }
        }
    }
}
