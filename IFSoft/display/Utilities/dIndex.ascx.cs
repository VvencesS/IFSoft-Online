using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IFSOFT.Dal;

namespace IFSoft.display.Utilities
{
    public partial class dIndex : System.Web.UI.UserControl
    {
        clsProduct _product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNewProduct();
                LoadPriceProduct();
            }
        }
        void LoadNewProduct()
        {
            DataTable dt = new DataTable();
            dt = _product.GetListNewProduct(4);
            if (dt.Rows.Count > 0)
            {
                rptNewProduct.DataSource = dt;
                rptNewProduct.DataBind();
            }
        }
        void LoadPriceProduct()
        {
            DataTable dt = new DataTable();
            dt = _product.GetListPriceProduct(4);
            if (dt.Rows.Count > 0)
            {
                rptPriceProduct.DataSource = dt;
                rptPriceProduct.DataBind();
            }
        }

        
    }
}