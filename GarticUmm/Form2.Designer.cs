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
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolBar2);
            this.splitContainer1.Size = new System.Drawing.Size(1045, 770);
            this.splitContainer1.SplitterDistance = 737;
            this.splitContainer1.TabIndex = 0;
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
            this.toolBar2.Size = new System.Drawing.Size(737, 44);
            this.toolBar2.TabIndex = 0;
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
            // GUGameForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1085, 854);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("MV Boli", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GUGameForm";
            this.Padding = new System.Windows.Forms.Padding(20, 63, 20, 21);
            this.Resizable = false;
            this.Text = "Gartic Umm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}