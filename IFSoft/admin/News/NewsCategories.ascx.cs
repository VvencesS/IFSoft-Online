using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Insert(txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else //update
            {
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Update(int.Parse(hdCategoryID.Value), txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
        }

        protected void rbtNewsCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            switch (e.CommandName.ToString())
            {
                case "update":
                    dt = _news.GetListByCateID(int.Parse(e.CommandArgument.ToString()));

                    if (dt.Rows.Count > 0)
                    {
                        //Thao tác update
                        txtCategoryName.Text = dt.Rows[0]["vName"].ToString();
                        txtOrder.Text = dt.Rows[0]["vOrder"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;

                        hdCategoryID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";

                        mul.ActiveViewIndex = 1;
                    }
                    break;
                case "delete":
                    dt = _news.GetListByCateID(int.Parse(e.CommandArgument.ToString()));

                    if(dt.Rows.Count > 0)
                    {
                        //Thao tác xóa
                        _news.Delete(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }
    }
}