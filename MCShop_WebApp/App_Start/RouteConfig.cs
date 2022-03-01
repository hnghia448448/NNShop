using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MCShop_WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "GioHang",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "ShoppingCart", id = UrlParameter.Optional }
            // namespaces: new[]{"MCShop_WebApp.Controllers"}
            );
           
            routes.MapRoute(
               name: "TrangChu",
               url: "trang-chu",
               defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
           // namespaces: new[] { "MCShop_WebApp.Controllers" }
           );
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new { controller = "Book", action = "Contact", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "Order",
              url: "danhsach-donhang",
              defaults: new { controller = "UserOrder", action = "Order", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "Payment",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "PayMent", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );

             // namespaces: new[] { "MCShop_WebApp.Controllers" }
        }
    }
}
