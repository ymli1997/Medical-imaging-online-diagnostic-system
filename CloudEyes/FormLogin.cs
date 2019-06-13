using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using CloudEyes.Entity;

namespace CloudEyes
{
    public partial class FormLogin : Form
    {

        //ServiceReference1.CloudEyesSoapClient SR = null;
        private void FormLogin_Load(object sender, EventArgs e)
        {
            //SR = new ServiceReference1.CloudEyesSoapClient("CloudEyesSoap");
        }


        /// <summary>
        /// 用户列表
        /// </summary>
        private DataTable DTUser = new DataTable("sys_users");

        /// <summary>
        /// 允许错误登录次数
        /// </summary>
        private int AllowLogOnCount = 3;

        /// <summary>
        /// 已登录次数
        /// </summary>
        private int LogOnCount = 0;

        public FormLogin()
        {
            InitializeComponent();
        }




        #region private bool CheckAllowLogOnCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        /// <returns>继续允许输入</returns>
        private bool CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                // 控件重新设置状态
                this.textBoxPassword.Text = string.Empty;
                this.textBoxUser.Enabled = false;
                this.textBoxPassword.Enabled = false;
                this.buttonConfirm.Enabled = false;

                // 进行提示信息，不能再输入了，已经错误N次了。
                MessageBox.Show("密码错误次数过多，不允许再次输入！");
                return false;

            }
            return true;
        }
        #endregion

        public bool CheckInput()
        {
            // 是否没有输入用户名
            if (this.textBoxUser.Text.Length == 0)
            {
                MessageBox.Show("请输入用户名");
                this.textBoxUser.Focus();
                return false;
            }
            if (this.textBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("请输入密码");
                this.textBoxPassword.Focus();
                return false;
            }
            this.buttonConfirm.Focus();
            return true;
        }
        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 已经登录次数 ++
            this.LogOnCount++;
            try
            {
                string userName = this.textBoxUser.Text;
                string password = this.textBoxPassword.Text;

                ClientCloudEyesServer.CloudEyesSoapClient serviceClient = new ClientCloudEyesServer.CloudEyesSoapClient("CloudEyesSoap");
                
                string jsonResult = serviceClient.Login(userName, password);

                //把集合放入json中
                //反序列化对象  
                
                JavaScriptSerializer js = new JavaScriptSerializer();             
                UserInfo userInfo = js.Deserialize<UserInfo>(jsonResult);
                //User_ID
                // check Logon
                 Boolean isLogSuccess = false;

                if (userInfo != null)
                {
                    isLogSuccess = true;
                }


                if (isLogSuccess == true)
                {
                    this.buttonConfirm.Enabled = false;
                    SystemConfiguration.LoginUser = userInfo;
                    // 这里是登录功能部分
                    if (this.Parent == null)
                    {
                        this.DialogResult = DialogResult.OK;
                        //this.Hide();
                        //Form mainForm = this.Owner;
                        //mainForm.Show();
                        //mainForm.Refresh();
                    }
                    // 登录次数归零，允许重新登录
                    this.LogOnCount = 0;
                }
                else
                {
                    MessageBox.Show("密码输入不正确，请注意大小写！");
                    this.textBoxPassword.Focus();
                    this.textBoxPassword.SelectAll();
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                // 已经忙完了
                this.Cursor = holdCursor;
            }
            return true;
        }
        #endregion

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 用户登录
                this.LogOn();
                // 允许登录次数已经到了
                this.CheckAllowLogOnCount();
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// 检查输入的有效性
            //if (this.CheckInput())
            //{
            //    if (e.KeyChar == 13)
            //    {
            //        // 用户登录
            //        this.LogOn();
            //    }
            //}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblUser_Click(object sender, EventArgs e)
        {
            this.textBoxUser.Text = "1774573926";
            this.textBoxPassword.Text = "666666";
        }

      
    }
}
