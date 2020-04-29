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
                    Controls.Add(LoadControl("display/news/dNewsControl.ascx"));
                    break;
                case "contact":
                    Controls.Add(LoadControl("display/Utilities/dcontact.ascx"));
                    break;
                case "product":
                    Controls.Add(LoadControl("display/Product/dProductControl.ascx"));
                    break;
                default:
                    Controls.Add(LoadControl("display/Utilities/dIndex.ascx"));
                    break;
            }
        }
    }
}