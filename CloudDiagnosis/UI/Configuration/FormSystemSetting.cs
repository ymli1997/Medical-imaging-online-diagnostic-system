using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudDiagnosis.UI.Configuration
{
    public partial class FormSystemSetting : Form
    {
        public FormSystemSetting()
        {
            InitializeComponent();
        }

        private void FormSystemSetting_Load(object sender, EventArgs e)
        {
            textBoxIPV6Address.Text = "2001:250:4800:ef:a4fe:bc62:9bc2:8f6b";
            textBoxPort.Text = "3003";
            //textBoxIPV6Address.Text = CloudEyesSettings.Default.str1;
            //textBoxPort.Text = CloudEyesSettings.Default.str2;
            //checkBoxIsSaveToConfiguration.Checked = CloudEyesSettings.Default.b;
        }

        private void FormSystemSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloudDiagnosisSettings.Default.str1 = textBoxIPV6Address.Text;
            CloudDiagnosisSettings.Default.str2 = textBoxPort.Text;
            CloudDiagnosisSettings.Default.Save();
        }
        
        
        /// <summary>
        /// 保存配置设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            CloudDiagnosisSettings.Default.str1 = textBoxIPV6Address.Text;
            CloudDiagnosisSettings.Default.str2 = textBoxPort.Text;
            CloudDiagnosisSettings.Default.Save();
            MessageBox.Show("配置修改成功");
            this.Close();
        }
        /// <summary>
        /// 取消配置设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
