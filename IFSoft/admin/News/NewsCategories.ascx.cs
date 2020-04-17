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

        protected void lnkAddNew_Click1(object sender, EventArgs e)
        {
            mul.ActiveViewIndex = 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            {
                bool active = chkActive.Checked ? true : false;
                _news.Insert(txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
}