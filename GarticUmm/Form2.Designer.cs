namespace GarticUmm
{
    partial class GUGameForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.SendButton = new MetroFramework.Controls.MetroButton();
            this.MessageLog = new MetroFramework.Controls.MetroTextBox();
            this.MessageSend = new MetroFramework.Controls.MetroTextBox();
            this.LabelTimer = new MetroFramework.Controls.MetroLabel();
            this.LabelStatus = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(20, 63);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LabelStatus);
            this.splitContainer1.Panel2.Controls.Add(this.LabelTimer);
            this.splitContainer1.Panel2.Controls.Add(this.SendButton);
            this.splitContainer1.Panel2.Controls.Add(this.MessageLog);
            this.splitContainer1.Panel2.Controls.Add(this.MessageSend);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 582);
            this.splitContainer1.SplitterDistance = 696;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(696, 582);
            this.splitContainer2.SplitterDistance = 77;
            this.splitContainer2.TabIndex = 1;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(288, 556);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(67, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseSelectable = true;
            // 
            // MessageLog
            // 
            // 
            // 
            // 
            this.MessageLog.CustomButton.Image = null;
            this.MessageLog.CustomButton.Location = new System.Drawing.Point(-113, 1);
            this.MessageLog.CustomButton.Name = "";
            this.MessageLog.CustomButton.Size = new System.Drawing.Size(465, 465);
            this.MessageLog.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MessageLog.CustomButton.TabIndex = 1;
            this.MessageLog.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MessageLog.CustomButton.UseSelectable = true;
            this.MessageLog.CustomButton.Visible = false;
            this.MessageLog.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.MessageLog.Lines = new string[0];
            this.MessageLog.Location = new System.Drawing.Point(2, 83);
            this.MessageLog.MaxLength = 32767;
            this.MessageLog.Multiline = true;
            this.MessageLog.Name = "MessageLog";
            this.MessageLog.PasswordChar = '\0';
            this.MessageLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.MessageLog.SelectedText = "";
            this.MessageLog.SelectionLength = 0;
            this.MessageLog.SelectionStart = 0;
            this.MessageLog.ShortcutsEnabled = true;
            this.MessageLog.Size = new System.Drawing.Size(353, 467);
            this.MessageLog.TabIndex = 1;
            this.MessageLog.UseSelectable = true;
            this.MessageLog.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MessageLog.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MessageSend
            // 
            // 
            // 
            // 
            this.MessageSend.CustomButton.Image = null;
            this.MessageSend.CustomButton.Location = new System.Drawing.Point(258, 1);
            this.MessageSend.CustomButton.Name = "";
            this.MessageSend.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.MessageSend.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MessageSend.CustomButton.TabIndex = 1;
            this.MessageSend.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MessageSend.CustomButton.UseSelectable = true;
            this.MessageSend.CustomButton.Visible = false;
            this.MessageSend.Lines = new string[0];
            this.MessageSend.Location = new System.Drawing.Point(2, 556);
            this.MessageSend.MaxLength = 32767;
            this.MessageSend.Name = "MessageSend";
            this.MessageSend.PasswordChar = '\0';
            this.MessageSend.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MessageSend.SelectedText = "";
            this.MessageSend.SelectionLength = 0;
            this.MessageSend.SelectionStart = 0;
            this.MessageSend.ShortcutsEnabled = true;
            this.MessageSend.Size = new System.Drawing.Size(280, 23);
            this.MessageSend.TabIndex = 0;
            this.MessageSend.UseSelectable = true;
            this.MessageSend.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MessageSend.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.Location = new System.Drawing.Point(231, 33);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(45, 20);
            this.LabelTimer.TabIndex = 0;
            this.LabelTimer.Text = "Timer";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(17, 33);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(45, 20);
            this.LabelStatus.TabIndex = 3;
            this.LabelStatus.Text = "Status";
            // 
            // GUGameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1098, 666);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GUGameForm";
            this.Padding = new System.Windows.Forms.Padding(20, 63, 20, 21);
            this.Resizable = false;
            this.Text = "Gartic Umm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroButton SendButton;
        private MetroFramework.Controls.MetroTextBox MessageLog;
        private MetroFramework.Controls.MetroTextBox MessageSend;
        private MetroFramework.Controls.MetroLabel LabelStatus;
        private MetroFramework.Controls.MetroLabel LabelTimer;
    }
}