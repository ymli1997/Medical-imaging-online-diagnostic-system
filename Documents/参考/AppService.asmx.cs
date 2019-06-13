using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Xml;
using Dealeasy.Util;

using FLL;
using Dealeasy.Log;
using System.Text.RegularExpressions;
using BO;
using System.Collections;
using System.Threading;
using GetuiService;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using zymb.model;

namespace zymb.WebServices
{
    /// <summary>
    /// APPWebservice 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class AppService : System.Web.Services.WebService
    {
        #region 窗体变量
        public Identify identify = new Identify();
        #endregion

        #region 合并结构相同datatable
        /// <summary>
        /// json转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>
        public DataTable UniteDataTable(DataTable dt1, DataTable dt2)
        {
            DataTable DataTable1 = new DataTable();
            DataTable DataTable2 = new DataTable();
            DataTable newDataTable = DataTable1.Clone();

            object[] obj = new object[newDataTable.Columns.Count];
            for (int i = 0; i < DataTable1.Rows.Count; i++)
            {
                DataTable1.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }

            for (int i = 0; i < DataTable2.Rows.Count; i++)
            {
                DataTable2.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            return newDataTable;
        }
        #endregion

        #region Json转化方法
        /// <summary>
        /// json转换
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>
        public string DataTableToJSON(DataTable dt, string dtName)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jw = new JsonTextWriter(sw))
            {

                JsonSerializer ser = new JsonSerializer();

                jw.WriteStartObject();

                jw.WritePropertyName(dtName);

                jw.WriteStartArray();

                foreach (DataRow dr in dt.Rows)
                {
                    jw.WriteStartObject();
                    foreach (DataColumn dc in dt.Columns)
                    {

                        jw.WritePropertyName(dc.ColumnName);

                        ser.Serialize(jw, dr[dc].ToString());

                    }
                    jw.WriteEndObject();

                }

                jw.WriteEndArray();
                jw.WriteEndObject();
                sw.Close();
                jw.Close();
            }
            return sb.ToString();
        }
        #endregion

        #region 网络测试
        /// <summary>
        /// 网络测试
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [SoapHeader("identify", Direction = SoapHeaderDirection.In)]
        [WebMethod]
        public string NetTest(string str)
        {
            string response = "{ \"DoctorLogin\":[{ \"MessageCode\": \"1\",\"MessageContent\":\"医生登录失败，请重试！\"}]}";
            return response;
        }
        #endregion

        #region (医生端)医生登录

        /// <summary>
        /// (医生端)医生登录
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [SoapHeader("identify", Direction = SoapHeaderDirection.In)]
        [WebMethod]
        public string MSDoctorLogin(string str)
        {
            string response = "{ \"MSDoctorLogin\":[{ \"MessageCode\": \"1\",\"MessageContent\":\"登录失败！\"}]}";
            try
            {
                string Mobile = "";//用户ID
                string Pwd = "";
                string PhoneType = "";
                string ClientID = "";
                string DeviceToken = "";
                //xml解析
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(str);
                XmlNodeList nodelist = doc.SelectNodes("Request");
                if (nodelist[0].SelectSingleNode("DoctorMobile") != null)
                {
                    Mobile = nodelist[0].SelectSingleNode("DoctorMobile").InnerText.ToString().Trim();
                }
                else
                {
                    response = "{ \"MSDoctorLogin\":[{ \"MessageCode\": \"2\",\"MessageContent\":\"用户名不能为空！\"}]}";
                    return response;
                }
                if (nodelist[0].SelectSingleNode("Password") != null)
                {
                    Pwd = nodelist[0].SelectSingleNode("Password").InnerText.ToString().Trim();
                }
                else
                {
                    response = "{ \"MSDoctorLogin\":[{ \"MessageCode\": \"2\",\"MessageContent\":\"用户密码不能为空！\"}]}";
                    return response;
                }
                if (nodelist[0].SelectSingleNode("PhoneType") != null)
                {
                    PhoneType = nodelist[0].SelectSingleNode("PhoneType").InnerText.ToString().Trim();
                }
                if (nodelist[0].SelectSingleNode("ClientID") != null)
                {
                    ClientID = nodelist[0].SelectSingleNode("ClientID").InnerText.ToString().Trim();
                }
                if (nodelist[0].SelectSingleNode("DeviceToken") != null)
                {
                    DeviceToken = nodelist[0].SelectSingleNode("DeviceToken").InnerText.ToString().Trim();
                }
                Dictionary<string, object> dictcolunms = new Dictionary<string, object>();
                dictcolunms.Add("@PhoneType", PhoneType);
                dictcolunms.Add("@ClientID", ClientID);
                dictcolunms.Add("@DeviceToken", DeviceToken);

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("@Mobile", Mobile);
                dict.Add("@Password", ConstUntil.Encode(Pwd));
                dict.Add("@Result", "A.DoctorID,A.DoctorName,A.Mobile,A.Bingqu,A.UserSex,A.Introduction,A.PicURL");
                DataSet dsInfo = DoctorFLL.DoctorSearch(dict);
                if (dsInfo.Tables.Count > 0 && dsInfo.Tables[0].Rows.Count > 0)
                {
                    Dictionary<string, object> dictWhere = new Dictionary<string, object>();
                    dictWhere.Add("@DoctorID", dsInfo.Tables[0].Rows[0]["DoctorID"].ToString());
                    if (DoctorFLL.DoctorUpdate(dictcolunms, dictWhere) > 0)
                    {

                    }
                    response = DataTableToJSON(dsInfo.Tables[0], "MSDoctorLogin");
                }
                else
                {
                    response = "{ \"MSDoctorLogin\":[{ \"MessageCode\": \"2\",\"MessageContent\":\"用户名密码不正确！\"}]}";
                }

            }
            catch (Exception ex)
            {
                LogUtil.Log(ex);
            }
            return response;
        }

        #endregion

    }
}
