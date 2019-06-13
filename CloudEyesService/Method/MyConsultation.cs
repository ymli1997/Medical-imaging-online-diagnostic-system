using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudEyesService.Entity;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace CloudEyesService.Method
{
    public class MyConsultation : Consultation
    {
        public override bool SendMessage(string jsonData)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MyConsultation consultation = js.Deserialize<MyConsultation>(jsonData);
            List<SqlParameter> list = new List<SqlParameter>();
            Report_ID = consultation.Report_ID;
            SenderID = consultation.SenderID;
            ReceiverID = consultation.ReceiverID;
            Content = consultation.Content;
            Images = consultation.Images;
            SqlParameter[] ps =
            {
                new SqlParameter("@Report_ID",Report_ID),
                new SqlParameter("@SenderID",SenderID),
                new SqlParameter("@ReceiverID",ReceiverID),
                new SqlParameter("@Content",Content),
                new SqlParameter("@images",Images),
            };
            list.AddRange(ps);
            string sql = "insert into Consultation (Report_ID,SenderID,ReceiverID,Content,images) values(@Report_ID,@SenderID,@ReceiverID,@Content,@images)";
            return SqlHelper.ExecuteNonQuery(sql, list.ToArray()) > 0 ? true : false;
        }

        public override string GetMessage(decimal sender_id, decimal receiver_id)
        {
            List<MyConsultation> list = new List<MyConsultation>();
            string datetime = DateTime.Now.ToLocalTime().ToString();
            //string sql1 = "select * from (select top 3 * from Consultation where SenderID=@SenderID and ReceiverID=@ReceiverID and IsReaded = 1 order by ID desc) as t order by ID";
            string sql2 = "select * from Consultation where SenderID=@SenderID and ReceiverID=@ReceiverID and IsReaded = 0; update Consultation set IsReaded = 1, ReadTime = @ReadTime where SenderID = @SenderID and ReceiverID = @ReceiverID";
            //using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql1, new SqlParameter("@SenderID", sender_id), new SqlParameter("@ReceiverID", receiver_id)))
            //{
            //    if (sdr.HasRows)
            //    {
            //        while (sdr.Read())
            //        {
            //            MyConsultation cs = new MyConsultation();
            //            cs.Content = sdr["Content"].ToString();
            //            cs.Images = sdr["images"].ToString();
            //            if (cs.Content == "")
            //            {
            //                cs.Images = sdr["images"].ToString();
            //                list.Add(cs);
            //            }
            //            else if (cs.Images == "")
            //            {
            //                cs.Content = sdr["Content"].ToString();
            //                list.Add(cs);
            //            }
            //            else
            //                list.Add(cs);
            //        }
            //    }
            //}
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql2, new SqlParameter("@SenderID", sender_id), new SqlParameter("@ReceiverID", receiver_id), new SqlParameter("@ReadTime", datetime)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyConsultation cs = new MyConsultation();
                        cs.Content = sdr["Content"].ToString();
                        cs.Images = sdr["images"].ToString();
                        if (cs.Content == "")
                        {
                            cs.Images = sdr["images"].ToString();
                            list.Add(cs);
                        }
                        else if (cs.Images == "")
                        {
                            cs.Content = sdr["Content"].ToString();
                            list.Add(cs);
                        }
                        else
                            list.Add(cs);
                    }
                }
            }
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        public override string GetOneMessage(decimal sender_id, decimal receiver_id)
        {
            List<MyConsultation> list = new List<MyConsultation>();
            string datetime = DateTime.Now.ToLocalTime().ToString();
            string sql = "select * from Consultation where SenderID=@SenderID and ReceiverID=@ReceiverID and IsReaded = 0; update Consultation set IsReaded = 1, ReadTime = @ReadTime where SenderID = @SenderID and ReceiverID = @ReceiverID";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql, new SqlParameter("@SenderID", sender_id), new SqlParameter("@ReceiverID", receiver_id), new SqlParameter("@ReadTime", datetime)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyConsultation cs = new MyConsultation();
                        cs.Content = sdr["Content"].ToString();
                        cs.Images = sdr["images"].ToString();
                        if (cs.Content == "")
                        {
                            cs.Images = sdr["images"].ToString();
                            list.Add(cs);
                        }
                        else if (cs.Images == "")
                        {
                            cs.Content = sdr["Content"].ToString();
                            list.Add(cs);
                        }
                        else
                            list.Add(cs);
                    }
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(list);
        }
    }
}