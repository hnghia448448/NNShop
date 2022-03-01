using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCShop_WebApp.Common
{
    [Serializable]
    public class UserLogin
    {
      
        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string QuyenSDs { set; get; }
    }
}