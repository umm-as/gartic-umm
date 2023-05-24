using System;
using MetroFramework.Forms;
using System.Collections.Generic;
    
namespace GarticUmm
{
    public partial class GULoginForm : MetroForm
    {
        public GULoginForm()
        {
            InitializeComponent();
        }
       
       
        private void btnCreateServer_Click(object sender, EventArgs e)
        {
            GUGameForm gameForm = new GUGameForm(true);
            gameForm.Owner = this;
            gameForm.ShowDialog();
        }

        private void btnJoinServer_Click(object sender, EventArgs e)
        {
            GUGameForm gameForm = new GUGameForm(false);
            gameForm.Owner = this;
            gameForm.ShowDialog();
        }
    }
}
