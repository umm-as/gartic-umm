namespace GarticUmm
{
    partial class GUWordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new MetroFramework.Controls.MetroButton();
            this.Wordbox = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(295, 122);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 29);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseSelectable = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Wordbox
            // 
            // 
            // 
            // 
            this.Wordbox.CustomButton.Image = null;
            this.Wordbox.CustomButton.Location = new System.Drawing.Point(196, 1);
            this.Wordbox.CustomButton.Name = "";
            this.Wordbox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.Wordbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Wordbox.CustomButton.TabIndex = 1;
            this.Wordbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Wordbox.CustomButton.UseSelectable = true;
            this.Wordbox.CustomButton.Visible = false;
            this.Wordbox.Lines = new string[0];
            this.Wordbox.Location = new System.Drawing.Point(42, 122);
            this.Wordbox.MaxLength = 32767;
            this.Wordbox.Name = "Wordbox";
            this.Wordbox.PasswordChar = '\0';
            this.Wordbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Wordbox.SelectedText = "";
            this.Wordbox.SelectionLength = 0;
            this.Wordbox.SelectionStart = 0;
            this.Wordbox.ShortcutsEnabled = true;
            this.Wordbox.Size = new System.Drawing.Size(224, 29);
            this.Wordbox.TabIndex = 1;
            this.Wordbox.UseSelectable = true;
            this.Wordbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Wordbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Wordbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Wordbox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "제시어를 입력해주세요!";
            // 
            // GUWordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 252);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Wordbox);
            this.Controls.Add(this.btnSend);
            this.Name = "GUWordForm";
            this.Text = "Word";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnSend;
        private MetroFramework.Controls.MetroTextBox Wordbox;
        public System.Windows.Forms.Label label1;
    }
}