using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSoft
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["f"])
            {
                case "news":
                    Controls.Add(LoadControl("display/news/dNewsList.ascx"));
                    break;
                case "contact":

                    break;
                default:

                    break;
            }
        }
    }
}