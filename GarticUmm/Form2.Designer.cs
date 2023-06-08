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
            this.whitebtn = new System.Windows.Forms.ToolBarButton();
            this.eraserbtn = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.MessageLog = new System.Windows.Forms.RichTextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.MessageSend = new MetroFramework.Controls.MetroTextBox();
            this.SendButton = new MetroFramework.Controls.MetroButton();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.stateLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 582);
            this.splitContainer1.SplitterDistance = 696;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel.Location = new System.Drawing.Point(0, 44);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(696, 538);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
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
            this.whitebtn,
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
            // whitebtn
            // 
            this.whitebtn.ImageIndex = 10;
            this.whitebtn.Name = "whitebtn";
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
            this.imageList1.Images.SetKeyName(10, "btn_white.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.MessageLog);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(358, 582);
            this.splitContainer2.SplitterDistance = 551;
            this.splitContainer2.TabIndex = 0;
            // 
            // MessageLog
            // 
            this.MessageLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLog.Font = new System.Drawing.Font("MV Boli", 10F);
            this.MessageLog.Location = new System.Drawing.Point(0, 0);
            this.MessageLog.Name = "MessageLog";
            this.MessageLog.ReadOnly = true;
            this.MessageLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.MessageLog.Size = new System.Drawing.Size(358, 551);
            this.MessageLog.TabIndex = 6;
            this.MessageLog.Text = "";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.MessageSend);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.SendButton);
            this.splitContainer3.Size = new System.Drawing.Size(358, 27);
            this.splitContainer3.SplitterDistance = 298;
            this.splitContainer3.TabIndex = 0;
            // 
            // MessageSend
            // 
            // 
            // 
            // 
            this.MessageSend.CustomButton.Image = null;
            this.MessageSend.CustomButton.Location = new System.Drawing.Point(272, 1);
            this.MessageSend.CustomButton.Name = "";
            this.MessageSend.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.MessageSend.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.MessageSend.CustomButton.TabIndex = 1;
            this.MessageSend.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MessageSend.CustomButton.UseSelectable = true;
            this.MessageSend.CustomButton.Visible = false;
            this.MessageSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageSend.Lines = new string[0];
            this.MessageSend.Location = new System.Drawing.Point(0, 0);
            this.MessageSend.MaxLength = 32767;
            this.MessageSend.Name = "MessageSend";
            this.MessageSend.PasswordChar = '\0';
            this.MessageSend.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.MessageSend.SelectedText = "";
            this.MessageSend.SelectionLength = 0;
            this.MessageSend.SelectionStart = 0;
            this.MessageSend.ShortcutsEnabled = true;
            this.MessageSend.Size = new System.Drawing.Size(298, 27);
            this.MessageSend.TabIndex = 7;
            this.MessageSend.UseSelectable = true;
            this.MessageSend.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.MessageSend.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.MessageSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageSend_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendButton.Location = new System.Drawing.Point(0, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(56, 27);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send";
            this.SendButton.UseSelectable = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
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
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.stateLabel.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.stateLabel.Location = new System.Drawing.Point(23, 22);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(114, 25);
            this.stateLabel.TabIndex = 1;
            this.stateLabel.Text = "Gartic Umm";
            this.stateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stateLabel.UseStyleColors = true;
            // 
            // GUGameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1098, 666);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GUGameForm";
            this.Padding = new System.Windows.Forms.Padding(20, 63, 20, 21);
            this.Resizable = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUGameForm_FormClosed);
            this.Load += new System.EventHandler(this.GUGameForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.ToolBarButton whitebtn;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox MessageLog;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private MetroFramework.Controls.MetroTextBox MessageSend;
        private MetroFramework.Controls.MetroButton SendButton;
        private MetroFramework.Controls.MetroLabel stateLabel;
    }
}