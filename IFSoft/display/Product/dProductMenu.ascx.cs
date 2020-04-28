using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IFSOFT.Dal;

namespace IFSoft.display.Product
{
    public partial class dProductMenu : System.Web.UI.UserControl
    {
        clsProduct _product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProduct();
            }
        }
        void LoadProduct()
        {
            DataTable dt = new DataTable();
            dt = _product.GetListProductCategories();
            if (dt.Rows.Count > 0)
            {
                rptProductList.DataSource = dt;
                rptProductList.DataBind();
            }
        }
    }
}