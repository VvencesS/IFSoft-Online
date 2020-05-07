using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace IFSoft.display.Product
{
    public partial class dProductCart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable dtCart = (DataTable)Session["cart"];
                rptProductCart.DataSource = dtCart;
                rptProductCart.DataBind();

                //Tính tổng tiền
                float total = 0;
                for(int i = 0; i < dtCart.Rows.Count; i++)
                {
                    total += Convert.ToSingle(dtCart.Rows[i]["Money"]);
                }
                ltTotal.Text = string.Format("{0:N0}", total);
            }
        }
    }
}