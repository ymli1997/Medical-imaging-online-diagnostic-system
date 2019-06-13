namespace CloudDiagnosis.UI.Configuration
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIPV6Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.checkBoxIsSaveToConfiguration = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "IPV6地址：";
            // 
            // textBoxIPV6Address
            // 
            this.textBoxIPV6Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxIPV6Address.Location = new System.Drawing.Point(150, 48);
            this.textBoxIPV6Address.Name = "textBoxIPV6Address";
            this.textBoxIPV6Address.Size = new System.Drawing.Size(240, 21);
            this.textBoxIPV6Address.TabIndex = 38;
            this.textBoxIPV6Address.Text = "2001:250:4800:ef:a4fe:bc62:9bc2:8f6b";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "端口号：";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPort.Location = new System.Drawing.Point(150, 95);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(240, 21);
            this.textBoxPort.TabIndex = 40;
            this.textBoxPort.Text = "3003";
            // 
            // checkBoxIsSaveToConfiguration
            // 
            this.checkBoxIsSaveToConfiguration.AutoSize = true;
            this.checkBoxIsSaveToConfiguration.Checked = true;
            this.checkBoxIsSaveToConfiguration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsSaveToConfiguration.Location = new System.Drawing.Point(65, 155);
            this.checkBoxIsSaveToConfiguration.Name = "checkBoxIsSaveToConfiguration";
            this.checkBoxIsSaveToConfiguration.Size = new System.Drawing.Size(144, 16);
            this.checkBoxIsSaveToConfiguration.TabIndex = 41;
            this.checkBoxIsSaveToConfiguration.Text = "将配置保存到配置文件";
            this.checkBoxIsSaveToConfiguration.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(330, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveSetting
            // 
            this.buttonSaveSetting.Location = new System.Drawing.Point(219, 203);
            this.buttonSaveSetting.Name = "buttonSaveSetting";
            this.buttonSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSetting.TabIndex = 42;
            this.buttonSaveSetting.Text = "确认";
            this.buttonSaveSetting.UseVisualStyleBackColor = true;
            this.buttonSaveSetting.Click += new System.EventHandler(this.buttonSaveSetting_Click);
            // 
            // FormSystemSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 271);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveSetting);
            this.Controls.Add(this.checkBoxIsSaveToConfiguration);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIPV6Address);
            this.Controls.Add(this.label1);
            this.Name = "FormSystemSetting";
            this.Text = "系统设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIPV6Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.CheckBox checkBoxIsSaveToConfiguration;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveSetting;
    }
}