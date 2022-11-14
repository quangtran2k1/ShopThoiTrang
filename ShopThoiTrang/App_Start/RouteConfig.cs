using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopThoiTrang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ProductDetail",
                url: "Sanpham/{slug}",
                defaults: new { controller = "Sanpham", action = "ProductDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "edit-password",
                url: "user/change-password",
                defaults: new { controller = "User", action = "ChangePassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User-edit",
                url: "user/edit",
                defaults: new { controller = "User", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "user/",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tim-kiem",
                url: "search/",
                defaults: new { controller = "Trangchu", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Loai-san-pham",
                url: "loai-san-pham/{slug}",
                defaults: new { controller = "Sanpham", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
