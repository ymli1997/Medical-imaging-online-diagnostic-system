using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace CloudDiagnosis.Entity
{
    public class Consultation
    {
        private decimal _ID;

        private decimal _Report_ID;

        private decimal _SenderID;

        private decimal _ReceiverID;

        private string _Content;

        private string _SendTime;

        private string _IsReaded;

        private string _ReadTime;
        private string _images;


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
        public string images
        {
            get
            {
                return _images;
            }

            set
            {
                _images = value;
            }
        }

        public bool SendMessage(decimal recevier_id, string jsonData)
        {
            //content = "'我爱你'";
            //string sql = "insert into Consultation (Report_ID,[Content])values(" + report_Id + "," + content + ")";
            //int res = SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@Report_ID", report_Id),new SqlParameter("@[Content]",content));
            //if (res != 0)
            //    return true;
            //else
                return true;           
        }

        public string GetMessage(decimal sender_id)
        {
            List<Consultation> list = new List<Consultation>();
            string sql = "select * from Consultation where HospitalName=@HospitalName";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@HospitalName", sender_id)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Consultation cs = new Consultation();
                        //cs.SendTime = Convert.ToInt32(sdr["Report_ID"]);
                        cs.Content = sdr["Content"].ToString();
                        //cs.HospitalName = sdr["HospitalName"].ToString();
                        ////hpf.DoctorId = Convert.ToInt32(sdr["Doctor_ID"]);
                        ////hpf.DoctorName = sdr["DoctorName"].ToString();
                        list.Add(cs);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }
    }
}