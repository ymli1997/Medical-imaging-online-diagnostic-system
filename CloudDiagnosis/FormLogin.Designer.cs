namespace CloudDiagnosis
{
    partial class FormLogin
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
            this.grpLogOn = new System.Windows.Forms.GroupBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            this.labUserNameReq = new System.Windows.Forms.Label();
            this.labPasswordReq = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.grpLogOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogOn
            // 
            this.grpLogOn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogOn.Controls.Add(this.textBoxPassword);
            this.grpLogOn.Controls.Add(this.textBoxUser);
            this.grpLogOn.Controls.Add(this.checkBoxRememberPassword);
            this.grpLogOn.Controls.Add(this.labUserNameReq);
            this.grpLogOn.Controls.Add(this.labPasswordReq);
            this.grpLogOn.Controls.Add(this.lblUser);
            this.grpLogOn.Controls.Add(this.lblPassword);
            this.grpLogOn.Location = new System.Drawing.Point(12, 60);
            this.grpLogOn.Name = "grpLogOn";
            this.grpLogOn.Size = new System.Drawing.Size(437, 118);
            this.grpLogOn.TabIndex = 1;
            this.grpLogOn.TabStop = false;
            this.grpLogOn.Text = "登录";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(106, 53);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(287, 28);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(106, 20);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(287, 28);
            this.textBoxUser.TabIndex = 7;
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(11, 87);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(106, 22);
            this.checkBoxRememberPassword.TabIndex = 6;
            this.checkBoxRememberPassword.Text = "记住密码";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // labUserNameReq
            // 
            this.labUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUserNameReq.AutoSize = true;
            this.labUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.labUserNameReq.Location = new System.Drawing.Point(398, 23);
            this.labUserNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labUserNameReq.Name = "labUserNameReq";
            this.labUserNameReq.Size = new System.Drawing.Size(17, 18);
            this.labUserNameReq.TabIndex = 2;
            this.labUserNameReq.Text = "*";
            // 
            // labPasswordReq
            // 
            this.labPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labPasswordReq.AutoSize = true;
            this.labPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.labPasswordReq.Location = new System.Drawing.Point(398, 56);
            this.labPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPasswordReq.Name = "labPasswordReq";
            this.labPasswordReq.Size = new System.Drawing.Size(17, 18);
            this.labPasswordReq.TabIndex = 5;
            this.labPasswordReq.Text = "*";
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(8, 23);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(92, 17);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "用户(&U)：";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(8, 53);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(92, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConfirm.Location = new System.Drawing.Point(235, 184);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(91, 38);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "登录(&L)";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(346, 184);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 38);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::CloudDiagnosis.Properties.Resources.info;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(452, 227);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.grpLogOn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智慧云眼-登录";
            this.grpLogOn.ResumeLayout(false);
            this.grpLogOn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogOn;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
        private System.Windows.Forms.Label labUserNameReq;
        private System.Windows.Forms.Label labPasswordReq;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}