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
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DataPass(Wordbox.Text); // 버튼 클릭시 이벤트 호출
        }

        private void Wordbox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DataPass(Wordbox.Text); // 버튼 클릭시 이벤트 호출
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
