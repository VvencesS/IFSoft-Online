﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSoft.admin.Product
{
    public partial class ProductControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Adminitrator.aspx");
            }
            string fs = Request["fs"];
            switch (fs)
            {
                case "des":
                    Controls.Add(LoadControl("ProductDetail.ascx"));
                    break;
                default:
                    Controls.Add(LoadControl("ProductCategories.ascx"));
                    break;
            }
        }
    }
}