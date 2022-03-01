using Model.Dao;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCShop_WebApp.Areas.Admin.Models
{
    
    public class RegisterModel
    {
        MCShop_DbContext context = new MCShop_DbContext();
        [Key]
        public int Id { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập tên người dùng.")]
        public string userName { set; get; }
        [Required(ErrorMessage ="Vui lòng nhập tài khoản.")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="Mật khẩu ít nhất 6 kí tự.")]
        public string password { set; get; }
        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [Compare("password", ErrorMessage ="Vui lòng xác nhận lại mật khẩu")]
        public string confirmPassword { set; get; }
        public void UpdatePass(int accId, string newPass)
        {
            var accNew = context.ACCOUNTS.Find(accId);
            accNew.PASSWORD = Encryptor.MD5Hash(newPass);
            context.SaveChanges();
        }
    }
}