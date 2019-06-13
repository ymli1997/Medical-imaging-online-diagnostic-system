using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace CloudEyesService.Entity
{
    public abstract class UserInfo
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

        public abstract string GetInfo(string username);
        public abstract bool AddUsers(string jsonData);
       
    }
}