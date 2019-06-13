using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CloudEyesService
{
    public class Reports
    {
        public void GetInfo()
        {
            List<Reports> list = new List<Reports>();
            string sqlrt = "select * from Reports";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sqlrt))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        //Reports rt = new Reports();
                        //rt.Id = Convert.ToInt32(sdr["ID"]);
                        //hpf.HospitalId = Convert.ToInt32(sdr["Hospital_ID"]);
                        //hpf.HospitalName = sdr["HospitalName"].ToString();
                        //hpf.DoctorId = Convert.ToInt32(sdr["Doctor_ID"]);
                        //hpf.DoctorName = sdr["DoctorName"].ToString();
                        //list.Add(hpf);
                    }
                }
            }
        }

        public void GetInfo(string Id)
        {
            List<Reports> list = new List<Reports>();
            string sqlrt = "select* from sys_users where User_Id = "+Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sqlrt, new SqlParameter("@User_Id", Id)))
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        //Reports rt = new Reports();
                        //rt.Id = Convert.ToInt32(sdr["ID"]);
                        //hpf.HospitalId = Convert.ToInt32(sdr["Hospital_ID"]);
                        //hpf.HospitalName = sdr["HospitalName"].ToString();
                        //hpf.DoctorId = Convert.ToInt32(sdr["Doctor_ID"]);
                        //hpf.DoctorName = sdr["DoctorName"].ToString();
                        //list.Add(hpf);
                    }
                }
            }
        }

        public int InsertInfo(string ID,string DoctorName)
        {
            string sql = "insert into HospitalInfo(ID,DoctorName)values("+ID+","+DoctorName+")";
            int res = SqlHelper.ExecuteNonQuery(sql);
            return res;
        }
    }
}