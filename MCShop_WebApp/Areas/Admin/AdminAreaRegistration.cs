using System.Web.Mvc;

namespace MCShop_WebApp.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 name: "Register",
                 url: "dang-ky",
                 defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
              // namespaces: new[]{"MCShop_WebApp.Controllers"}
              );
            context.MapRoute(
              name: "Login",
              url: "dang-nhap",
              defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
           // namespaces: new[]{"MCShop_WebApp.Controllers"}
           );
            context.MapRoute(
              name: "ChangePass",
              url: "doi-matkhau",
              defaults: new { controller = "User", action = "ChangePassword", id = UrlParameter.Optional }
           // namespaces: new[]{"MCShop_WebApp.Controllers"}
           );
            context.MapRoute(
                 name: "EditBook",
                 url: "chinhsua-sach",
                 defaults: new { controller = "Home", action = "EditBook", id = UrlParameter.Optional }
              // namespaces: new[]{"MCShop_WebApp.Controllers"}
              );
            context.MapRoute(
                 name: "AddBook",
                 url: "them-sach",
                 defaults: new { controller = "Home", action = "CreateBook", id = UrlParameter.Optional }
              // namespaces: new[]{"MCShop_WebApp.Controllers"}
              );
            context.MapRoute(
                 name: "DeleteBook",
                 url: "xoa-sach",
                 defaults: new { controller = "Home", action = "DeleteBook", id = UrlParameter.Optional }
              // namespaces: new[]{"MCShop_WebApp.Controllers"}
              );
            context.MapRoute(
                 name: "Index",
                 url: "index",
                 defaults: new { controller = "Home", action = "EditBook", id = UrlParameter.Optional }
              // namespaces: new[]{"MCShop_WebApp.Controllers"}
              );
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller ="Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}