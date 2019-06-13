//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Globalization;

namespace Rising.Utilities
{
    /// <summary>
    /// BaseConfiguration
    /// 连接配置。
    /// 
    /// 修改纪录
    /// 
    ///		2015.02.08 版本：1.0 JiRiGaLa 从配置文件读取数据库连接。
    /// 
    /// 版本：3.8
    /// 
    /// <author>
    ///		<name>吴亚平</name>
    ///		<date>2015.02.08</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
        #region public BaseConfiguration()
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseConfiguration()
        {
        }
        #endregion

        #region public BaseConfiguration(string softName)
        /// <summary>
        /// 设定当前软件Id
        /// </summary>
        /// <param name="softName">当前软件Id</param>
        public BaseConfiguration(string softName)
        {
            BaseSystemInfo.SoftName = softName;
        }
        #endregion

        #region public static DataBaseType GetDataBaseType(string dataBaseType)
        /// <summary>
        /// 数据库连接的类型判断
        /// </summary>
        /// <param name="dataBaseType">数据库类型</param>
        /// <returns>数据库类型</returns>
        public static DataBaseType GetDataBaseType(string dataBaseType)
        {
            DataBaseType returnValue = DataBaseType.SqlServer;
            foreach (DataBaseType dbType in Enum.GetValues(typeof(DataBaseType)))
            {
                if (dbType.ToString().Equals(dataBaseType))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static ConfigurationCategory GetConfiguration(string configuration)
        /// <summary>
        /// 配置信息的类型判断
        /// </summary>
        /// <param name="configuration">配置信息类型</param>
        /// <returns>配置信息类型</returns>
        public static ConfigurationCategory GetConfiguration(string configuration)
        {
            ConfigurationCategory returnValue = ConfigurationCategory.Configuration;
            foreach (ConfigurationCategory configurationCategory in Enum.GetValues(typeof(ConfigurationCategory)))
            {
                if (configurationCategory.ToString().Equals(configuration))
                {
                    returnValue = configurationCategory;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetSetting()
        /// <summary>
        /// 读取配置信息
        /// </summary>
        public static void GetSetting()
        {
            // 读取注册表
            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.RegistryKey)
            {
                RegistryHelper.GetConfig();
            }
            // 读取配置文件
            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.Configuration)
            {
                ConfigurationHelper.GetConfig();
            }
            // 读取个性化配置文件
            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.UserConfig)
            {
                UserConfigHelper.GetConfig();
            }
        }
        #endregion
    }
}