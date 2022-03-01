using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCShop_WebApp.Areas.Admin.Models
{
    public class ChangePassModel
    {
        [Key]
        public string id { set; get; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        public string oldPass { set; get; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        public string newPass { set; get; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu ít nhất 6 kí tự.")]
        [Compare("newPass", ErrorMessage = "Vui lòng xác nhận lại mật khẩu")]
        public string cfNewPass { set; get; }
    }
}