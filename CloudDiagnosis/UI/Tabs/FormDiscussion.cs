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

namespace CloudDiagnosis.UI.Tabs
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class FormDiscussion : FormTabBase
    {

        public FormDiscussion()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }
        

        private void toolbarItemPredictionAlgorithm_Click(object sender, EventArgs e)
        {

        }

        private void Predict(string dataPropertyName)
        {
        }

        private void toolbarItemPrediction_Click(object sender, EventArgs e)
        {

            MessageBox.Show("预测数据计算完成！");
        }
        

    }
}
