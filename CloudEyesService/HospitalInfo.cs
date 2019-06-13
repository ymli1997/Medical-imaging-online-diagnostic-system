using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CloudEyesService
{
    public class HospitalInfo
    {
        private string _DoctorName;
        private int _Id;

        public string DoctorName
        {
            get
            {
                return _DoctorName;
            }

            set
            {
                _DoctorName = value;
            }
        }

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string GetInfo()
        {
            List<HospitalInfo> list = new List<HospitalInfo>();
            string sqlhos = "select * from HospitalInfo";
            using (SqlDataReader sdr = SqlHelper.ExecuteReader(sqlhos))
            {
                if(sdr.HasRows)
                {
                    while(sdr.Read())
                    {
                        HospitalInfo hpf = new HospitalInfo();
                        hpf.Id = Convert.ToInt32(sdr["ID"]);
                        //hpf.HospitalId = Convert.ToInt32(sdr["Hospital_ID"]);
                        //hpf.HospitalName = sdr["HospitalName"].ToString();
                        //hpf.DoctorId = Convert.ToInt32(sdr["Doctor_ID"]);
                        hpf.DoctorName = sdr["DoctorName"].ToString();
                        list.Add(hpf);
                    }
                }
            }
            //把集合放入json中
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //return js.Serialize(list);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }    

    }
}