using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Assignment_2
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
	        var settings = new FriendlyUrlSettings()
	        {
		        AutoRedirectMode = RedirectMode.Permanent
	        };

            routes.EnableFriendlyUrls(settings, new JerseyResolver());

            routes.MapPageRoute("About", "About", "~/UL/About.aspx");
            routes.MapPageRoute("AccountSettings", "AccountSettings", "~/UL/AccountSettings.aspx");
            routes.MapPageRoute("AdminItemManagement", "AdminItemManagement", "~/UL/AdminItemManagement.aspx");
            routes.MapPageRoute("AdminItemManagementInsert", "AdminItemManagementInsert", "~/UL/AdminItemManagementInsert.aspx");
            routes.MapPageRoute("AdminManageUserAccounts", "AdminManageUserAccounts", "~/UL/AdminManageUserAccounts.aspx");
            routes.MapPageRoute("AdminPostageOptions", "AdminPostageOptions", "~/UL/AdminPostageOptions.aspx");
            routes.MapPageRoute("AdminRegistration",
                "AdminRegistration/{vc}",
                "~/UL/AdminRegistration.aspx", false,
                new RouteValueDictionary { { "vc", string.Empty } });
            routes.MapPageRoute("AdminTransactions", "AdminTransactions", "~/UL/AdminTransactions.aspx");
            routes.MapPageRoute("AdminUpdateSelectedItem", "AdminUpdateSelectedItem", "~/UL/AdminUpdateSelectedItem.aspx");
            routes.MapPageRoute("AdminUpdateSelectedUser", "AdminUpdateSelectedUser", "~/UL/AdminUpdateSelectedUser.aspx");
            routes.MapPageRoute("Cart", "Cart", "~/UL/Cart.aspx");
            routes.MapPageRoute(
               "ChangePassword",
                "ChangePassword/{email}/{pass}",
                "~/UL/ChangePassword.aspx", false,
                new RouteValueDictionary { { "email", string.Empty }, { "pass", string.Empty }}
            );
            routes.MapPageRoute("Contact", "Contact", "~/UL/Contact.aspx");
			routes.MapPageRoute("Default", "Default", "~/UL/Default.aspx");
			routes.MapPageRoute("ErrorPage", 
				"ErrorPage/{status}", 
				"~/UL/ErrorPage.aspx", false,
				new RouteValueDictionary { { "status", string.Empty } });
			routes.MapPageRoute("ForgotPassword", "ForgotPassword", "~/UL/ForgotPassword.aspx");
			routes.MapPageRoute("GuestRegistration", "GuestRegistration", "~/UL/GuestRegistration.aspx");
			routes.MapPageRoute("Login", "Login", "~/UL/Login.aspx");
			routes.MapPageRoute("Logout", "Logout", "~/UL/Logout.aspx");
			routes.MapPageRoute("Payment", "Payment", "~/UL/Payment.aspx");
			routes.MapPageRoute("PaymentConfirmation", "PaymentConfirmation", "~/UL/PaymentConfirmation.aspx");
			routes.MapPageRoute("PaymentResponse", "PaymentResponse", "~/UL/PaymentResponse.aspx");
			routes.MapPageRoute("Products", "Products", "~/UL/Products.aspx");
			routes.MapPageRoute("PurchaseHistory", "PurchaseHistory", "~/UL/PurchaseHistory.aspx");
			routes.MapPageRoute("Registration", "Registration", "~/UL/Registration.aspx");
			routes.MapPageRoute("SingleProductPage", "SingleProductPage", "~/UL/SingleProductPage.aspx");
            routes.MapPageRoute("SuccessPage",
                "SuccessPage/{status}",
                "~/UL/SuccessPage.aspx", false,
                new RouteValueDictionary { { "status", string.Empty } });
            routes.MapPageRoute("ViewSingleOrder", "ViewSingleOrder", "~/UL/ViewSingleOrder.aspx");

        }
    }
}
