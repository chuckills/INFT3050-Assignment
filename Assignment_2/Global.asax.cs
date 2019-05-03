﻿using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment_1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Initialise shopping cart to empty for each session
            HttpContext.Current.Session["Cart"] = new ShoppingCart();

            // Add admin user to session
            HttpContext.Current.Session["Admin"] = new User("admin@jerseysure.com", "admin", true);

            // Add general user to session
            HttpContext.Current.Session["User"] = new User("user", "user", false);

            // Add variable indicating status of login 
            HttpContext.Current.Session["LoginStatus"] = "LoggedOut";
        }
    }
}