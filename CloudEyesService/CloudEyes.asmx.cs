using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using CloudEyesService.Entity;
using CloudEyesService.Method;
using System.IO;
using System.Security.Cryptography;

namespace CloudEyesService
{
    ///// <summary>
    ///// CloudEyes 的摘要说明
    ///// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    ////[System.Web.Script.Services.ScriptService]  
    public class CloudEyes : System.Web.Services.WebService
    {
        #region 增加系统用户
        [WebMethod]
        //判断用户是否登陆成功
        public bool root(string jsonData)
        {
            MyUserInfo userinfo = new MyUserInfo();
            return userinfo.AddUsers(jsonData);
        }

        #endregion

        #region 登录功能相关接口，返回认证信息，返回下级医疗机构或三甲医院信息
        [WebMethod]
        //判断用户是否登陆成功
        public string Login(string username, string password)
        {
            string sql = "select * from UserInfo where UserName=@UserName and Password=@Password";
            string res = "";
            DataTable dt = SqlHelper.ExecuteTable(sql, new SqlParameter("@UserName", username), new SqlParameter("@Password", password));
            if (dt.Rows.Count > 0)
            {
                MyUserInfo userinfo = new MyUserInfo();
                res = userinfo.GetInfo(username);
            }
            return res;
        }

        #endregion

        #region 获取所有报表，管理员使用
        [WebMethod]
        //判断用户是否登陆成功
        public string GetAllReport()
        {
            MyReports rt = new MyReports();
            return rt.GetAllReport();
        }

        #endregion

        #region 获取信息 三甲医院使用
        [WebMethod]
        //判断用户是否登陆成功
        public string GetReportsByAuditUserID(decimal AuditUserID)
        {
            MyReports rt = new MyReports();
            return rt.GetReportsByAuditUserID(AuditUserID);
        }

        #endregion

        #region 根据病人姓名模糊查询
        [WebMethod]
        public string GetReportInfoByRetrieval(string retrievalMassage)
        {
            MyReports rt = new MyReports();
            return rt.GetReportInfoByRetrieval(retrievalMassage);
        }
        #endregion

        #region 通过上传用户编号检索数据，基层医院使用
        [WebMethod]
        public string GetReportsByUserID(decimal UserID)
        {
            MyReports rt = new MyReports();
            return rt.GetReportsByUserID(UserID);
        }
        #endregion

        #region 获取所有报表，管理员使用
        [WebMethod]
        public string GetReportInfo(decimal report_Id)
        {
            MyReports rt = new MyReports();
            return rt.GetReportInfo(report_Id);
        }
        #endregion

        #region 发送信息
        [WebMethod]
        public bool SendMessage(string jsonData)
        {
            MyConsultation SM = new MyConsultation();
            return SM.SendMessage(jsonData);
        }
        #endregion

        #region 接受信息
        [WebMethod]
        public string GetMessage(decimal sender_Id, decimal receiver_Id)
        {
            MyConsultation GM = new MyConsultation();
            return GM.GetMessage(sender_Id, receiver_Id);
        }
        #endregion

        #region 审核上传
        [WebMethod]
        public bool UploadInfo(decimal report_id, string jsonData)
        {
            MyReports rt = new MyReports();
            return rt.SubmiteInfo(report_id, jsonData);
        }
        #endregion

        #region 数据分析执行，三甲医院医生就某一病例给出分析建议（写入数据库），激活后台分析软件
        [WebMethod]
        public string DataAnalys(decimal report_id)
        {

            return "";
        }
        #endregion

        #region 文件信息传输
        [WebMethod]
        //判断用户是否登陆成功
        public bool DicomUpload(string jsonData)
        {
            MyReports rt = new MyReports();
            return rt.DicomUpload(jsonData);
        }
        #endregion

        #region 影像信息上传
        [WebMethod]
        public bool UploadFile(byte[] fs, string path, string fileName)
        {
            bool flag = false;
            try
            {
                //获取上传案例图片路径
                path = Server.MapPath(path);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //定义并实例化一个内存流，以存放提交上来的字节数组。
                MemoryStream m = new MemoryStream(fs);
                //定义实际文件对象，保存上载的文件。
                FileStream f = new FileStream(path + "\\" + fileName, FileMode.Create);
                //把内内存里的数据写入物理文件
                m.WriteTo(f);
                m.Close();
                f.Close();
                f = null;
                m = null;
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region 影像信息下载
        [WebMethod(Description = "下载服务器站点文件，传递文件相对路径")]
        public byte[] DownloadFile(string strFilePath, string path)
        {
            FileStream fs = null;
            string CurrentUploadFolderPath = HttpContext.Current.Server.MapPath(path);
            string CurrentUploadFilePath = CurrentUploadFolderPath + "\\" + strFilePath;
            if (File.Exists(CurrentUploadFilePath))
            {
                try
                {
                    ///打开现有文件以进行读取。
                    fs = File.OpenRead(CurrentUploadFilePath);
                    int b1;
                    System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
                    while ((b1 = fs.ReadByte()) != -1)
                    {
                        tempStream.WriteByte(((byte)b1));
                    }
                    return tempStream.ToArray();
                }
                catch (Exception ex)
                {
                    return new byte[0];
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                return new byte[0];
            }

        }
        #endregion
    }
}
