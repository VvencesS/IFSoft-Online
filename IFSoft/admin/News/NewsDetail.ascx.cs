using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFSoft.admin.News
{
    public partial class NewsDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTest_Click(object sender, EventArgs e)
        {
            Response.Write(txtContent.Text);
        }
    }
}