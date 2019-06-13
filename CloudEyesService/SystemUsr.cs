using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using CloudEyesService.Entity;

namespace CloudEyesService
{
    public class SystemUsr
    {
        
        /// <summary>
        /// 得到用户登录名，判断用户是否登陆成功
        /// </summary>
        /// <param name="User_Id"></param>
        /// <param name="Password"></param>
        /// <returns>登陆成功或者失败</returns>
        public string GetUserInfoByLoginName(string User_Id, string Password)
        {
            //string sqlsys = "select * from sys_users where User_Id=@User_Id and Password=@Password";
            //string res="";
            //DataTable dt = SqlHelper.ExecuteTable(sqlsys, new SqlParameter("@User_Id", User_Id), new SqlParameter("@Password", Password));
            //if (dt.Rows.Count > 0)
            //{
            //    HospitalInfo hpf = new HospitalInfo();
            //    res =  hpf.GetInfo();
            //}
            
            sys_users temp = new sys_users();
            temp.User_ID = 1;
            temp.UserName = "章医生";
            temp.Password = "123456";
            temp.UserRole = "doctor";
            temp.HospitalName = "郑州大学第一附属医院";

            //把集合放入json中
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(temp);

            //return res;
        }

    }
}