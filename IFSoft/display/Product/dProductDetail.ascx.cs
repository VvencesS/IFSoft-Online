using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
using System.Data;
using System.Data.SqlClient;

namespace IFSoft.display.Product
{
    public partial class dProductDetail : System.Web.UI.UserControl
    {
        clsProduct _product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDetail();
            }
        }
        void LoadProductDetail()
        {
            DataTable dt = new DataTable();
            string id = Request["id"];
            dt = _product.GetProductDetailByProDelID(int.Parse(id));
            if (dt.Rows.Count > 0)
            {
                ltName.Text = dt.Rows[0]["vName"].ToString();
                ltImage.Text = "<img src='/Images/" + dt.Rows[0]["vImage"].ToString() + "' />";
                ltDesc.Text = dt.Rows[0]["vDesc"].ToString();
                ltPrice.Text = string.Format("{0:N0}", dt.Rows[0]["vPrice"].ToString());
                ltContent.Text = dt.Rows[0]["vContent"].ToString();
            }
        }
    }
}