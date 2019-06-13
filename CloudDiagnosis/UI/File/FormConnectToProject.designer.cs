namespace CloudDiagnosis.UI.File
{
    partial class FormConnectToProject
    {
        /// <summary>
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。

        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            this.picCompany = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnConnectTest = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // picCompany
            // 
            this.picCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCompany.Location = new System.Drawing.Point(57, 24);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(100, 100);
            this.picCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCompany.TabIndex = 15;
            this.picCompany.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "连接字符串：";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(179, 39);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(278, 85);
            this.txtFileName.TabIndex = 19;
            // 
            // btnConnectTest
            // 
            this.btnConnectTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConnectTest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConnectTest.Location = new System.Drawing.Point(252, 145);
            this.btnConnectTest.Name = "btnConnectTest";
            this.btnConnectTest.Size = new System.Drawing.Size(75, 23);
            this.btnConnectTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConnectTest.TabIndex = 20;
            this.btnConnectTest.Text = "连接";
            this.btnConnectTest.Click += new System.EventHandler(this.btnConnectTest_Click);
            // 
            // FormConnectToProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 180);
            this.Controls.Add(this.btnConnectTest);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picCompany);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConnectToProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接到GeoMos";
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private DevComponents.DotNetBar.ButtonX btnConnectTest;
    }
}