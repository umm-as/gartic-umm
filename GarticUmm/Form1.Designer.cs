namespace GarticUmm
{
    partial class GULoginForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnCreateServer = new MetroFramework.Controls.MetroButton();
            this.btnJoinServer = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateServer
            // 
            this.btnCreateServer.Location = new System.Drawing.Point(148, 180);
            this.btnCreateServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateServer.Name = "btnCreateServer";
            this.btnCreateServer.Size = new System.Drawing.Size(172, 52);
            this.btnCreateServer.TabIndex = 0;
            this.btnCreateServer.Text = "Create Server";
            this.btnCreateServer.UseSelectable = true;
            this.btnCreateServer.Click += new System.EventHandler(this.btnCreateServer_Click);
            // 
            // btnJoinServer
            // 
            this.btnJoinServer.Location = new System.Drawing.Point(412, 180);
            this.btnJoinServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnJoinServer.Name = "btnJoinServer";
            this.btnJoinServer.Size = new System.Drawing.Size(172, 52);
            this.btnJoinServer.TabIndex = 1;
            this.btnJoinServer.Text = "Join Server";
            this.btnJoinServer.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(132, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 87);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gartic Umm";
            // 
            // GULoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 338);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoinServer);
            this.Controls.Add(this.btnCreateServer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GULoginForm";
            this.Padding = new System.Windows.Forms.Padding(18, 50, 18, 15);
            this.Resizable = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private MetroFramework.Controls.MetroButton btnCreateServer;
        private MetroFramework.Controls.MetroButton btnJoinServer;
        private System.Windows.Forms.Label label1;
    }
}

