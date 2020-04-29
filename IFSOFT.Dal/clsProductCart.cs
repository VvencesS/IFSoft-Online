using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace IFSOFT.Dal
{
    public class clsProductCart
    {
        clsProduct _pro = new clsProduct();
        static void ShoppingCart_CreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(int)); //ProDelID
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Money", typeof(float));

            System.Web.HttpContext.Current.Session["cart"] = dt;
        }
        public void ShoppingCart_AddCart(int PID, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                ShoppingCart_CreateCart();
                ShoppingCart_AddCart(PID, quantity);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = new clsProduct().GetListProductDetail_ByProDelID(PID);
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0]["vName"].ToString();
                    float price = float.Parse(dt.Rows[0]["vPrice"].ToString());
                    float money = price * quantity;

                    DataTable dtCart = new DataTable();
                    dtCart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

                    bool hdInsert = false;

                    for(int i = 0; i < dtCart.Rows.Count; i++)
                    {
                        if (dtCart.Rows[0]["PID"].ToString().Equals(PID)) //Nếu sản phẩm đã có trong giỏ
                        {
                            hdInsert = true;

                            quantity += Convert.ToInt32(dtCart.Rows[i]["Quantity"].ToString());
                            dtCart.Rows[i]["Quantity"] = quantity;
                            dtCart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtCart.Rows[0]["Price"]);

                            System.Web.HttpContext.Current.Session["cart"] = dtCart;
                            break;
                        }
                    }

                    if (hdInsert == false) 
                    { 
                        if (dtCart != null)
                        {
                            DataRow dr = dtCart.NewRow();

                            dr["PID"] = PID;
                            dr["Name"] = name;
                            dr["Quantity"] = quantity;
                            dr["Price"] = price;
                            dr["Money"] = money;

                            dtCart.Rows.Add(dr);
                            System.Web.HttpContext.Current.Session["cart"] = dtCart;
                        }
                    }
                }
            }
        }
    }
}
