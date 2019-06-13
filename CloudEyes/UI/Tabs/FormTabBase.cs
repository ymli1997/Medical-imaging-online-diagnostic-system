using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rising.Utilities;

namespace CloudEyes.UI.Tabs
{
    #region 委托
    public delegate void ProgressDelegate(int incrementValue);
    #endregion

    public class FormTabBase : Form
    {
        /// <summary>
        /// Tab标签类型
        /// </summary>
        public TabTypes TabType = TabTypes.Others;

        #region 窗体初始化等
        /// <summary>
        /// 窗体已经加载完毕
        /// </summary>
        public bool FormLoaded = false;

        /// <summary>
        /// 是否忙碌状态
        /// </summary>
        public bool Busyness = false;

        /// <summary>
        /// 数据发生过变化
        /// </summary>
        public bool Changed = false;

        public FormTabBase()
        {
            if (!this.DesignMode)
            {
                // 必须放在初始化组件之前
                // this.GetIcon(); 
            }
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormTabBase
            // 
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.KeyPreview = true;
            this.Name = "FormTabBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);

        }


        public virtual void Form_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态
                this.Cursor = Cursors.WaitCursor;
                this.FormLoaded = false;
                try
                {
                    if (!this.DesignMode)
                    {
                        // 是否记录访问日志                       
                    }

                    // 加载窗体
                    this.FormOnLoad();
                    // 设置按钮状态
                    this.SetControlState();

                    // 设置帮助
                    this.SetHelp();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    this.FormLoaded = true;
                    // 设置鼠标默认状态
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void FormOnClosed()
        {
            if (!this.DesignMode)
            {
                // 退出前工作，比如日志等

            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.DesignMode)
            {
                // 设置鼠标繁忙状态
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.FormOnClosed();
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        public virtual void FormOnLoad()
        {
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public virtual void PrintPreview()
        {

        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual void Print()
        {

        }


        /// <summary>
        /// 复制
        /// </summary>
        public virtual Object Copy()
        {
            return null;
        }
        /// <summary>
        /// 帮助主题
        /// </summary>
        public virtual void Help()
        {
        }

        public virtual void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 按键事件
            if (e.KeyCode == Keys.F5)
            {
                // F5刷新，重新加载窗体
                this.FormOnLoad();
            }
            else
            {
                // 按了回车按钮处理光标焦点
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    if ((this.ActiveControl is TextBox) || (this.ActiveControl is ComboBox) || (this.ActiveControl is CheckBox))
                    {
                        if ((this.ActiveControl is TextBox) && ((TextBox)this.ActiveControl).Multiline)
                        {
                            return;
                        }
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }

        /// <summary>
        /// 设置帮助
        /// </summary>
        public virtual void SetHelp()
        {
        }

        /// <summary>
        /// 设置控件状态
        /// </summary>
        public virtual void SetControlState()
        {
        }


        public void WriteException(Exception ex)
        {
            // 在本地记录异常
            FileUtil.WriteException(ex);
        }

        /// <summary>
        /// 处理异常信息
        /// </summary>
        /// <param name="exception">异常</param>
        public void ProcessException(Exception ex)
        {
            this.WriteException(ex);
            //// 显示异常页面
            //FrmException frmException = new FrmException(ex);
            //frmException.ShowDialog();
        }

        #endregion
        #region 主窗口数据刷新操作部分
        public virtual void DataRefresh()
        {
            
        }
        #endregion
        public virtual void InitLeftTabProperty(ref Object obj)
        {

        }
        public virtual void UpdateLeftTabProperty(string type, Object obj)
        {

        }
        public virtual object GetLeftTabProperty()
        {
            return null;
        }
        #region 主窗口Tab操作部分
     

        public virtual void Refresh()
        {
            this.FormOnLoad();
        }
        #endregion

        #region 委托
        /// <summary>
        /// 刷新进度条
        /// </summary>
        private ProgressDelegate _ProgressDelegate;
        /// <summary>
        /// 注册进度委托
        /// </summary>
        /// <param name="progressDelegate"></param>
        public void RegisterProgressDelegate(ProgressDelegate progressDelegate)
        {
            if (_ProgressDelegate == null)
            {
                _ProgressDelegate = progressDelegate;
            }
            else
            {
                _ProgressDelegate += progressDelegate;
            }
        }
        public void UnregisterProgressDelegate(ProgressDelegate progressDelegate)
        {
            _ProgressDelegate -= progressDelegate;
        }


        /// <summary>
        /// 进度条设置，默认进度 10
        /// </summary>
        /// <param name="incrementValue"></param>
        private void ProgressBarIncrement(int incrementValue = 10)
        {
            _ProgressDelegate(10);
        }

        #endregion


    }
}
