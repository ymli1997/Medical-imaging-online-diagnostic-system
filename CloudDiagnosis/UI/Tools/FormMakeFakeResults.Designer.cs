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
    partial class FormMakeFakeResults
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
            this.comboBoxPoints = new System.Windows.Forms.ComboBox();
            this.btnExport2Excel = new System.Windows.Forms.Button();
            this.btnImportFromExcel = new System.Windows.Forms.Button();
            this.btnFakeDailyResults = new System.Windows.Forms.Button();
            this.btnSaveData2DB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Location = new System.Drawing.Point(13, 49);
            this.dataGridViewMain.Margin = new System.Windows.Forms.Padding(10, 40, 10, 35);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(964, 503);
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
            this.btnQueryNodeData.Location = new System.Drawing.Point(201, 12);
            this.btnQueryNodeData.Name = "btnQueryNodeData";
            this.btnQueryNodeData.Size = new System.Drawing.Size(136, 23);
            this.btnQueryNodeData.TabIndex = 3;
            this.btnQueryNodeData.Text = "查询日平均数据";
            this.btnQueryNodeData.UseVisualStyleBackColor = true;
            this.btnQueryNodeData.Click += new System.EventHandler(this.BtnQueryNodeDataClick);
            // 
            // comboBoxPoints
            // 
            this.comboBoxPoints.FormattingEnabled = true;
            this.comboBoxPoints.Location = new System.Drawing.Point(70, 14);
            this.comboBoxPoints.Name = "comboBoxPoints";
            this.comboBoxPoints.Size = new System.Drawing.Size(125, 20);
            this.comboBoxPoints.TabIndex = 15;
            // 
            // btnExport2Excel
            // 
            this.btnExport2Excel.Location = new System.Drawing.Point(343, 12);
            this.btnExport2Excel.Name = "btnExport2Excel";
            this.btnExport2Excel.Size = new System.Drawing.Size(136, 23);
            this.btnExport2Excel.TabIndex = 16;
            this.btnExport2Excel.Text = "导出到Excel";
            this.btnExport2Excel.UseVisualStyleBackColor = true;
            this.btnExport2Excel.Click += new System.EventHandler(this.btnExport2Excel_Click);
            // 
            // btnImportFromExcel
            // 
            this.btnImportFromExcel.Location = new System.Drawing.Point(485, 12);
            this.btnImportFromExcel.Name = "btnImportFromExcel";
            this.btnImportFromExcel.Size = new System.Drawing.Size(136, 23);
            this.btnImportFromExcel.TabIndex = 17;
            this.btnImportFromExcel.Text = "从Excel导入";
            this.btnImportFromExcel.UseVisualStyleBackColor = true;
            this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
            // 
            // btnFakeDailyResults
            // 
            this.btnFakeDailyResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFakeDailyResults.Location = new System.Drawing.Point(13, 561);
            this.btnFakeDailyResults.Name = "btnFakeDailyResults";
            this.btnFakeDailyResults.Size = new System.Drawing.Size(136, 23);
            this.btnFakeDailyResults.TabIndex = 18;
            this.btnFakeDailyResults.Text = "生成明细数据";
            this.btnFakeDailyResults.UseVisualStyleBackColor = true;
            this.btnFakeDailyResults.Click += new System.EventHandler(this.btnFakeDailyResults_Click);
            // 
            // btnSaveData2DB
            // 
            this.btnSaveData2DB.Location = new System.Drawing.Point(627, 12);
            this.btnSaveData2DB.Name = "btnSaveData2DB";
            this.btnSaveData2DB.Size = new System.Drawing.Size(136, 23);
            this.btnSaveData2DB.TabIndex = 19;
            this.btnSaveData2DB.Text = "日平均数据入库";
            this.btnSaveData2DB.UseVisualStyleBackColor = true;
            this.btnSaveData2DB.Click += new System.EventHandler(this.btnSaveData2DB_Click);
            // 
            // FormMakeFakeResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 596);
            this.Controls.Add(this.btnSaveData2DB);
            this.Controls.Add(this.btnFakeDailyResults);
            this.Controls.Add(this.btnImportFromExcel);
            this.Controls.Add(this.btnExport2Excel);
            this.Controls.Add(this.comboBoxPoints);
            this.Controls.Add(this.btnQueryNodeData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMain);
            this.Name = "FormMakeFakeResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成测试数据";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnQueryNodeData;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.ComboBox comboBoxPoints;
        private System.Windows.Forms.Button btnExport2Excel;
        private System.Windows.Forms.Button btnImportFromExcel;
        private System.Windows.Forms.Button btnFakeDailyResults;
        private System.Windows.Forms.Button btnSaveData2DB;
	}
}
