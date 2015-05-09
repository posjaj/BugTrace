using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JAJ.WinForm
{
    public class UserInfo
    {
        private static UserInfo _user;
        private static object _obj = new object();

        private UserInfo()
        { 

        }

        public static UserInfo GetInstence()
        {
            if (_user == null)
            {
                lock (_obj)
                {
                    if (_user == null)
                        _user=new UserInfo();
                }
            }
            return _user;
        }

        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DefaultProjectCode { get; set; }
        public string Tel { get; set; }
        public string QQ { get; set; }
        public DateTime LoginTime { get; set; }

        

       
    }
}
