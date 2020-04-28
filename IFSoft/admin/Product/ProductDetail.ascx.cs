using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IFSOFT.Dal;
using System.IO;

namespace IFSoft.admin.Product
{
    public partial class ProductDetail : System.Web.UI.UserControl
    {
        clsProduct _product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDetailAll();
                LoadDataDropDownList();
                LoadDataDropDownList1();
            }
        }
        void LoadDataDropDownList()
        {
            drpProductCategory.DataSource = _product.GetList();
            drpProductCategory.DataValueField = "ProID";
            drpProductCategory.DataTextField = "vName";
            drpProductCategory.DataBind();
        }
        void LoadDataDropDownList1()
        {
            drpProductCategory1.DataSource = _product.GetList();
            drpProductCategory1.DataValueField = "ProID";
            drpProductCategory1.DataTextField = "vName";
            drpProductCategory1.DataBind();
        }
        void LoadProductDetailAll()
        {
            rptProductDetails.DataSource = _product.GetListProductDetailAll();
            rptProductDetails.DataBind();
        }
        void LoadProductDetail()
        {
            rptProductDetails.DataSource = _product.GetListProductDetail(int.Parse(drpProductCategory1.SelectedValue.ToString()));
            rptProductDetails.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Upload image
            string typefile = "";
            string file = hdImage.Value; //Nếu file chưa có thì sẽ là rỗng

            if (fUp.FileName.Length > 0)
            {
                if (fUp.PostedFile.ContentLength < 5000000)
                {
                    if (fUp.PostedFile.ContentType.Equals("image/jpeg")
                        || fUp.PostedFile.ContentType.Equals("image/pjpeg")
                        || fUp.PostedFile.ContentType.Equals("image/x-png")
                        || fUp.PostedFile.ContentType.Equals("image/png")
                        || fUp.PostedFile.ContentType.Equals("image/gif")
                        || fUp.PostedFile.ContentType.Equals("image/x-shockwave-flash"))
                    {
                        typefile = Path.GetExtension(fUp.FileName).ToLower();
                        file = Path.GetFileName(fUp.PostedFile.FileName);
                        file = fUp.FileName.Replace(file, "IFsoft_ProductImage" + DateTime.Now.Hour + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Second + typefile);
                        fUp.PostedFile.SaveAs(Server.MapPath("~/Images/") + file);
                    }
                }
            }

            //Kiểm tra image đã tồn tại
            if (!file.Equals(hdImage.Value))
            {
                if (!hdImage.Value.Equals(""))
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Images/" + hdImage.Value)) == true)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + hdImage.Value));
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                if (hdInsert.Value == "insert")
                {
                    //Thêm mới
                    bool active = chkActive.Checked ? true : false;
                    _product.InsertProductDetail(int.Parse(drpProductCategory.SelectedValue.ToString()), 
                        int.Parse(txtCode.Text.Trim()), txtName.Text.Trim(), txtDesc.Text.Trim(), 
                        txtContent.Text.Trim(), file, int.Parse(txtQuantity.Text.Trim()), 
                        float.Parse(txtPrice.Text.Trim()), DateTime.Now, txtView.Text.Trim(), active);
                }
                else
                {
                    //Cập nhật
                    bool active = chkActive.Checked ? true : false;
                    _product.UpdateProductDetail(int.Parse(hdProDelID.Value.ToString()), 
                        int.Parse(drpProductCategory.SelectedValue.ToString()),
                        int.Parse(txtCode.Text.Trim()), txtName.Text.Trim(), txtDesc.Text.Trim(),
                        txtContent.Text.Trim(), file, int.Parse(txtQuantity.Text.Trim()),
                        float.Parse(txtPrice.Text.Trim()), DateTime.Now, txtView.Text.Trim(), active);
                }
                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
            mul.ActiveViewIndex = 1;
        }
        protected void msgDelete(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }

        protected void rptProductDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _product.GetListProductDetail_ByProDelID(int.Parse(e.CommandArgument.ToString()));
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        drpProductCategory.SelectedValue = dt.Rows[0]["ProID"].ToString();
                        txtCode.Text = dt.Rows[0]["vCode"].ToString();
                        txtName.Text = dt.Rows[0]["vName"].ToString();
                        txtDesc.Text = dt.Rows[0]["vDesc"].ToString();
                        txtContent.Text = dt.Rows[0]["vContent"].ToString();
                        hdImage.Value = dt.Rows[0]["vImage"].ToString();
                        txtQuantity.Text = dt.Rows[0]["iQuantity"].ToString();
                        txtPrice.Text = dt.Rows[0]["vPrice"].ToString();
                        txtView.Text = dt.Rows[0]["iView"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;

                        hdProDelID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";

                        mul.ActiveViewIndex = 1;
                    }
                    break;
                case "delete":
                    if (dt.Rows.Count > 0)
                    {
                        //Xóa hình ảnh project
                        if (System.IO.File.Exists(Server.MapPath("~/Images/" + dt.Rows[0]["vImage"])) == true)
                        {
                            System.IO.File.Delete(Server.MapPath("~/Images/" + dt.Rows[0]["vImage"]));
                        }

                        //Xóa dữ liệu trong csdl
                        _product.DeleteProductDetail(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }

        protected void drpProductCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductDetail();
        }
    }
}