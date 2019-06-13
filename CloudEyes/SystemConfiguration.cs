using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Rising.Utilities;
using Rising.Utilities.Utilities;

namespace CloudEyes
{
    public class SystemConfiguration
    {
        /// <summary>
        /// 主程序界面实例
        /// </summary>
        public static CloudEyes.FormMain FormMain = null;
        public static CloudEyes.Entity.UserInfo LoginUser = null;
        public static CloudEyes.Entity.Reports report = null;
        //public static string ServerfileStoreDir = "C:\\CloudEyes\\CloudEyesServices\\MedicalImages\\";
        public static string ServerfileStoreDir = "C:\\CloudEyes\\CloudEyesServices\\MedicalImages\\";


        //数据
        public static Random RandomQueueID = new Random();

        public class UIFormName
        {             
            public static string FormReportQuery = "CloudEyes.UI.Tabs.FormReportQuery";
            public static string FormConsultation = "CloudEyes.UI.Tabs.FormConsultation";
        }
        static SystemConfiguration()
        {
            InitializeConfig();
        }
        public static void InitializeConfig()
        {
            try
            {
                //DbConnectionString = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                //TODO 
                //ServerfileStoreDir = ConfigurationManager.ConnectionStrings["ServerfileStoreDir"].ConnectionString;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            //TODO：为什么调试的时候保存不上？为什么注释掉的部分不起作用？
            //AppConfigHelper.UpdateAppConfig("StringFormat", StringFormat);
            //ConfigurationManager.AppSettings.Set("StringFormat", StringFormat);
        }



        #region 数据库连接相关配置

        /// <summary>
        /// 是否加数据库连接
        /// </summary>
        public static bool EncryptDbConnection = false;
        

        /// <summary>
        /// 数据库类别
        /// </summary>
        public static DataBaseType DbType = DataBaseType.SqlServer;
        

        /// <summary>
        /// 数据库连接字符串（连接串，可能是加密的）
        /// </summary>
        public static string DbConnectionString = string.Empty;

        #endregion

        #region 系统性的参数配置

        /// <summary>
        /// 软件是否需要注册
        /// </summary>
        public static bool NeedRegister = true;

        /// <summary>
        /// 检查周期5分钟内不在线的，就认为是已经没在线了，生命周期检查
        /// </summary>
        //public static int OnLineTime0ut = 5 * 60 + 20;
        //TODO  测试用
        public static int OnLineTime0ut = 20;

        /// <summary>
        /// 每过1分钟，检查一次在线状态
        /// </summary>
        public static int OnLineCheck = 60;

        /// <summary>
        /// 注册码
        /// </summary>
        public static string RegisterKey = string.Empty;
        

        /// <summary>
        /// 是否区分大小写
        /// </summary>
        public static bool MatchCase = true;

        /// <summary>
        /// 最多获取数据的行数限制
        /// </summary>
        public static int TopLimit = 200;

        /// <summary>
        /// 锁不住记录时的循环次数
        /// </summary>
        public static int LockNoWaitCount = 5;

        /// <summary>
        /// 锁不住记录时的等待时间
        /// </summary>
        public static int LockNoWaitTickMilliSeconds = 30;

        /// <summary>
        /// 是否采用服务器端缓存
        /// </summary>
        public static bool ServerCache = false;

        /// <summary>
        /// 最后更新日期
        /// </summary>
        public static string LastUpdate = "2018.01.11";

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string Version = "0.1";

        /// <summary>
        /// 每个操作是否进行信息提示。
        /// </summary>
        public static bool ShowInformation = true;

        /// <summary>
        /// 时间格式
        /// </summary>
        public static string TimeFormat = "HH:mm:ss";

        /// <summary>
        /// 日期短格式
        /// </summary>
        public static string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 日期长格式
        /// </summary>
        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 当前软件Id
        /// </summary>
        public static string SoftName = string.Empty;

        /// <summary>
        /// 软件的名称
        /// </summary>
        public static string SoftFullName = string.Empty;

        /// <summary>
        /// 根菜单编号
        /// </summary>
        public static string RootMenuCode = string.Empty;

        /// <summary>
        /// 是否采用客户端缓存
        /// </summary>
        public static bool ClientCache = false;

        /// <summary>
        /// 当前客户公司名称
        /// </summary>
        public static string CustomerCompanyName = string.Empty;

        /// <summary>
        /// 系统图标文件
        /// </summary>
        public static string AppIco = "Resource\\Form.ico";

        /// <summary>
        /// RegistryKey、Configuration、UserConfig 注册表或者配置文件读取参数
        /// </summary>
        public static ConfigurationCategory ConfigurationFrom = ConfigurationCategory.Configuration;

        public static string RegisterException = "请您联系： 河南省郑州市 吴亚平 手机：13103850422 电子邮件：ZhengzhouRising@126.com 对软件进行注册。";

        public static string CustomerPhone = "0371-67783046";			    // 当前客户公司电话
        public static string CompanyName = "郑州锐升软件技术有限公司";	// 公司名称
        public static string CompanyPhone = "13103850422";			    // 公司电话

        public static string Copyright = "Copyright 2010-2013 Rising TECH";
        public static string BugFeedback = @"mailto:ZhengzhouRising@126.com?subject=对智慧云眼的反馈&body=这里输入您宝贵的反馈";
        public static string IEDownloadUrl = @"http://download.microsoft.com/download/ie6sp1/finrel/6_sp1/W98NT42KMeXP/CN/ie6setup.exe";

        public static string HelpNamespace = string.Empty;
        public static string UploadDirectory = "Document/";
        #endregion

        #region 系统邮件错误报告反馈相关

        /// <summary>
        /// 发送给谁，用,;符号隔开
        /// </summary>
        public static string ErrorReportTo = "ZhengzhouRising@126.com";

        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public static string ErrorReportMailServer = "";

        /// <summary>
        /// 用户名
        /// </summary>
        public static string ErrorReportMailUserName = "";

        /// <summary>
        /// 密码
        /// </summary>
        public static string ErrorReportMailPassword = "";

        #endregion
    }
}
