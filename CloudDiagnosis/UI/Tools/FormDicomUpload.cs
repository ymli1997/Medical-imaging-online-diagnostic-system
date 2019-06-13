/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-27
 * Time: 17:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CloudDiagnosis;
using CloudDiagnosis.UI.Tabs;
using DevComponents.DotNetBar;

namespace CloudDiagnosis.UI.Tools
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormDicomUpload : FormTabBase
    {

        public FormDicomUpload()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }
        

        private void toolbarItemPredictionAlgorithm_Click(object sender, EventArgs e)
        {
            ////默认智能选中一种算法
            //toolbarItemDDGM11.Checked = false;
            //toolbarItemDGM0N.Checked = false;
            //toolbarItemDGM11.Checked = false;
            //toolbarItemDGM21.Checked = false;
            //toolbarItemGM11.Checked = false;
            //toolbarItemGM1N.Checked = false;
            //toolbarItemVerhulst.Checked = false;
            //设置选中选项
            ButtonItem itemClicked = sender as ButtonItem;
            itemClicked.Checked = !itemClicked.Checked;
        }

        private void toolbarItemQueryData_Click(object sender, EventArgs e)
        {
        }

        private void Predict(string dataPropertyName)
        {
        }

        private void toolbarItemPrediction_Click(object sender, EventArgs e)
        {

            MessageBox.Show("预测数据计算完成！");
        }

        private void toolbarItemPrediction2DB_Click(object sender, EventArgs e)
        {

        }
        
        
        private void toolbarItemDataPreprocessing_Click(object sender, EventArgs e)
        {
        }

        private void FormDicomUpload_Load(object sender, EventArgs e)
        {

        }
    }
}
