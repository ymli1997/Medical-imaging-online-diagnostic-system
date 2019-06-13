namespace CloudDiagnosis.UI.View
{
    partial class FormSetTimePeriod
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
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnStartFromNow = new System.Windows.Forms.Button();
            this.btnEndByNow = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQueryFromDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(86, 13);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(162, 21);
            this.dateTimePickerStartTime.TabIndex = 0;
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(21, 19);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(59, 12);
            this.labelStartTime.TabIndex = 1;
            this.labelStartTime.Text = "开始时间:";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(21, 46);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(59, 12);
            this.labelEndTime.TabIndex = 3;
            this.labelEndTime.Text = "结束时间:";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(86, 40);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(162, 21);
            this.dateTimePickerEndTime.TabIndex = 2;
            // 
            // btnStartFromNow
            // 
            this.btnStartFromNow.Location = new System.Drawing.Point(254, 11);
            this.btnStartFromNow.Name = "btnStartFromNow";
            this.btnStartFromNow.Size = new System.Drawing.Size(37, 23);
            this.btnStartFromNow.TabIndex = 4;
            this.btnStartFromNow.Text = "当前";
            this.btnStartFromNow.UseVisualStyleBackColor = true;
            this.btnStartFromNow.Click += new System.EventHandler(this.btnStartFromNow_Click);
            // 
            // btnEndByNow
            // 
            this.btnEndByNow.Location = new System.Drawing.Point(254, 40);
            this.btnEndByNow.Name = "btnEndByNow";
            this.btnEndByNow.Size = new System.Drawing.Size(37, 23);
            this.btnEndByNow.TabIndex = 5;
            this.btnEndByNow.Text = "当前";
            this.btnEndByNow.UseVisualStyleBackColor = true;
            this.btnEndByNow.Click += new System.EventHandler(this.btnEndByNow_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(135, 80);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnQueryFromDatabase
            // 
            this.btnQueryFromDatabase.Location = new System.Drawing.Point(23, 80);
            this.btnQueryFromDatabase.Name = "btnQueryFromDatabase";
            this.btnQueryFromDatabase.Size = new System.Drawing.Size(75, 23);
            this.btnQueryFromDatabase.TabIndex = 8;
            this.btnQueryFromDatabase.Text = "从数据库查询";
            this.btnQueryFromDatabase.UseVisualStyleBackColor = true;
            this.btnQueryFromDatabase.Click += new System.EventHandler(this.btnQueryFromDatabase_Click);
            // 
            // FormSetTimePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 115);
            this.Controls.Add(this.btnQueryFromDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnEndByNow);
            this.Controls.Add(this.btnStartFromNow);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.MaximizeBox = false;
            this.Name = "FormSetTimePeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取数时间段";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.Button btnStartFromNow;
        private System.Windows.Forms.Button btnEndByNow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        public System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Button btnQueryFromDatabase;
    }
}