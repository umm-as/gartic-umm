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

namespace GarticUmm
{
    public partial class GUWordForm : MetroFramework.Forms.MetroForm
    {
        public delegate void DataPassEventHandler(string data);
        public event DataPassEventHandler DataPass;//이벤트 생성
        public GUWordForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Wordbox.Text.Contains(","))
            {
                MessageBox.Show("You can't use \",\"!");
                return;
            }
            if (Wordbox.Text == "")
            {
                MessageBox.Show("Enter your word!");
                return;
            }
            DataPass(Wordbox.Text); // 버튼 클릭시 이벤트 호출
        }

        private void Wordbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (Wordbox.Text.Contains(","))
                {
                    MessageBox.Show("You can't use \",\"!");
                    return;
                }
                if (Wordbox.Text == "")
                {
                    MessageBox.Show("Enter your word!");
                    return;
                }
                DataPass(Wordbox.Text); // 버튼 클릭시 이벤트 호출
            }

        }
    }
}
