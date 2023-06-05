namespace GarticUmm
{
    partial class GUFinishForm
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
            this.panel = new System.Windows.Forms.Panel();
            this.btnPicLeft = new System.Windows.Forms.Button();
            this.btnPicRight = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Wordlist = new System.Windows.Forms.ListBox();
            this.Word = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(206, 105);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(696, 538);
            this.panel.TabIndex = 0;
            // 
            // btnPicLeft
            // 
            this.btnPicLeft.Location = new System.Drawing.Point(48, 303);
            this.btnPicLeft.Name = "btnPicLeft";
            this.btnPicLeft.Size = new System.Drawing.Size(75, 94);
            this.btnPicLeft.TabIndex = 0;
            this.btnPicLeft.Text = "◀";
            this.btnPicLeft.UseVisualStyleBackColor = true;
            this.btnPicLeft.Click += new System.EventHandler(this.btnPicLeft_Click);
            // 
            // btnPicRight
            // 
            this.btnPicRight.Location = new System.Drawing.Point(967, 303);
            this.btnPicRight.Name = "btnPicRight";
            this.btnPicRight.Size = new System.Drawing.Size(75, 94);
            this.btnPicRight.TabIndex = 1;
            this.btnPicRight.Text = "▶";
            this.btnPicRight.UseVisualStyleBackColor = true;
            this.btnPicRight.Click += new System.EventHandler(this.btnPicRight_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(967, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // Wordlist
            // 
            this.Wordlist.FormattingEnabled = true;
            this.Wordlist.ItemHeight = 18;
            this.Wordlist.Location = new System.Drawing.Point(206, 24);
            this.Wordlist.Name = "Wordlist";
            this.Wordlist.Size = new System.Drawing.Size(323, 40);
            this.Wordlist.TabIndex = 3;
            this.Wordlist.SelectedIndexChanged += new System.EventHandler(this.Words_SelectedIndexChanged);
            // 
            // Word
            // 
            this.Word.AutoSize = true;
            this.Word.Location = new System.Drawing.Point(572, 24);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(54, 18);
            this.Word.TabIndex = 4;
            this.Word.Text = "label1";
            // 
            // GUFinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 666);
            this.Controls.Add(this.Word);
            this.Controls.Add(this.Wordlist);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPicRight);
            this.Controls.Add(this.btnPicLeft);
            this.Controls.Add(this.panel);
            this.Name = "GUFinishForm";
            this.Text = "Finish";
            this.Load += new System.EventHandler(this.GUFinishForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnPicLeft;
        private System.Windows.Forms.Button btnPicRight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox Wordlist;
        private System.Windows.Forms.Label Word;
    }
}