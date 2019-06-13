using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudEyesService
{
    //管理员
    public class Administrator
    {
        private int _userId;

        private string _userName;

        private string _passWord;

        public int UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
            }
        }
        public string PassWord
        {
            get
            {
                return _passWord;
            }

            set
            {
                _passWord = value;
            }
        }
    }
}