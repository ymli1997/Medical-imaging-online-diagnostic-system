﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Rising TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rising.Utilities
{
    /// <summary>
    /// ResourceManagerWrapper
    /// 资源管理器
    /// 
    ///	修改纪录
    ///		2007.05.16 版本：1.0 JiRiGaLa	重新调整主键的规范化。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.16</date>
    /// </author> 
    /// </summary>
    public class ResourceManagerWrapper
    {
        private volatile static ResourceManagerWrapper instance = null;
        private static object locker = new Object();

        public static ResourceManagerWrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ResourceManagerWrapper();
                        }
                    }
                }
                return instance;
            }
        }

        private ResourceManager resourceManager;

        public ResourceManagerWrapper()
        {
        }

        public void LoadResources(string path)
        {
            resourceManager = ResourceManager.Instance;
            resourceManager.Init(path);
        }

        public string Get(string key)
        {
            if (resourceManager == null)
            {
                return string.Empty;
            }
            return resourceManager.Get(BaseSystemInfo.CurrentLanguage, key);
        }

        public string Get(string language, string key)
        {
            return resourceManager.Get(language, key);
        }
        
        public Hashtable GetLanguages()
        {
            if (resourceManager == null)
            {
                return null;
            }
            return resourceManager.GetLanguages();
        }

        public Hashtable GetLanguages(string path)
        {
            return resourceManager.GetLanguages(path);
        }

        public void Serialize(string path, string language, string key, string value)
        {
            Resources resources = this.GetResources(path, language);
            resources.Set(key, value);
            string filePath = path + "\\" + language + ".xml";
            resourceManager.Serialize(resources, filePath);
        }

        public Resources GetResources(string path, string language)
        {
            string filePath = path + "\\" + language + ".xml";
            return resourceManager.GetResources(filePath);
        }

        public Resources GetResources(string language)
        {
            return resourceManager.languageResources[language];
        }
    }
}