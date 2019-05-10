using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Assignment_2
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                            "~/UL/Scripts/WebForms/WebForms.js",
                            "~/UL/Scripts/WebForms/WebUIValidation.js",
                            "~/UL/Scripts/WebForms/MenuStandards.js",
                            "~/UL/Scripts/WebForms/Focus.js",
                            "~/UL/Scripts/WebForms/GridView.js",
                            "~/UL/Scripts/WebForms/DetailsView.js",
                            "~/UL/Scripts/WebForms/TreeView.js",
                            "~/UL/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/UL/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                    "~/UL/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                    "~/UL/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                    "~/UL/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/UL/Scripts/modernizr-*"));
        }
    }
}