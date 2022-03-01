using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCShop_WebApp.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    // khi truy xuat se la [HasCredential()]
    // lớp này tạo ra để phân quyền đăng nhập
    {
        public string MaQuyenSD { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        // cái ô vuông
        {
            // lấy ra sesion login, nếu có đăng nhập thì mới duyệt 
            var session = (ACCOUNT)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                return false;
            }
            // hàm getCredetialByLoggedInUser sẽ lấy ra danh sách các quyền sử dụng ở dạng list string
            string privilegeLevels = session.PERMISSION; // Call another method to get rights of the user from DB

            
                if (privilegeLevels.Trim() == this.MaQuyenSD) 
                {
                return true;
                }
                else
                {
                return false;
                }
                
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Areas/Admin/Views/User/Index.cshtml"
            };
        }
    }
}