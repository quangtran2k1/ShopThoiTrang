using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopThoiTrang
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Session["UserAdmin"] = "";
            Session["User"] = "";
            Session["UserID"] = "";
            Session["Password"] = "";
            Session["Address"] = "";
            Session["FullName"] = "";
            Session["Img"] = "";
            Session["Phone"] = "";
            Session["Email"] = "";
            Session["MyCart"] = "";
        }
    }
}
