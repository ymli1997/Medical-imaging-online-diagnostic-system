using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CloudEyesService.Entity;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace CloudEyesService.Method
{
    public class MyUserInfo:UserInfo
    {
        public override string GetInfo(string username)
        {
            string res = "";
            string sql = "select * from UserInfo where UserName=" + username;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        MyUserInfo userinfo = new MyUserInfo();
                        userinfo.User_ID = Convert.ToInt32(sdr["User_ID"]);
                        userinfo.UserName = sdr["UserName"].ToString();
                        userinfo.HospitalName = sdr["HospitalName"].ToString();
                        userinfo.UserRole = sdr["UserRole"].ToString();
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        res = js.Serialize(userinfo);
                    }
                }
            }
            return res;
        }

        public override bool AddUsers(string jsonData)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            UserName = "12345678";
            Password = "888888";
            UserRole = "管理员";
            HospitalName = "郑州大学第五附属医院";
            SqlParameter[] ps =
           {
                new SqlParameter("@UserName", UserName),
                new SqlParameter("@Password", Password),
                new SqlParameter("@UserRole", UserRole),
                new SqlParameter("@HospitalName", HospitalName),
            };
            list.AddRange(ps);
            string sql = "insert into UserInfo (UserName,Password,UserRole,HospitalName) values(@UserName,@Password,@UserRole,@HospitalName)";
            int res = SqlHelper.ExecuteNonQuery(sql, list.ToArray());
            return true;
        }
    }
}