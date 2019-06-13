using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudEyes.UI.Configuration
{
    public partial class FormSystemSetting : Form
    {
        public FormSystemSetting()
        {
            InitializeComponent();
        }

        private void FormSystemSetting_Load(object sender, EventArgs e)
        {
            textBoxIPV6Address.Text = "2001:da8:270:2021::f";
            textBoxPort.Text = "8080";
            //textBoxIPV6Address.Text = CloudEyesSettings.Default.str1;
            //textBoxPort.Text = CloudEyesSettings.Default.str2;
            //checkBoxIsSaveToConfiguration.Checked = CloudEyesSettings.Default.b;
        }

        private void FormSystemSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloudEyesSettings.Default.str1 = textBoxIPV6Address.Text;
            //CloudEyesSettings.Default.str2 = textBoxPort.Text;
            //CloudEyesSettings.Default.Save();
        }
        /// <summary>
        /// 保存配置设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            //CloudEyesSettings.Default.str1 = textBoxIPV6Address.Text;
            //CloudEyesSettings.Default.str2 = textBoxPort.Text;
            //CloudEyesSettings.Default.Save();
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
