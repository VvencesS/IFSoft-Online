using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IFSOFT.Dal;

namespace IFSoft.admin.Product
{
    public partial class ProductCategories : System.Web.UI.UserControl
    {
        clsProduct _product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }

        }
        void LoadData()
        {
            rbtProductCategories.DataSource = _product.GetList();
            rbtProductCategories.DataBind();
        }

        protected void lnkAddNew_Click1(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
            mul.ActiveViewIndex = 1;
        }
        protected void msgDelete(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdInsert.Value == "insert")
            {
                if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _product.Insert(txtProductName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else //update
            {
                if (!string.IsNullOrEmpty(txtProductName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _product.Update(int.Parse(hdProID.Value), txtProductName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
        }

        protected void rbtProductCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            switch (e.CommandName.ToString())
            {
                case "update":
                    dt = _product.GetListByCategoryID(int.Parse(e.CommandArgument.ToString()));

                    if (dt.Rows.Count > 0)
                    {
                        //Thao tác update
                        txtProductName.Text = dt.Rows[0]["vName"].ToString();
                        txtOrder.Text = dt.Rows[0]["vOrder"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;

                        hdProID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";

                        mul.ActiveViewIndex = 1;
                    }
                    break;
                case "delete":
                    dt = _product.GetListByCategoryID(int.Parse(e.CommandArgument.ToString()));

                    if (dt.Rows.Count > 0)
                    {
                        //Thao tác xóa
                        _product.Delete(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }
    }
}