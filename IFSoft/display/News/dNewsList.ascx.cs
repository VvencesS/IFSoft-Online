using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
using System.Data;
using System.Data.SqlClient;

namespace IFSoft.display.News
{
    public partial class dNewsList : System.Web.UI.UserControl
    {
        clsNews _news = new clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadList();
            }
        }
        void LoadList()
        {
            rptNewsDetails.DataSource = _news.GetNewsList();
            rptNewsDetails.DataBind();
        }
    }
}