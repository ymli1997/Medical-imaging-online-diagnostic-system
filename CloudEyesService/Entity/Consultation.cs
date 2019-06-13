using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CloudEyesService.Entity
{
    public abstract class Consultation
    {
        private decimal _ID;

        private decimal _Report_ID;

        private decimal _SenderID;

        private decimal _ReceiverID;

        private string _Content;

        private string _SendTime;

        private string _IsReaded;

        private string _ReadTime;

        private string _Images;

        /// <summary>
        /// 主键
        /// </summary>
        /// 
        public decimal ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
        /// <summary>
        /// 报告ID
        /// </summary>
        public decimal Report_ID
        {
            get
            {
                return _Report_ID;
            }

            set
            {
                _Report_ID = value;
            }
        }
        /// <summary>
        /// 发送者ID
        /// </summary>
        public decimal SenderID
        {
            get
            {
                return _SenderID;
            }

            set
            {
                _SenderID = value;
            }
        }
        /// <summary>
        /// 接收者ID
        /// </summary>
        public decimal ReceiverID
        {
            get
            {
                return _ReceiverID;
            }

            set
            {
                _ReceiverID = value;
            }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string Content
        {
            get
            {
                return _Content;
            }

            set
            {
                _Content = value;
            }
        }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendTime
        {
            get
            {
                return _SendTime;
            }

            set
            {
                _SendTime = value;
            }
        }
        /// <summary>
        /// 阅读状态
        /// </summary>
        public string IsReaded
        {
            get
            {
                return _IsReaded;
            }

            set
            {
                _IsReaded = value;
            }
        }
        /// <summary>
        /// 阅读时间
        /// </summary>
        public string ReadTime
        {
            get
            {
                return _ReadTime;
            }

            set
            {
                _ReadTime = value;
            }
        }

        public string Images
        {
            get
            {
                return _Images;
            }

            set
            {
                _Images = value;
            }
        }

        public abstract bool SendMessage(string jsonData);

        public abstract string GetMessage(decimal sender_id, decimal receiver_id);

        public abstract string GetOneMessage(decimal sender_id, decimal receiver_id);
    }
}