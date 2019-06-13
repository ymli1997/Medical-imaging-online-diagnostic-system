/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CloudEyes.UI.Tools
{
    partial class FormDicomUpload
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFileLoad = new System.Windows.Forms.TextBox();
            this.buttonFileChoose = new System.Windows.Forms.Button();
            this.textBoxPatientName = new System.Windows.Forms.TextBox();
            this.textBoxPatientAge = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPatientSex = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPatientID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxReportID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxFileLoadSeg = new System.Windows.Forms.TextBox();
            this.buttonSegFileChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(9, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "影像位置：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(11, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "姓名";
            // 
            // textBoxFileLoad
            // 
            this.textBoxFileLoad.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxFileLoad.Location = new System.Drawing.Point(70, 12);
            this.textBoxFileLoad.Name = "textBoxFileLoad";
            this.textBoxFileLoad.Size = new System.Drawing.Size(472, 21);
            this.textBoxFileLoad.TabIndex = 9;
            this.textBoxFileLoad.TextChanged += new System.EventHandler(this.textBoxFileLoad_TextChanged);
            // 
            // buttonFileChoose
            // 
            this.buttonFileChoose.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonFileChoose.Location = new System.Drawing.Point(553, 11);
            this.buttonFileChoose.Name = "buttonFileChoose";
            this.buttonFileChoose.Size = new System.Drawing.Size(75, 23);
            this.buttonFileChoose.TabIndex = 10;
            this.buttonFileChoose.Text = "文件选择";
            this.buttonFileChoose.UseVisualStyleBackColor = true;
            this.buttonFileChoose.Click += new System.EventHandler(this.buttonFileChoose_Click);
            // 
            // textBoxPatientName
            // 
            this.textBoxPatientName.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxPatientName.Location = new System.Drawing.Point(52, 92);
            this.textBoxPatientName.Name = "textBoxPatientName";
            this.textBoxPatientName.Size = new System.Drawing.Size(87, 21);
            this.textBoxPatientName.TabIndex = 11;
            // 
            // textBoxPatientAge
            // 
            this.textBoxPatientAge.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxPatientAge.Location = new System.Drawing.Point(192, 92);
            this.textBoxPatientAge.Name = "textBoxPatientAge";
            this.textBoxPatientAge.Size = new System.Drawing.Size(30, 21);
            this.textBoxPatientAge.TabIndex = 13;
            this.textBoxPatientAge.TextChanged += new System.EventHandler(this.textBoxPatientAge_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.Location = new System.Drawing.Point(151, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "年龄";
            // 
            // textBoxPatientSex
            // 
            this.textBoxPatientSex.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxPatientSex.Location = new System.Drawing.Point(275, 92);
            this.textBoxPatientSex.Name = "textBoxPatientSex";
            this.textBoxPatientSex.Size = new System.Drawing.Size(28, 21);
            this.textBoxPatientSex.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.Location = new System.Drawing.Point(234, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "性别";
            // 
            // textBoxPatientID
            // 
            this.textBoxPatientID.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxPatientID.Location = new System.Drawing.Point(368, 92);
            this.textBoxPatientID.Name = "textBoxPatientID";
            this.textBoxPatientID.Size = new System.Drawing.Size(76, 21);
            this.textBoxPatientID.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.Location = new System.Drawing.Point(315, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "检查号";
            // 
            // textBoxReportID
            // 
            this.textBoxReportID.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxReportID.Location = new System.Drawing.Point(509, 92);
            this.textBoxReportID.Name = "textBoxReportID";
            this.textBoxReportID.Size = new System.Drawing.Size(76, 21);
            this.textBoxReportID.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.Location = new System.Drawing.Point(456, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "登记号";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // richTextBoxDetails
            // 
            this.richTextBoxDetails.Location = new System.Drawing.Point(9, 163);
            this.richTextBoxDetails.Name = "richTextBoxDetails";
            this.richTextBoxDetails.Size = new System.Drawing.Size(614, 135);
            this.richTextBoxDetails.TabIndex = 21;
            this.richTextBoxDetails.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.Location = new System.Drawing.Point(12, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "检查情况：";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonUpload.Location = new System.Drawing.Point(275, 304);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 23;
            this.buttonUpload.Text = "上传";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.Location = new System.Drawing.Point(7, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "分割后影像位置：";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // textBoxFileLoadSeg
            // 
            this.textBoxFileLoadSeg.Font = new System.Drawing.Font("宋体", 9F);
            this.textBoxFileLoadSeg.Location = new System.Drawing.Point(114, 51);
            this.textBoxFileLoadSeg.Name = "textBoxFileLoadSeg";
            this.textBoxFileLoadSeg.Size = new System.Drawing.Size(428, 21);
            this.textBoxFileLoadSeg.TabIndex = 25;
            // 
            // buttonSegFileChoose
            // 
            this.buttonSegFileChoose.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonSegFileChoose.Location = new System.Drawing.Point(553, 49);
            this.buttonSegFileChoose.Name = "buttonSegFileChoose";
            this.buttonSegFileChoose.Size = new System.Drawing.Size(75, 23);
            this.buttonSegFileChoose.TabIndex = 26;
            this.buttonSegFileChoose.Text = "文件选择";
            this.buttonSegFileChoose.UseVisualStyleBackColor = true;
            this.buttonSegFileChoose.Click += new System.EventHandler(this.buttonSegFileChoose_Click);
            // 
            // FormDicomUpload
            // 
            this.ClientSize = new System.Drawing.Size(640, 342);
            this.Controls.Add(this.buttonSegFileChoose);
            this.Controls.Add(this.textBoxFileLoadSeg);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.richTextBoxDetails);
            this.Controls.Add(this.textBoxReportID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxPatientID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxPatientSex);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxPatientAge);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPatientName);
            this.Controls.Add(this.buttonFileChoose);
            this.Controls.Add(this.textBoxFileLoad);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "FormDicomUpload";
            this.Text = "影像上传";
            this.Load += new System.EventHandler(this.FormDicomUpload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private DevComponents.DotNetBar.DotNetBarManager dotNetBarManagerPrediction;
        private DevComponents.DotNetBar.DockSite dockSite4;
        private DevComponents.DotNetBar.DockSite dockSite1;
        private DevComponents.DotNetBar.DockSite dockSite2;
        private DevComponents.DotNetBar.DockSite dockSite3;
        private DevComponents.DotNetBar.DockSite dockSite5;
        private DevComponents.DotNetBar.DockSite dockSite6;
        private DevComponents.DotNetBar.DockSite dockSite7;
        private DevComponents.DotNetBar.DockSite dockSite8;
        private DevComponents.DotNetBar.Bar barMain;
        private DevComponents.DotNetBar.ButtonItem toolbarItemExportDt2Excel;
        private System.Windows.Forms.ImageList imageListToolbar;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxFileLoad;
        private System.Windows.Forms.Button buttonFileChoose;
        private System.Windows.Forms.TextBox textBoxPatientName;
        private System.Windows.Forms.TextBox textBoxPatientAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPatientSex;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPatientID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxReportID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxFileLoadSeg;
        private System.Windows.Forms.Button buttonSegFileChoose;
    }
}
