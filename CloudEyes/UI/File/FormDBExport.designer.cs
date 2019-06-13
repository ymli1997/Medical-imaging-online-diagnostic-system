namespace CloudEyes.UI.File
{
    partial class FormDBExport
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDatabaseName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnGetSaveFileDir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "选择需要备份的数据库：";
            // 
            // comboBoxDatabaseName
            // 
            this.comboBoxDatabaseName.FormattingEnabled = true;
            this.comboBoxDatabaseName.Location = new System.Drawing.Point(179, 51);
            this.comboBoxDatabaseName.Name = "comboBoxDatabaseName";
            this.comboBoxDatabaseName.Size = new System.Drawing.Size(232, 20);
            this.comboBoxDatabaseName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "设置备份文件保存的路径：";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(179, 113);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(232, 21);
            this.txtFileName.TabIndex = 19;
            // 
            // btnGetSaveFileDir
            // 
            this.btnGetSaveFileDir.Location = new System.Drawing.Point(417, 113);
            this.btnGetSaveFileDir.Name = "btnGetSaveFileDir";
            this.btnGetSaveFileDir.Size = new System.Drawing.Size(31, 23);
            this.btnGetSaveFileDir.TabIndex = 20;
            this.btnGetSaveFileDir.Text = "...";
            this.btnGetSaveFileDir.UseVisualStyleBackColor = true;
            this.btnGetSaveFileDir.Click += new System.EventHandler(this.btnGetSaveFileDir_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(25, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(469, 47);
            this.label3.TabIndex = 22;
            this.label3.Text = "    为了保证在任何情况下都不会由于数据库损坏而造成损失，建议每次关闭程序时都对数据库进行备份，并将备份文件拷贝到其他存储一份进行保存。";
            // 
            // FormDBExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 253);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetSaveFileDir);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDatabaseName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCompany);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDBExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库备份（仅支持SqlServer）";
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDatabaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnGetSaveFileDir;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
    }
}