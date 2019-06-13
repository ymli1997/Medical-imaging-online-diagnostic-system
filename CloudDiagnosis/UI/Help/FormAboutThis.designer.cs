namespace CloudDiagnosis.UI.Help
{
    partial class FormAboutThis
    {
        /// <summary>
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutThis));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.grpAboutThis = new System.Windows.Forms.GroupBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.lblBuy = new System.Windows.Forms.LinkLabel();
            this.lblBlog = new System.Windows.Forms.LinkLabel();
            this.picCompany = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirm.Location = new System.Drawing.Point(686, 330);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(112, 34);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "&OK";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Location = new System.Drawing.Point(118, 242);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(636, 96);
            this.lblWarning.TabIndex = 6;
            this.lblWarning.Text = resources.GetString("lblWarning.Text");
            this.lblWarning.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // grpAboutThis
            // 
            this.grpAboutThis.Location = new System.Drawing.Point(39, 216);
            this.grpAboutThis.Margin = new System.Windows.Forms.Padding(4);
            this.grpAboutThis.Name = "grpAboutThis";
            this.grpAboutThis.Padding = new System.Windows.Forms.Padding(4);
            this.grpAboutThis.Size = new System.Drawing.Size(747, 4);
            this.grpAboutThis.TabIndex = 5;
            this.grpAboutThis.TabStop = false;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Location = new System.Drawing.Point(285, 182);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(450, 24);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright 2010-2015 Rising TECH";
            this.lblCopyright.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(285, 148);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(450, 24);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version V3.7";
            this.lblVersion.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.Location = new System.Drawing.Point(285, 116);
            this.lblSoftFullName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(450, 24);
            this.lblSoftFullName.TabIndex = 2;
            this.lblSoftFullName.Text = "Deformation Analyzer";
            this.lblSoftFullName.Click += new System.EventHandler(this.FrmAboutThis_Click);
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(429, 24);
            this.lblBuy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(287, 18);
            this.lblBuy.TabIndex = 0;
            this.lblBuy.TabStop = true;
            this.lblBuy.Tag = "www2.zzu.edu.cn/calab";
            this.lblBuy.Text = "技术支持：www2.zzu.edu.cn/calab";
            this.lblBuy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkLabel_LinkClicked);
            // 
            // lblBlog
            // 
            this.lblBlog.AutoSize = true;
            this.lblBlog.Location = new System.Drawing.Point(429, 48);
            this.lblBlog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlog.Name = "lblBlog";
            this.lblBlog.Size = new System.Drawing.Size(287, 18);
            this.lblBlog.TabIndex = 1;
            this.lblBlog.TabStop = true;
            this.lblBlog.Tag = "www2.zzu.edu.cn/calab";
            this.lblBlog.Text = "购买正版：www2.zzu.edu.cn/calab";
            this.lblBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkLabel_LinkClicked);
            // 
            // picCompany
            // 
            this.picCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCompany.Image = global::CloudDiagnosis.Properties.Resources.info;
            this.picCompany.Location = new System.Drawing.Point(86, 36);
            this.picCompany.Margin = new System.Windows.Forms.Padding(4);
            this.picCompany.Name = "picCompany";
            this.picCompany.Size = new System.Drawing.Size(150, 150);
            this.picCompany.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCompany.TabIndex = 15;
            this.picCompany.TabStop = false;
            // 
            // FormAboutThis
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnConfirm;
            this.ClientSize = new System.Drawing.Size(825, 380);
            this.Controls.Add(this.picCompany);
            this.Controls.Add(this.lblBlog);
            this.Controls.Add(this.lblBuy);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.grpAboutThis);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblSoftFullName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAboutThis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于本软件";
            this.Click += new System.EventHandler(this.FrmAboutThis_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox grpAboutThis;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblSoftFullName;
        private System.Windows.Forms.LinkLabel lblBuy;
        private System.Windows.Forms.LinkLabel lblBlog;
        private System.Windows.Forms.PictureBox picCompany;
    }
}