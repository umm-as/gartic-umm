using System;
using MetroFramework.Forms;

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
            GUGameForm gameForm = new GUGameForm();
            gameForm.Owner = this;
            gameForm.ShowDialog();
        }
    }
}
