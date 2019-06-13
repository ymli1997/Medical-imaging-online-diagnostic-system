using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CloudEyesService.Entity
{
    public abstract class Reports
    {
        private decimal _User_ID;

        private decimal _Report_ID;

        private string _Overview;

        private string _Content;

        private string _Comment;

        private bool _isAudited;

        private string _AuditUserID;

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
        public string AuditUserID
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

        /// <summary>
        /// 审核人姓名
        /// </summary>
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

        public abstract string GetReportsByAuditUserID(decimal AuditUserID);

        public abstract string GetAllReport();

        //新增
        public abstract string GetReportInfoByRetrieval(string retrievalMassage);

        public abstract string GetReportsByUserID(decimal User_ID);

        public abstract string GetReportInfo(decimal report_id);

        public abstract bool SubmiteInfo(decimal report_id, string jsonData);

        public abstract bool DicomUpload(string jsonData);
    }
}