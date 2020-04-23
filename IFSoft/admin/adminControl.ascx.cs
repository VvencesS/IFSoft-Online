using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSoft.admin
{
    public partial class AdminControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu chưa login
            if (Session["username"] == null)
            {
                Response.Redirect("administrator.aspx");
            }

            //Đã login
            string s = Request["f"];
            switch (s) 
            {
                case "news":
                    plLoad.Controls.Add(LoadControl("News/NewsControl.ascx"));
                    break;
                case "product":
                    plLoad.Controls.Add(LoadControl("Product/ProductControl.ascx"));
                    break;
                case "user":
                    plLoad.Controls.Add(LoadControl("User/UserControl.ascx"));
                    break;
            }
        }

        protected void lnkExit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/Adminitrator.aspx");
        }
    }
}