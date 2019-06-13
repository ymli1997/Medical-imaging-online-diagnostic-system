namespace CloudEyes.UI.Configuration
{
    partial class FormSystemSetting
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
            this.checkBoxIsSaveToConfiguration = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIPV6Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxIsSaveToConfiguration
            // 
            this.checkBoxIsSaveToConfiguration.AutoSize = true;
            this.checkBoxIsSaveToConfiguration.Checked = true;
            this.checkBoxIsSaveToConfiguration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsSaveToConfiguration.Location = new System.Drawing.Point(61, 148);
            this.checkBoxIsSaveToConfiguration.Name = "checkBoxIsSaveToConfiguration";
            this.checkBoxIsSaveToConfiguration.Size = new System.Drawing.Size(144, 16);
            this.checkBoxIsSaveToConfiguration.TabIndex = 35;
            this.checkBoxIsSaveToConfiguration.Text = "将配置保存到配置文件";
            this.checkBoxIsSaveToConfiguration.UseVisualStyleBackColor = true;
           
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "IPV6地址：";
        
            // 
            // textBoxIPV6Address
            // 
            this.textBoxIPV6Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxIPV6Address.Location = new System.Drawing.Point(133, 41);
            this.textBoxIPV6Address.Name = "textBoxIPV6Address";
            this.textBoxIPV6Address.Size = new System.Drawing.Size(240, 21);
            this.textBoxIPV6Address.TabIndex = 37;
            this.textBoxIPV6Address.Text = "2001:da8:270:2021::f";
           
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "端口号：";
           
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPort.Location = new System.Drawing.Point(133, 84);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(240, 21);
            this.textBoxPort.TabIndex = 39;
            this.textBoxPort.Text = "8080";
         
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Location = new System.Drawing.Point(197, 208);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSetting.TabIndex = 40;
            this.buttonSaveSetting.Text = "确认";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(298, 208);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 41;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormSystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 274);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveSetting);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIPV6Address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxIsSaveToConfiguration);
            this.Name = "FormSystemSetting";
            this.Text = "系统设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSystemSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSystemSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxIsSaveToConfiguration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIPV6Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Button buttonSaveSetting;
        private System.Windows.Forms.Button buttonCancel;
    }
}