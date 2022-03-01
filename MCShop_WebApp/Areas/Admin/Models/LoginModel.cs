using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCShop_WebApp.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage =("Vui lòng nhập tài khoản"))]
        public string userName { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string password { set; get; }
    }
}