using MetroFramework.Forms;
using System.Windows.Forms;

namespace GarticUmm
{
    public partial class AccessClientForm : MetroForm
    {
        public AccessClientForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            GUGameForm gameForm = new GUGameForm(false, ipTextBox.Text);
            this.Hide();
            gameForm.Owner = this;
            gameForm.ShowDialog();

            this.Close();
        }
    }
}
