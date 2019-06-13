using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudEyesService.Entity;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace CloudEyesService.Method
{
    public class MyReports : Reports
    {
        /// <summary>
        /// 通过审核用户查询所有数据，三甲医院使用
        /// </summary>
        /// <param name="AuditUserID"></param>
        /// <returns></returns>
        public override string GetReportsByAuditUserID(decimal AuditUserID)
        {
            List<MyReports> list = new List<MyReports>();
            string sql = "select * from Reports left join UserInfo on Reports.AuditUserID = UserInfo.User_ID  where Reports.AuditUserID=@User_ID or Reports.isAudited=0";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@User_ID", AuditUserID)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyReports rt = new MyReports();
                        rt.IsAudited = Convert.ToBoolean(sdr["IsAudited"]);
                        if (sdr["AuditUserName"].ToString() != null)
                            rt.AuditUserName = sdr["AuditUserName"].ToString();
                        if (sdr["AuditUserID"].ToString() != null)
                            rt.AuditUserID = sdr["AuditUserID"].ToString();
                        if (Convert.ToInt32(sdr["Report_ID"]) != 0)
                            rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        if (sdr["Overview"].ToString() != null)
                            rt.Overview = sdr["Overview"].ToString();
                        if (sdr["Content"].ToString() != null)
                            rt.Content = sdr["Content"].ToString();
                        if (sdr["Comment"].ToString() != null)
                            rt.Comment = sdr["Comment"].ToString();
                        if (sdr["AuditTime"].ToString() != null)
                            rt.AuditTime = sdr["AuditTime"].ToString();
                        if (sdr["PatientName"].ToString() != null)
                            rt.PatientName = sdr["PatientName"].ToString();
                        if (sdr["PatientID"].ToString() != null)
                            rt.PatientID = sdr["PatientID"].ToString();
                        if (Convert.ToInt32(sdr["PatientAge"]) != 0)
                            rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        if (sdr["PatientSex"].ToString() != null)
                            rt.PatientSex = sdr["PatientSex"].ToString();
                        if (sdr["StudyTime"].ToString() != null)
                            rt.StudyTime = sdr["StudyTime"].ToString();
                        if (sdr["BodyPart"].ToString() != null)
                            rt.BodyPart = sdr["BodyPart"].ToString();
                        if (sdr["StudyDescription"].ToString() != null)
                            rt.StudyDescription = sdr["StudyDescription"].ToString();
                        if (sdr["InstitutionName"].ToString() != null)
                            rt.InstitutionName = sdr["InstitutionName"].ToString();
                        if (sdr["RequestTime"].ToString() != null)
                            rt.RequestTime = sdr["RequestTime"].ToString();
                        if (sdr["Modality"].ToString() != null)
                            rt.Modality = sdr["Modality"].ToString();
                        if (sdr["StudyLocalDirectory"].ToString() != null)
                            rt.StudyLocalDirectory = sdr["StudyLocalDirectory"].ToString();
                        if (sdr["StudyLocalDirectorySeg"].ToString() != null)
                            rt.StudyLocalDirectorySeg = sdr["StudyLocalDirectorySeg"].ToString();
                        if (sdr["ImageFilePath"].ToString() != null)
                            rt.ImageFilePath = sdr["ImageFilePath"].ToString();
                        if (sdr["MaskFilePath"].ToString() != null)
                            rt.MaskFilePath = sdr["MaskFilePath"].ToString();
                        list.Add(rt);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// 通过上传用户编号检索数据，基层医院使用
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public override string GetReportsByUserID(decimal UserID)
        {
            List<MyReports> list = new List<MyReports>();
            string sql = "select * from Reports left join UserInfo on Reports.User_ID = UserInfo.User_ID  where UserInfo.User_ID = @User_ID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@User_ID", UserID)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyReports rt = new MyReports();
                        rt.IsAudited = Convert.ToBoolean(sdr["IsAudited"]);
                        if (sdr["AuditUserName"].ToString() != null)
                            rt.AuditUserName = sdr["AuditUserName"].ToString();
                        if (sdr["AuditUserID"].ToString() != null)
                            rt.AuditUserID = sdr["AuditUserID"].ToString();
                        if (Convert.ToInt32(sdr["Report_ID"]) != 0)
                            rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        if (sdr["Overview"].ToString() != null)
                            rt.Overview = sdr["Overview"].ToString();
                        if (sdr["Content"].ToString() != null)
                            rt.Content = sdr["Content"].ToString();
                        if (sdr["Comment"].ToString() != null)
                            rt.Comment = sdr["Comment"].ToString();
                        if (sdr["AuditTime"].ToString() != null)
                            rt.AuditTime = sdr["AuditTime"].ToString();
                        if (sdr["PatientName"].ToString() != null)
                            rt.PatientName = sdr["PatientName"].ToString();
                        if (sdr["PatientID"].ToString() != null)
                            rt.PatientID = sdr["PatientID"].ToString();
                        if (Convert.ToInt32(sdr["PatientAge"]) != 0)
                            rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        if (sdr["PatientSex"].ToString() != null)
                            rt.PatientSex = sdr["PatientSex"].ToString();
                        if (sdr["StudyTime"].ToString() != null)
                            rt.StudyTime = sdr["StudyTime"].ToString();
                        if (sdr["BodyPart"].ToString() != null)
                            rt.BodyPart = sdr["BodyPart"].ToString();
                        if (sdr["StudyDescription"].ToString() != null)
                            rt.StudyDescription = sdr["StudyDescription"].ToString();
                        if (sdr["InstitutionName"].ToString() != null)
                            rt.InstitutionName = sdr["InstitutionName"].ToString();
                        if (sdr["RequestTime"].ToString() != null)
                            rt.RequestTime = sdr["RequestTime"].ToString();
                        if (sdr["Modality"].ToString() != null)
                            rt.Modality = sdr["Modality"].ToString();
                        if (sdr["StudyLocalDirectory"].ToString() != null)
                            rt.StudyLocalDirectory = sdr["StudyLocalDirectory"].ToString();
                        if (sdr["StudyLocalDirectorySeg"].ToString() != null)
                            rt.StudyLocalDirectorySeg = sdr["StudyLocalDirectorySeg"].ToString();
                        if (sdr["ImageFilePath"].ToString() != null)
                            rt.ImageFilePath = sdr["ImageFilePath"].ToString();
                        if (sdr["MaskFilePath"].ToString() != null)
                            rt.MaskFilePath = sdr["MaskFilePath"].ToString();
                        list.Add(rt);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// 获取所有报表，管理员使用
        /// </summary>
        /// <returns></returns>
        public override string GetAllReport()
        {
            List<MyReports> list = new List<MyReports>();
            string sql = "select * from Reports left join UserInfo on Reports.AuditUserID = UserInfo.User_ID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyReports rt = new MyReports();
                        rt.IsAudited = Convert.ToBoolean(sdr["IsAudited"]);                        
                        if (sdr["AuditUserID"].ToString() != null)
                            rt.AuditUserID = sdr["AuditUserID"].ToString();
                        if (Convert.ToInt32(sdr["Report_ID"]) != 0)
                            rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        if (sdr["Overview"].ToString() != null)
                            rt.Overview = sdr["Overview"].ToString();
                        if (sdr["Content"].ToString() != null)
                            rt.Content = sdr["Content"].ToString();
                        if (sdr["Comment"].ToString() != null)
                            rt.Comment = sdr["Comment"].ToString();
                        if (sdr["AuditTime"].ToString() != null)
                            rt.AuditTime = sdr["AuditTime"].ToString();
                        if (sdr["PatientName"].ToString() != null)
                            rt.PatientName = sdr["PatientName"].ToString();
                        if (sdr["PatientID"].ToString() != null)
                            rt.PatientID = sdr["PatientID"].ToString();
                        if (Convert.ToInt32(sdr["PatientAge"]) != 0)
                            rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        if (sdr["PatientSex"].ToString() != null)
                            rt.PatientSex = sdr["PatientSex"].ToString();
                        if (sdr["StudyTime"].ToString() != null)
                            rt.StudyTime = sdr["StudyTime"].ToString();
                        if (sdr["BodyPart"].ToString() != null)
                            rt.BodyPart = sdr["BodyPart"].ToString();
                        if (sdr["StudyDescription"].ToString() != null)
                            rt.StudyDescription = sdr["StudyDescription"].ToString();
                        if (sdr["InstitutionName"].ToString() != null)
                            rt.InstitutionName = sdr["InstitutionName"].ToString();
                        if (sdr["RequestTime"].ToString() != null)
                            rt.RequestTime = sdr["RequestTime"].ToString();
                        if (sdr["Modality"].ToString() != null)
                            rt.Modality = sdr["Modality"].ToString();
                        if (sdr["StudyLocalDirectory"].ToString() != null)
                            rt.StudyLocalDirectory = sdr["StudyLocalDirectory"].ToString();
                        if (sdr["StudyLocalDirectorySeg"].ToString() != null)
                            rt.StudyLocalDirectorySeg = sdr["StudyLocalDirectorySeg"].ToString();
                        if (sdr["ImageFilePath"].ToString() != null)
                            rt.ImageFilePath = sdr["ImageFilePath"].ToString();
                        if (sdr["MaskFilePath"].ToString() != null)
                            rt.MaskFilePath = sdr["MaskFilePath"].ToString();
                        if (sdr["AuditUserName"].ToString() != null)
                            rt.AuditUserName = sdr["AuditUserName"].ToString();
                        list.Add(rt);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// 根据病人姓名查询
        /// </summary>
        /// <param name="retrievalMassage"></param>
        /// <returns></returns>
        public override string GetReportInfoByRetrieval(string retrievalMassage)
        {
            List<MyReports> list = new List<MyReports>();
            string sql = "select * from Reports where PatientName like '%" + retrievalMassage + "%'";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("PatientName",retrievalMassage)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyReports rt = new MyReports();
                        rt.IsAudited = Convert.ToBoolean(sdr["IsAudited"]);
                        if (sdr["AuditUserName"].ToString() != null)
                            rt.AuditUserName = sdr["AuditUserName"].ToString();
                        if (sdr["AuditUserID"].ToString() != null)
                            rt.AuditUserID = sdr["AuditUserID"].ToString();
                        if (Convert.ToInt32(sdr["Report_ID"]) != 0)
                            rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        if (sdr["Overview"].ToString() != null)
                            rt.Overview = sdr["Overview"].ToString();
                        if (sdr["Content"].ToString() != null)
                            rt.Content = sdr["Content"].ToString();
                        if (sdr["Comment"].ToString() != null)
                            rt.Comment = sdr["Comment"].ToString();
                        if (sdr["AuditTime"].ToString() != null)
                            rt.AuditTime = sdr["AuditTime"].ToString();
                        if (sdr["PatientName"].ToString() != null)
                            rt.PatientName = sdr["PatientName"].ToString();
                        if (sdr["PatientID"].ToString() != null)
                            rt.PatientID = sdr["PatientID"].ToString();
                        if (Convert.ToInt32(sdr["PatientAge"]) != 0)
                            rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        if (sdr["PatientSex"].ToString() != null)
                            rt.PatientSex = sdr["PatientSex"].ToString();
                        if (sdr["StudyTime"].ToString() != null)
                            rt.StudyTime = sdr["StudyTime"].ToString();
                        if (sdr["BodyPart"].ToString() != null)
                            rt.BodyPart = sdr["BodyPart"].ToString();
                        if (sdr["StudyDescription"].ToString() != null)
                            rt.StudyDescription = sdr["StudyDescription"].ToString();
                        if (sdr["InstitutionName"].ToString() != null)
                            rt.InstitutionName = sdr["InstitutionName"].ToString();
                        if (sdr["RequestTime"].ToString() != null)
                            rt.RequestTime = sdr["RequestTime"].ToString();
                        if (sdr["Modality"].ToString() != null)
                            rt.Modality = sdr["Modality"].ToString();
                        if (sdr["StudyLocalDirectory"].ToString() != null)
                            rt.StudyLocalDirectory = sdr["StudyLocalDirectory"].ToString();
                        if (sdr["StudyLocalDirectorySeg"].ToString() != null)
                            rt.StudyLocalDirectorySeg = sdr["StudyLocalDirectorySeg"].ToString();
                        if (sdr["ImageFilePath"].ToString() != null)
                            rt.ImageFilePath = sdr["ImageFilePath"].ToString();
                        if (sdr["MaskFilePath"].ToString() != null)
                            rt.MaskFilePath = sdr["MaskFilePath"].ToString();
                        list.Add(rt);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// 根据report_id获取报表信息
        /// </summary>
        /// <param name="report_id"></param>
        /// <returns></returns>
        public override string GetReportInfo(decimal report_id)
        {
            MyReports rt = new MyReports();
            string sql = "select * from Reports where Report_ID=@Report_ID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@Report_ID", report_id)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        rt.IsAudited = Convert.ToBoolean(sdr["IsAudited"]);
                        //if (sdr["AuditUserName"].ToString() != null)
                        //    rt.AuditUserName = sdr["AuditUserName"].ToString();                        
                        if (sdr["AuditUserID"].ToString() != null)
                            rt.AuditUserID = sdr["AuditUserID"].ToString();
                        if (Convert.ToInt32(sdr["Report_ID"]) != 0)
                            rt.Report_ID = Convert.ToInt32(sdr["Report_ID"]);
                        if (sdr["Overview"].ToString() != null)
                            rt.Overview = sdr["Overview"].ToString();
                        if (sdr["Content"].ToString() != null)
                            rt.Content = sdr["Content"].ToString();
                        if (sdr["Comment"].ToString() != null)
                            rt.Comment = sdr["Comment"].ToString();
                        if (sdr["AuditTime"].ToString() != null)
                            rt.AuditTime = sdr["AuditTime"].ToString();
                        if (sdr["PatientName"].ToString() != null)
                            rt.PatientName = sdr["PatientName"].ToString();
                        if (sdr["PatientID"].ToString() != null)
                            rt.PatientID = sdr["PatientID"].ToString();
                        if (Convert.ToInt32(sdr["PatientAge"]) != 0)
                            rt.PatientAge = Convert.ToInt32(sdr["PatientAge"]);
                        if (sdr["PatientSex"].ToString() != null)
                            rt.PatientSex = sdr["PatientSex"].ToString();
                        if (sdr["StudyTime"].ToString() != null)
                            rt.StudyTime = sdr["StudyTime"].ToString();
                        if (sdr["BodyPart"].ToString() != null)
                            rt.BodyPart = sdr["BodyPart"].ToString();
                        if (sdr["StudyDescription"].ToString() != null)
                            rt.StudyDescription = sdr["StudyDescription"].ToString();
                        if (sdr["InstitutionName"].ToString() != null)
                            rt.InstitutionName = sdr["InstitutionName"].ToString();
                        if (sdr["RequestTime"].ToString() != null)
                            rt.RequestTime = sdr["RequestTime"].ToString();
                        if (sdr["Modality"].ToString() != null)
                            rt.Modality = sdr["Modality"].ToString();
                        if (sdr["StudyLocalDirectory"].ToString() != null)
                            rt.StudyLocalDirectory = sdr["StudyLocalDirectory"].ToString();
                        if (sdr["StudyLocalDirectorySeg"].ToString() != null)
                            rt.StudyLocalDirectorySeg = sdr["StudyLocalDirectorySeg"].ToString();
                        if (sdr["ImageFilePath"].ToString() != null)
                            rt.ImageFilePath = sdr["ImageFilePath"].ToString();
                        if (sdr["MaskFilePath"].ToString() != null)
                            rt.MaskFilePath = sdr["MaskFilePath"].ToString();
                        if (sdr["AuditUserName"].ToString() != null)
                            rt.AuditUserName = sdr["AuditUserName"].ToString();
                    }
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(rt);
        }


        /// <summary>
        /// 报告审核
        /// </summary>
        /// <param name="report_id"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public override bool SubmiteInfo(decimal report_id, string jsonData)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MyReports rt = js.Deserialize<MyReports>(jsonData);
            List<SqlParameter> list = new List<SqlParameter>();
            Content = rt.Content;
            Comment = rt.Comment;
            ///TODO Overview是否有用？
            Overview = rt.Overview;
            AuditTime = DateTime.Now.ToLocalTime().ToString();

            SqlParameter[] ps =
            {
                new SqlParameter("@Content",Content),
                new SqlParameter("@Comment",Comment),
                new SqlParameter("@AuditTime",AuditTime),
                new SqlParameter("@StudyDescription",rt.StudyDescription),
                new SqlParameter("@AuditUserID", rt.AuditUserID),
                new SqlParameter("@AuditUserName", rt.AuditUserName)

            };
            list.AddRange(ps);
            string sql = "update Reports set Content=@Content,Comment=@Comment,StudyDescription=@StudyDescription,AuditUserID = @AuditUserID,AuditUserName = @AuditUserName, AuditTime=@AuditTime, IsAudited = 1 where Report_ID=" + report_id;
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray()) > 0 ? true : false;
        }


        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="ReportID"></param>
        /// <param name="imageFile"></param>
        /// <param name="maskFile"></param>
        public delegate void GliomaGradingHandler(int ReportID,string imageFile, string maskFile);

        public override bool DicomUpload(string jsonData)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MyReports rt = js.Deserialize<MyReports>(jsonData);
            User_ID = rt.User_ID;
            PatientName = rt.PatientName;
            PatientSex = rt.PatientSex;
            PatientAge = rt.PatientAge;
            PatientID = rt.PatientID;
            StudyDescription = rt.StudyDescription;
            StudyLocalDirectory = rt.StudyLocalDirectory;
            StudyLocalDirectorySeg = rt.StudyLocalDirectorySeg;
            ImageFilePath = rt.ImageFilePath;
            MaskFilePath = rt.MaskFilePath;

            SqlParameter[] ps =
            {
                new SqlParameter("@User_ID",User_ID),
                new SqlParameter("@PatientName",PatientName),
                new SqlParameter("@PatientSex",PatientSex),
                new SqlParameter("@PatientAge",PatientAge),
                new SqlParameter("@PatientID",PatientID),
                new SqlParameter("@StudyDescription",StudyDescription),
                new SqlParameter("@StudyLocalDirectory",StudyLocalDirectory),
                new SqlParameter("@StudyLocalDirectorySeg",StudyLocalDirectorySeg),
                new SqlParameter("@ImageFilePath",ImageFilePath),
                new SqlParameter("@MaskFilePath",MaskFilePath),
            };
            string sql1 = "insert into Reports (User_ID, PatientName,PatientSex,PatientAge,PatientID,StudyDescription,StudyLocalDirectory,StudyLocalDirectorySeg,ImageFilePath,MaskFilePath) values(@User_ID, @PatientName,@PatientSex,@PatientAge,@PatientID,@StudyDescription,@StudyLocalDirectory,@StudyLocalDirectorySeg,@ImageFilePath,@MaskFilePath);select @@IDENTITY";
            //int id = Convert.ToInt32(SqlHelper.ExecuteScalar(sql1, list.ToArray()));
            //Report_ID = 30;
            // bool a = SqlHelper.ExecuteNonQuery(sql1, list.ToArray()) > 0 ? true : false;
            int reportID = Convert.ToInt32(SqlHelper.ExecuteScalar(sql1, ps));
            
            GliomaGradingHandler gliomaGradingHandler = new GliomaGradingHandler(GradingGlioma);
            gliomaGradingHandler(reportID, ImageFilePath, MaskFilePath);

            //调用甘富文的接口
            //GradingGliomaAsync(reportID, ImageFilePath, MaskFilePath);

            if (reportID > 0)
                return true;
            else
                return false;
        }
        

        public void GradingGlioma(int reportID,string imageFile, string maskFile)
        {
            ///TODO 尚未实现
            gradingServeice.ApplicationClient client = new gradingServeice.ApplicationClient();
            gradingServeice.glioma_grading g1 = new gradingServeice.glioma_grading();
            g1.image = imageFile;
            g1.mask = maskFile;
            //System.Threading.Tasks.Task<gradingServeice.glioma_gradingResponse1> gradingTask = client.glioma_gradingAsync(g1);

            string gradeResult = "";
            try
            {
                gradingServeice.glioma_gradingResponse res = client.glioma_grading(g1);
                foreach (string str in res.glioma_gradingResult)
                {
                    gradeResult = gradeResult + str;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                gradeResult = "调用服务器失败，信息为：" + ex.Message;
            }
            
            gradeResult = "AI分析结果为：" + gradeResult;

            SqlParameter[] paramUpdate =
            {
                new SqlParameter("@Comment",gradeResult),
                new SqlParameter("@Report_ID",reportID)
            };
            string sqlUpdate = "update Reports set Comment = @Comment where Report_ID = @Report_ID";
            SqlHelper.ExecuteNonQuery(sqlUpdate, paramUpdate);
        }
    }
    
}