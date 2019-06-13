using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CloudDiagnosis.Entity
{
    public class UserInfo
    {

        private decimal _User_ID;

        private string _UserName;

        private string _Password;

        private string _UserRole;

        private string _HospitalName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        /// <summary>
        /// 登陆角色
        /// </summary>
        public string UserRole
        {
            get
            {
                return _UserRole;
            }

            set
            {
                _UserRole = value;
            }
        }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName
        {
            get
            {
                return _HospitalName;
            }

            set
            {
                _HospitalName = value;
            }
        }

        /// <summary>
        /// 用户唯一编号
        /// </summary>
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

        public string GetInfo(string username)
        {
            string res = "";
            string sql = "select * from UserInfo where UserName=" + username;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sql))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        UserInfo userinfo = new UserInfo();
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

        public bool AddUsers(string jsonData)
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