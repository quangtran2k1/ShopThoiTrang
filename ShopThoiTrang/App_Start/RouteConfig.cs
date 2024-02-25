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
                url: "product/{slug}",
                defaults: new { controller = "Sanpham", action = "ProductDetail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "edit-password",
                url: "user/change-password/{id}",
                defaults: new { controller = "NguoiDung", action = "ChangePassword", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User-edit",
                url: "user/edit/{id}",
                defaults: new { controller = "NguoiDung", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Register",
                url: "user/register",
                defaults: new { controller = "NguoiDung", action = "Register", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Logout",
                url: "user/logout",
                defaults: new { controller = "NguoiDung", action = "Logout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "user/login",
                defaults: new { controller = "NguoiDung", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "user/",
                defaults: new { controller = "NguoiDung", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tim-kiem",
                url: "search/",
                defaults: new { controller = "TrangChu", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Loai-san-pham",
                url: "category/{slug}",
                defaults: new { controller = "Sanpham", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About",
                url: "about/",
                defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact",
                url: "contact/",
                defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Blog",
                url: "blog/",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "product/",
                defaults: new { controller = "Sanpham", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductCategory",
                url: "category/product/{catid}",
                defaults: new { controller = "Sanpham", action = "ProductCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Send-Contact",
                url: "contact/send-contact",
                defaults: new { controller = "LienHe", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "cart",
                url: "cart/",
                defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "pay",
                url: "cart/pay",
                defaults: new { controller = "Giohang", action = "Thanhtoan", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
