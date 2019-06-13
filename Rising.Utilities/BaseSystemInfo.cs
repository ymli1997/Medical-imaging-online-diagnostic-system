//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace Rising.Utilities
{
    /// <summary>
    /// BaseSystemInfo
    /// 系统全局配置信息
    /// 
    /// 修改记录
    ///
    ///		2015.02.08 版本：1.0 吴亚平	创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>吴亚平</name>
    ///		<date>2015.02.08</date>
    /// </author>
    /// </summary>
    public class BaseSystemInfo
    {
        #region 客户端的配置信息部分
        
        /// <summary>
        /// 当前用户名
        /// </summary>
        public static string CurrentUserName = string.Empty;

        /// <summary>
        /// 当前密码
        /// </summary>
        public static string CurrentPassword = string.Empty;

        /// <summary>
        /// 登录是否保存密码，默认能记住密码会好用一些
        /// </summary>
        public static bool RememberPassword = true;

        /// <summary>
        /// 是否自动登录，默认不自动登录会好一些
        /// </summary>
        public static bool AutoLogOn = false;

        /// <summary>
        /// 客户端加密存储密码，这个应该是要加密才可以
        /// </summary>
        public static bool ClientEncryptPassword = true;
                        
        /// <summary>
        /// 是否采用多语言
        /// </summary>
        public static bool MultiLanguage = false;

        /// <summary>
        /// 当前客户选择的语言
        /// </summary>
        public static string CurrentLanguage = "zh-CN";

        /// <summary>
        /// 当前语言
        /// </summary>
        public static string Themes = string.Empty;

        private int lockWaitMinute = 60;

        /// <summary>
        /// 锁定等待时间分钟
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        }

        /// <summary>
        /// 主页地址
        /// </summary>
        public static string WebHostUrl = "WebHostUrl";

        #endregion
        
        #region 服务器端的配置信息

        /// <summary>
        /// 检查密码强度，默认要检查比较好，系统安全性高一些
        /// </summary>
        public static bool CheckPasswordStrength = true;

        /// <summary>
        /// 允许新用户注册
        /// </summary>
        public static bool AllowUserRegister = true;

        /// <summary>
        /// 是否启用即时内部消息
        /// </summary>
        public static bool UseMessage = false;

        /// <summary>
        /// 是否启用拼音检索
        /// </summary>
        public static bool UsePinyinFilter = true;

        /// <summary>
        /// 是否启用表格数据权限
        /// 启用分级管理范围权限设置，启用逐级授权
        /// </summary>
        public static bool UsePermissionScope = false;

        /// <summary>
        /// 启用按用户权限
        /// </summary>
        public static bool UseUserPermission = true;

        /// <summary>
        /// 启用模块菜单权限
        /// </summary>
        public static bool UseModulePermission = false;

        /// <summary>
        /// 启用操作权限
        /// </summary>
        public static bool UsePermissionItem = false;

        /// <summary>
        /// 启用数据表的约束条件限制
        /// </summary>
        public static bool UseTableScopePermission = false;

        /// <summary>
        /// 启用数据表的列权限
        /// </summary>
        public static bool UseTableColumnPermission = false;

        /// <summary>
        /// 设置手写签名
        /// </summary>
        public static bool HandwrittenSignature = true;

        /// <summary>
        /// 服务器端加密存储密码
        /// </summary>
        public static bool ServerEncryptPassword = true;

        /// <summary>
        /// 登录历史纪录
        /// </summary>
        public static bool RecordLogOnLog = true;

        /// <summary>
        /// 是否进行日志记录
        /// </summary>
        public static bool RecordLog = true;

        /// <summary>
        /// 是否更新访问日期信息
        /// </summary>
        public static bool UpdateVisit = true;

        /// <summary>
        /// 只允许登录一次
        /// </summary>
        public static bool CheckOnLine = false;

        /// <summary>
        /// 同时在线用户数量限制
        /// </summary>
        public static int OnLineLimit = 0;

        /// <summary>
        /// 是否检查用户IP地址
        /// </summary>
        public static bool CheckIPAddress = true;        

        /// <summary>
        /// 是否登记异常
        /// </summary>
        public static bool LogException = true;

        /// <summary>
        /// 是否登记数据库操作
        /// </summary>
        public static bool LogSQL = false;

        /// <summary>
        /// 是否登记到 Windows 系统异常中
        /// </summary>
        public static bool EventLog = false;

        #endregion
        
        #region 数据库连接相关配置

        /// <summary>
        /// 业务数据库类别
        /// </summary>
        public static DataBaseType BusinessDbType = DataBaseType.SqlServer;

        /// <summary>
        /// 用户数据库类别
        /// </summary>
        public static DataBaseType UserCenterDbType = DataBaseType.SqlServer;

        /// <summary>
        /// 工作流数据库类别
        /// </summary>
        public static DataBaseType WorkFlowDbType = DataBaseType.SqlServer;

        /// <summary>
        /// 是否加数据库连接
        /// </summary>
        public static bool EncryptDbConnection = false;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string UserCenterDbConnection = string.Empty;

        /// <summary>
        /// 数据库连接的字符串
        /// </summary>
        public static string UserCenterDbConnectionString = string.Empty;

        /// <summary>
        /// 业务数据库
        /// </summary>
        public static string BusinessDbConnection = string.Empty;

        /// <summary>
        /// 业务数据库（连接串，可能是加密的）
        /// </summary>
        public static string BusinessDbConnectionString = string.Empty;

        /// <summary>
        /// 工作流数据库
        /// </summary>
        public static string WorkFlowDbConnection = string.Empty;

        /// <summary>
        /// 工作流数据库（连接串，可能是加密的）
        /// </summary>
        public static string WorkFlowDbConnectionString = string.Empty;

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
        public static int OnLineTime0ut = 20 ;

        /// <summary>
        /// 每过1分钟，检查一次在线状态
        /// </summary>
        public static int OnLineCheck = 60;

        /// <summary>
        /// 注册码
        /// </summary>
        public static string RegisterKey = string.Empty;

        /// <summary>
        /// 当前网站的安装地址
        /// </summary>
        public static string StartupPath = string.Empty;

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
        public static string LastUpdate = "2013.10.11";

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string Version = "3.7";

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

        public static string RegisterException = "请您联系： 河南省郑州市 吴亚平 手机：18537182396 电子邮件：ZhengzhouRising@126.com 对软件进行注册。";

        public static string CustomerPhone = "0371-67783046";			    // 当前客户公司电话
        public static string CompanyName = "郑州锐升软件技术有限公司";	// 公司名称
        public static string CompanyPhone = "18537182396";			    // 公司电话

        public static string Copyright = "Copyright 2010-2013 Rising TECH";
        public static string BugFeedback = @"mailto:ZhengzhouRising@126.com?subject=对物资管理系统的反馈&body=这里输入您宝贵的反馈";
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


        #region 客户端动态加载程序相关
        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;
        public static string MainForm = "MainForm";

        public static string LogOnAssembly = "DotNet.WinForm";
        public static string LogOnForm = "FrmLogOnByName";

        public static string ServiceFactory = "ServiceFactory";
        public static string Service = "DotNet.Business";
        // public static string DbHelperClass = "DotNet.Utilities.SqlHelper";
        public static string DbHelperAssmely = "Rising.Utilities";

        #endregion
    }
}