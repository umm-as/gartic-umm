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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUGameForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel = new System.Windows.Forms.Panel();
            this.toolBar2 = new System.Windows.Forms.ToolBar();
            this.thinbtn = new System.Windows.Forms.ToolBarButton();
            this.middlebtn = new System.Windows.Forms.ToolBarButton();
            this.thickbtn = new System.Windows.Forms.ToolBarButton();
            this.redbtn = new System.Windows.Forms.ToolBarButton();
            this.yellowbtn = new System.Windows.Forms.ToolBarButton();
            this.greenbtn = new System.Windows.Forms.ToolBarButton();
            this.bluebtn = new System.Windows.Forms.ToolBarButton();
            this.purplebtn = new System.Windows.Forms.ToolBarButton();
            this.blackbtn = new System.Windows.Forms.ToolBarButton();
            this.eraserbtn = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.LabelStatus = new MetroFramework.Controls.MetroLabel();
            this.LabelTimer = new MetroFramework.Controls.MetroLabel();
            this.SendButton = new MetroFramework.Controls.MetroButton();
            this.MessageLog = new MetroFramework.Controls.MetroTextBox();
            this.MessageSend = new MetroFramework.Controls.MetroTextBox();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel);
            this.splitContainer1.Panel1.Controls.Add(this.toolBar2);
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
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 44);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(696, 538);
            this.panel.TabIndex = 1;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // toolBar2
            // 
            this.toolBar2.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.thinbtn,
            this.middlebtn,
            this.thickbtn,
            this.redbtn,
            this.yellowbtn,
            this.greenbtn,
            this.bluebtn,
            this.purplebtn,
            this.blackbtn,
            this.eraserbtn});
            this.toolBar2.DropDownArrows = true;
            this.toolBar2.ImageList = this.imageList1;
            this.toolBar2.Location = new System.Drawing.Point(0, 0);
            this.toolBar2.Name = "toolBar2";
            this.toolBar2.ShowToolTips = true;
            this.toolBar2.Size = new System.Drawing.Size(696, 44);
            this.toolBar2.TabIndex = 0;
            this.toolBar2.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar2_ButtonClick);
            // 
            // thinbtn
            // 
            this.thinbtn.ImageIndex = 0;
            this.thinbtn.Name = "thinbtn";
            // 
            // middlebtn
            // 
            this.middlebtn.ImageIndex = 1;
            this.middlebtn.Name = "middlebtn";
            // 
            // thickbtn
            // 
            this.thickbtn.ImageIndex = 2;
            this.thickbtn.Name = "thickbtn";
            // 
            // redbtn
            // 
            this.redbtn.ImageIndex = 3;
            this.redbtn.Name = "redbtn";
            // 
            // yellowbtn
            // 
            this.yellowbtn.ImageIndex = 4;
            this.yellowbtn.Name = "yellowbtn";
            // 
            // greenbtn
            // 
            this.greenbtn.ImageIndex = 5;
            this.greenbtn.Name = "greenbtn";
            // 
            // bluebtn
            // 
            this.bluebtn.ImageIndex = 6;
            this.bluebtn.Name = "bluebtn";
            // 
            // purplebtn
            // 
            this.purplebtn.ImageIndex = 7;
            this.purplebtn.Name = "purplebtn";
            // 
            // blackbtn
            // 
            this.blackbtn.ImageIndex = 8;
            this.blackbtn.Name = "blackbtn";
            // 
            // eraserbtn
            // 
            this.eraserbtn.ImageIndex = 9;
            this.eraserbtn.Name = "eraserbtn";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Tag = "";
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn_small.png");
            this.imageList1.Images.SetKeyName(1, "btn_medium.png");
            this.imageList1.Images.SetKeyName(2, "btn_big.png");
            this.imageList1.Images.SetKeyName(3, "btn_red.png");
            this.imageList1.Images.SetKeyName(4, "btn_yellow.png");
            this.imageList1.Images.SetKeyName(5, "btn_green.png");
            this.imageList1.Images.SetKeyName(6, "btn_blue.png");
            this.imageList1.Images.SetKeyName(7, "btn_purple.png");
            this.imageList1.Images.SetKeyName(8, "btn_black.png");
            this.imageList1.Images.SetKeyName(9, "btn_eraser.png");
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(17, 33);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(43, 19);
            this.LabelStatus.TabIndex = 3;
            this.LabelStatus.Text = "Status";
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.Location = new System.Drawing.Point(231, 33);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(43, 19);
            this.LabelTimer.TabIndex = 0;
            this.LabelTimer.Text = "Timer";
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
            // toolBar1
            // 
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Location = new System.Drawing.Point(3, 19);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(737, 42);
            this.toolBar1.TabIndex = 0;
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroButton SendButton;
        private MetroFramework.Controls.MetroTextBox MessageLog;
        private MetroFramework.Controls.MetroTextBox MessageSend;
        private MetroFramework.Controls.MetroLabel LabelStatus;
        private MetroFramework.Controls.MetroLabel LabelTimer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBar toolBar2;
        private System.Windows.Forms.ToolBarButton thinbtn;
        private System.Windows.Forms.ToolBarButton middlebtn;
        private System.Windows.Forms.ToolBarButton thickbtn;
        private System.Windows.Forms.ToolBarButton redbtn;
        private System.Windows.Forms.ToolBarButton yellowbtn;
        private System.Windows.Forms.ToolBarButton greenbtn;
        private System.Windows.Forms.ToolBarButton bluebtn;
        private System.Windows.Forms.ToolBarButton purplebtn;
        private System.Windows.Forms.ToolBarButton blackbtn;
        private System.Windows.Forms.ToolBarButton eraserbtn;
        private System.Windows.Forms.Panel panel;
    }
}