using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminPostageOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (!IsPostBack)
	        {
		        lsvPostage.DataSource = BLShipping.getShippingTable();
		        lsvPostage.DataBind();
	        }
        }

        // Adds postage option to currently available options
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //postageList.Add(tbxMethodName.Text + ", " + tbxDescription.Text + ", " + tbxAvgTime.Text + ", " + "$" + tbxPrice.Text);

                BLShipping shipping = new BLShipping
                {
                    Method = tbxMethodName.Text,
                    Description = tbxDescription.Text,
                    Cost = Convert.ToDouble(tbxPrice.Text),
                    Wait = Convert.ToInt32(tbxAvgTime.Text)
                };

                BLShipping.addShipping(shipping);

                // Redirect to updated postage options
                Response.Redirect("~/UL/AdminPostageOptions");
            }
        }

        protected void cbxActive_CheckedChanged(object sender, EventArgs e)
        {
			ListViewItem item = (sender as CheckBox).NamingContainer as ListViewItem;
	        int index = Convert.ToInt32((item.FindControl("lblShipID") as Label).Text);
			BLShipping.toggleActive(index);
			lsvPostage.DataSource = BLShipping.getShippingTable();
			lsvPostage.DataBind();
		}
	}
}