using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CloudEyes.Entity
{
    public class Reports
    {
        private decimal _User_ID;

        private decimal _Report_ID;

        private string _Overview;

        private string _Content;

        private string _Comment;

        private bool _isAudited;

        private decimal? _AuditUserID;

        private string _AuditUserName;

        private string _AuditTime;

        private string _PatientName;

        private string _PatientID;

        private int _PatientAge;

        private string _PatientSex;

        private string _StudyTime;

        private string _BodyPart;

        private string _StudyDescription;

        private string _InstitutionName;

        private string _RequestTime;

        private string _Modality;

        private string _StudyLocalDirectory;

        private string _StudyLocalDirectorySeg;

        private string _ImageFilePath;

        private string _MaskFilePath;

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

        public string Overview
        {
            get
            {
                return _Overview;
            }

            set
            {
                _Overview = value;
            }
        }
        /// <summary>
        /// 报告内容
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
        /// 报告评价
        /// </summary>
        public string Comment
        {
            get
            {
                return _Comment;
            }

            set
            {
                _Comment = value;
            }
        }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudited
        {
            get
            {
                return _isAudited;
            }

            set
            {
                _isAudited = value;
            }
        }

        /// <summary>
        /// 审核人ID
        /// </summary>
        public decimal? AuditUserID
        {
            get
            {
                return _AuditUserID;
            }

            set
            {
                _AuditUserID = value;
            }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public string AuditTime
        {
            get
            {
                return _AuditTime;
            }

            set
            {
                _AuditTime = value;
            }
        }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            {
                return _PatientName;
            }

            set
            {
                _PatientName = value;
            }
        }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID
        {
            get
            {
                return _PatientID;
            }

            set
            {
                _PatientID = value;
            }
        }

        /// <summary>
        /// 病人年龄
        /// </summary>
        public int PatientAge
        {
            get
            {
                return _PatientAge;
            }

            set
            {
                _PatientAge = value;
            }
        }

        /// <summary>
        /// 病人性别
        /// </summary>
        public string PatientSex
        {
            get
            {
                return _PatientSex;
            }

            set
            {
                _PatientSex = value;
            }
        }

        /// <summary>
        /// 诊断时间
        /// </summary>
        public string StudyTime
        {
            get
            {
                return _StudyTime;
            }

            set
            {
                _StudyTime = value;
            }
        }

        /// <summary>
        /// 身体部位
        /// </summary>
        public string BodyPart
        {
            get
            {
                return _BodyPart;
            }

            set
            {
                _BodyPart = value;
            }
        }

        /// <summary>
        /// 诊断描述
        /// </summary>
        public string StudyDescription
        {
            get
            {
                return _StudyDescription;
            }

            set
            {
                _StudyDescription = value;
            }
        }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string InstitutionName
        {
            get
            {
                return _InstitutionName;
            }

            set
            {
                _InstitutionName = value;
            }
        }

        /// <summary>
        /// 请求时间
        /// </summary>
        public string RequestTime
        {
            get
            {
                return _RequestTime;
            }

            set
            {
                _RequestTime = value;
            }
        }

        /// <summary>
        /// 序列
        /// </summary>
        public string Modality
        {
            get
            {
                return _Modality;
            }

            set
            {
                _Modality = value;
            }
        }

        /// <summary>
        /// 本地诊断目录
        /// </summary>
        public string StudyLocalDirectory
        {
            get
            {
                return _StudyLocalDirectory;
            }

            set
            {
                _StudyLocalDirectory = value;
            }
        }

        public string StudyLocalDirectorySeg
        {
            get
            {
                return _StudyLocalDirectorySeg;
            }

            set
            {
                _StudyLocalDirectorySeg = value;
            }
        }
        /// <summary>
        /// 未标记图片目录
        /// </summary>
        public string ImageFilePath
        {
            get
            {
                return _ImageFilePath;
            }

            set
            {
                _ImageFilePath = value;
            }
        }

        /// <summary>
        /// 标记图片目录
        /// </summary>
        public string MaskFilePath
        {
            get
            {
                return _MaskFilePath;
            }

            set
            {
                _MaskFilePath = value;
            }
        }

        public decimal User_ID
        {
            get
            {
                return _User_ID;
            }

            set
            {
                _User_ID = value;
            }
        }
        public string AuditUserName
        {
            get
            {
                return _AuditUserName;
            }

            set
            {
                _AuditUserName = value;
            }
        }
        public string GetInfo(decimal Report_ID)
        {
            Reports rt = null;
            string sql = "select * from Reports where Report_ID=@Report_ID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@Report_ID", Report_ID)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        rt = new Reports();
                        rt.PatientName = sdr["PatientName"].ToString();
                        rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        rt.PatientSex = sdr["PatientSex"].ToString();
                        rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        rt.Content = sdr["Content"].ToString();
                        rt.Overview = sdr["Overview"].ToString();
                        rt.Comment = sdr["Comment"].ToString();
                    }
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(rt);
        }

        public string GetInfo()
        {
            List<Reports> list = new List<Reports>();
            string sql = "select * from Reports";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Reports rt = new Reports();
                        rt.PatientName = sdr["PatientName"].ToString();
                        rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        rt.PatientSex = sdr["PatientSex"].ToString();
                        rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        rt.Content = sdr["Content"].ToString();
                        rt.Overview = sdr["Overview"].ToString();
                        rt.Comment = sdr["Comment"].ToString();
                        list.Add(rt);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        public string GetReportInfo(decimal report_id)
        {
            List<Reports> list = new List<Reports>();
            string sql = "select * from Reports where Report_ID=@Report_ID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@Report_ID", report_id)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Reports rt = new Reports();
                        rt.PatientName = sdr["PatientName"].ToString();
                        rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        rt.PatientSex = sdr["PatientSex"].ToString();                     
                        rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        //rt.AuditUserName = sdr["AuditUserName"].ToString();
                        rt.Overview = sdr["Overview"].ToString();
                        rt.Comment = sdr["Comment"].ToString();
                        rt.Content = sdr["Content"].ToString();
                        list.Add(rt);
                    }
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(list);
        }

        public bool SubmiteInfo(decimal report_id, string jsonData)
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Reports rt = js.Deserialize<Reports>(jsonData);
            List<SqlParameter> list = new List<SqlParameter>();
            PatientName = "李四";
            PatientAge = 23;
            PatientSex = "女";
            SqlParameter[] ps =
            {
                new SqlParameter("@PatientName",PatientName),
                new SqlParameter("@PatientAge",PatientAge),
                new SqlParameter("@PatientSex",PatientSex),
            };
            list.AddRange(ps);
            string sql = "update Reports set PatientName=@PatientName,PatientAge=@PatientAge,PatientSex=@PatientSex where Report_ID=" + report_id;
            int res = SqlHelper.ExecuteNonQuery(sql,list.ToArray());
            return true;
        }
    }
}