namespace CloudDiagnosis.UI.Tabs
{
    partial class FormSettings
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxIsSaveToConfiguration = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(706, 438);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxIsSaveToConfiguration
            // 
            this.checkBoxIsSaveToConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIsSaveToConfiguration.AutoSize = true;
            this.checkBoxIsSaveToConfiguration.Checked = true;
            this.checkBoxIsSaveToConfiguration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsSaveToConfiguration.Location = new System.Drawing.Point(83, 450);
            this.checkBoxIsSaveToConfiguration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsSaveToConfiguration.Name = "checkBoxIsSaveToConfiguration";
            this.checkBoxIsSaveToConfiguration.Size = new System.Drawing.Size(214, 22);
            this.checkBoxIsSaveToConfiguration.TabIndex = 34;
            this.checkBoxIsSaveToConfiguration.Text = "将配置保存到配置文件";
            this.checkBoxIsSaveToConfiguration.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 528);
            this.Controls.Add(this.checkBoxIsSaveToConfiguration);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxIsSaveToConfiguration;
    }
}