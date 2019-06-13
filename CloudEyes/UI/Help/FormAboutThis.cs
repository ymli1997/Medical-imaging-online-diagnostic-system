//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2018 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace CloudEyes.UI.Help
{
    /// <summary>
    /// FrmAboutThis
    /// 
    /// 修改纪录
    ///		2018.01.11 版本：0.1 YPWu 创建。
    ///		
    /// 版本：0.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.18</date>
    /// </author> 
    /// </summary>
    public partial class FormAboutThis : Form
    {
        public FormAboutThis()
        {
            InitializeComponent();
            GetSystemInfo();
        }

        #region private void GetSystemInfo() 获取配置信息
        /// <summary>
        /// 获取配置信息
        /// </summary>
        private void GetSystemInfo()
        {
            // this.Text = "About " + BaseSystemInfo.SoftName + " Software";
            this.lblSoftFullName.Text = SystemConfiguration.SoftFullName;
            this.lblVersion.Text = "Edition V" + SystemConfiguration.Version;
            this.lblCopyright.Text = SystemConfiguration.Copyright;
        }
        #endregion

        private void lblLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // 获取导航地址
            LinkLabel llabNavigation = (LinkLabel)sender;
            string targetUrl = llabNavigation.Tag.ToString();
            // 打开浏览器，导航到相应的网址上
            System.Diagnostics.Process.Start(targetUrl); 
        }

        private void FrmAboutThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 关闭此窗口
            this.Close();
        }
    }
}