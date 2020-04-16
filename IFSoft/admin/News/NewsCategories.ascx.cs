using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
using System.Data.SqlClient;
using System.Configuration;

namespace IFSoft.admin.News
{
    public partial class NewsCategories : System.Web.UI.UserControl
    {
        clsNews _news = new IFSOFT.Dal.clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            rbtNewsCategories.DataSource = _news.GetList();
            rbtNewsCategories.DataBind();
        }
    }
}