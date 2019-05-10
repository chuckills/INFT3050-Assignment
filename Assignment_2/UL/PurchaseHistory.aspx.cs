using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        List<String> purchaseList;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Stores placeholder values in session as demonstration
            purchaseList = Session["PurchaseList"] as List<String>;
            if (purchaseList == null)
            {
                purchaseList = new List<String>()
                {
                    "9967 2019-04-12 BOS00001 XL $100",
                    "8087 2018-04-12 BOS00001 XL $95",
                    "6678 2017-04-12 BOS00001 XL $90",
                    "3585 2016-04-12 BOS00001 XL $90"
                };
                
                Session["PurchaseList"] = purchaseList;
            }
        }

        // Returns current purchase history information
        public List<String> GetPurchaseHistory()
        {
            return purchaseList;
        }
    }
}