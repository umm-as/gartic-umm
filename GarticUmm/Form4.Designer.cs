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
            this.btnPicLeft = new System.Windows.Forms.Button();
            this.btnPicRight = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Word = new System.Windows.Forms.Label();
            this.Words = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPicLeft
            // 
            this.btnPicLeft.Location = new System.Drawing.Point(91, 136);
            this.btnPicLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPicLeft.Name = "btnPicLeft";
            this.btnPicLeft.Size = new System.Drawing.Size(19, 20);
            this.btnPicLeft.TabIndex = 0;
            this.btnPicLeft.Text = "◀";
            this.btnPicLeft.UseVisualStyleBackColor = true;
            this.btnPicLeft.Click += new System.EventHandler(this.btnPicLeft_Click);
            // 
            // btnPicRight
            // 
            this.btnPicRight.Location = new System.Drawing.Point(193, 136);
            this.btnPicRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPicRight.Name = "btnPicRight";
            this.btnPicRight.Size = new System.Drawing.Size(19, 20);
            this.btnPicRight.TabIndex = 1;
            this.btnPicRight.Text = "▶";
            this.btnPicRight.UseVisualStyleBackColor = true;
            this.btnPicRight.Click += new System.EventHandler(this.btnPicRight_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(251, 176);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Word
            // 
            this.Word.AutoSize = true;
            this.Word.Location = new System.Drawing.Point(134, 139);
            this.Word.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Word.Name = "Word";
            this.Word.Size = new System.Drawing.Size(35, 13);
            this.Word.TabIndex = 4;
            this.Word.Text = "label1";
            // 
            // Words
            // 
            this.Words.FormattingEnabled = true;
            this.Words.Location = new System.Drawing.Point(91, 67);
            this.Words.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Words.Name = "Words";
            this.Words.Size = new System.Drawing.Size(123, 21);
            this.Words.TabIndex = 5;
            this.Words.SelectedIndexChanged += new System.EventHandler(this.Words_SelectedIndexChanged);
            // 
            // GUFinishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 218);
            this.Controls.Add(this.Words);
            this.Controls.Add(this.Word);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPicRight);
            this.Controls.Add(this.btnPicLeft);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GUFinishForm";
            this.Padding = new System.Windows.Forms.Padding(12, 43, 12, 14);
            this.Text = "Finish";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUFinishForm_FormClosed);
            this.Load += new System.EventHandler(this.GUFinishForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPicLeft;
        private System.Windows.Forms.Button btnPicRight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label Word;
        private System.Windows.Forms.ComboBox Words;
    }
}