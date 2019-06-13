/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CloudDiagnosis.UI.Tools
{
    partial class FormMakeFakeDailyResults
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
			if (disposing) {
				if (components != null) {
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
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQueryNodeData = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPointNo = new System.Windows.Forms.TextBox();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTimeInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaxLD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMinLD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAvgLD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAvgTD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMinTD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxMaxTD = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAvgHD = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxMinHD = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxMaxHD = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxAvTemp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPressure = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(13, 180);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(10, 40, 10, 35);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(964, 406);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "节点编号";
            // 
            // btnQueryNodeData
            // 
            this.btnQueryNodeData.Location = new System.Drawing.Point(360, 12);
            this.btnQueryNodeData.Name = "btnQueryNodeData";
            this.btnQueryNodeData.Size = new System.Drawing.Size(136, 23);
            this.btnQueryNodeData.TabIndex = 3;
            this.btnQueryNodeData.Text = "查询现有数据";
            this.btnQueryNodeData.UseVisualStyleBackColor = true;
            this.btnQueryNodeData.Click += new System.EventHandler(this.BtnQueryNodeDataClick);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(71, 44);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 21);
            this.textBoxID.TabIndex = 19;
            this.textBoxID.Text = "999";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "统一编号";
            // 
            // textBoxPointNo
            // 
            this.textBoxPointNo.Location = new System.Drawing.Point(70, 14);
            this.textBoxPointNo.Name = "textBoxPointNo";
            this.textBoxPointNo.Size = new System.Drawing.Size(100, 21);
            this.textBoxPointNo.TabIndex = 21;
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(330, 49);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(59, 12);
            this.labelEndTime.TabIndex = 25;
            this.labelEndTime.Text = "结束时间:";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "HH:mm:ss";
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(395, 43);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(85, 21);
            this.dateTimePickerEndTime.TabIndex = 24;
            this.dateTimePickerEndTime.Value = new System.DateTime(2014, 8, 21, 23, 59, 59, 0);
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(174, 49);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(59, 12);
            this.labelStartTime.TabIndex = 23;
            this.labelStartTime.Text = "开始时间:";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "HH:mm:ss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(239, 43);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(85, 21);
            this.dateTimePickerStartTime.TabIndex = 22;
            this.dateTimePickerStartTime.Value = new System.DateTime(2014, 8, 21, 0, 0, 0, 0);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(254, 14);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxTime.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "数据日期";
            // 
            // textBoxTimeInterval
            // 
            this.textBoxTimeInterval.Location = new System.Drawing.Point(574, 44);
            this.textBoxTimeInterval.Name = "textBoxTimeInterval";
            this.textBoxTimeInterval.Size = new System.Drawing.Size(64, 21);
            this.textBoxTimeInterval.TabIndex = 29;
            this.textBoxTimeInterval.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(491, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "时间间隔(分)";
            // 
            // textBoxMaxLD
            // 
            this.textBoxMaxLD.Location = new System.Drawing.Point(71, 71);
            this.textBoxMaxLD.Name = "textBoxMaxLD";
            this.textBoxMaxLD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMaxLD.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "MaxLD";
            // 
            // textBoxMinLD
            // 
            this.textBoxMinLD.Location = new System.Drawing.Point(308, 71);
            this.textBoxMinLD.Name = "textBoxMinLD";
            this.textBoxMinLD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMinLD.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "MinLD";
            // 
            // textBoxAvgLD
            // 
            this.textBoxAvgLD.Location = new System.Drawing.Point(543, 71);
            this.textBoxAvgLD.Name = "textBoxAvgLD";
            this.textBoxAvgLD.Size = new System.Drawing.Size(188, 21);
            this.textBoxAvgLD.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(502, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "AvgLD";
            // 
            // textBoxAvgTD
            // 
            this.textBoxAvgTD.Location = new System.Drawing.Point(543, 98);
            this.textBoxAvgTD.Name = "textBoxAvgTD";
            this.textBoxAvgTD.Size = new System.Drawing.Size(188, 21);
            this.textBoxAvgTD.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(502, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "AvgTD";
            // 
            // textBoxMinTD
            // 
            this.textBoxMinTD.Location = new System.Drawing.Point(308, 98);
            this.textBoxMinTD.Name = "textBoxMinTD";
            this.textBoxMinTD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMinTD.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "MinTD";
            // 
            // textBoxMaxTD
            // 
            this.textBoxMaxTD.Location = new System.Drawing.Point(71, 98);
            this.textBoxMaxTD.Name = "textBoxMaxTD";
            this.textBoxMaxTD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMaxTD.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 36;
            this.label10.Text = "MaxTD";
            // 
            // textBoxAvgHD
            // 
            this.textBoxAvgHD.Location = new System.Drawing.Point(543, 125);
            this.textBoxAvgHD.Name = "textBoxAvgHD";
            this.textBoxAvgHD.Size = new System.Drawing.Size(188, 21);
            this.textBoxAvgHD.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(502, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "AvgHD";
            // 
            // textBoxMinHD
            // 
            this.textBoxMinHD.Location = new System.Drawing.Point(308, 125);
            this.textBoxMinHD.Name = "textBoxMinHD";
            this.textBoxMinHD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMinHD.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 128);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 44;
            this.label12.Text = "MinHD";
            // 
            // textBoxMaxHD
            // 
            this.textBoxMaxHD.Location = new System.Drawing.Point(71, 125);
            this.textBoxMaxHD.Name = "textBoxMaxHD";
            this.textBoxMaxHD.Size = new System.Drawing.Size(188, 21);
            this.textBoxMaxHD.TabIndex = 43;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 42;
            this.label13.Text = "MaxHD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(737, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "生成数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 49;
            this.button2.Text = "数据入库";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAvTemp
            // 
            this.textBoxAvTemp.Location = new System.Drawing.Point(308, 152);
            this.textBoxAvTemp.Name = "textBoxAvTemp";
            this.textBoxAvTemp.Size = new System.Drawing.Size(188, 21);
            this.textBoxAvTemp.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(261, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 52;
            this.label14.Text = "AvTemp";
            // 
            // textBoxPressure
            // 
            this.textBoxPressure.Location = new System.Drawing.Point(71, 152);
            this.textBoxPressure.Name = "textBoxPressure";
            this.textBoxPressure.Size = new System.Drawing.Size(188, 21);
            this.textBoxPressure.TabIndex = 51;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 50;
            this.label15.Text = "Pressure";
            // 
            // FormMakeFakeDailyResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 596);
            this.Controls.Add(this.textBoxAvTemp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxPressure);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxAvgHD);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxMinHD);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxMaxHD);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxAvgTD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxMinTD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxMaxTD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxAvgLD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxMinLD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxMaxLD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTimeInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.textBoxPointNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.btnQueryNodeData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMain);
            this.Name = "FormMakeFakeDailyResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成测试日明细数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnQueryNodeData;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPointNo;
        private System.Windows.Forms.Label labelEndTime;
        public System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label labelStartTime;
        public System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTimeInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaxLD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMinLD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAvgLD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAvgTD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMinTD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMaxTD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAvgHD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxMinHD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxMaxHD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxAvTemp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxPressure;
        private System.Windows.Forms.Label label15;
	}
}
