using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;

namespace IFSoft.admin.News
{
    public partial class NewsDetail : System.Web.UI.UserControl
    {
        clsNews _news = new clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNewsDetailAll();
                LoadDataDropDownList();
                LoadDataDropDownList1();
            }
        }
        void LoadDataDropDownList()
        {
            drpNewsCategoy.DataSource = _news.GetList();
            drpNewsCategoy.DataValueField = "CateID";
            drpNewsCategoy.DataTextField = "vName";
            drpNewsCategoy.DataBind();
        }
        void LoadDataDropDownList1()
        {
            drpNewsCategory1.DataSource = _news.GetList();
            drpNewsCategory1.DataValueField = "CateID";
            drpNewsCategory1.DataTextField = "vName";
            drpNewsCategory1.DataBind();
        }
        void LoadNewsDetailAll()
        {
            rptNewsDetails.DataSource = _news.GetListNewsDetailAll();
            rptNewsDetails.DataBind();
        }
        void LoadNewsDetail()
        {
            rptNewsDetails.DataSource = _news.GetListNewsDetail(int.Parse(drpNewsCategory1.SelectedValue.ToString()));
            rptNewsDetails.DataBind();
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
                    if(fUp.PostedFile.ContentType.Equals("image/jpeg") 
                        || fUp.PostedFile.ContentType.Equals("image/pjpeg") 
                        || fUp.PostedFile.ContentType.Equals("image/x-png") 
                        || fUp.PostedFile.ContentType.Equals("image/png") 
                        || fUp.PostedFile.ContentType.Equals("image/gif") 
                        || fUp.PostedFile.ContentType.Equals("image/x-shockwave-flash"))
                    {
                        typefile = Path.GetExtension(fUp.FileName).ToLower();
                        file = Path.GetFileName(fUp.PostedFile.FileName);
                        file = fUp.FileName.Replace(file, "IFsoft" + DateTime.Now.Hour + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Second + typefile);
                        fUp.PostedFile.SaveAs(Server.MapPath("~/Images/") + file);
                    }
                }
            }

            //Kiểm tra image đã tồn tại
            if (!file.Equals(hdImage.Value))
            {
                if (!hdImage.Value.Equals(""))
                {
                    if(System.IO.File.Exists(Server.MapPath("~/Images/" + hdImage.Value)) == true)
                    {
                        System.IO.File.Delete(Server.MapPath("~/Images/" + hdImage.Value));
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                if (hdInsert.Value == "insert")
                {
                    //Thêm mới
                    bool active = chkActive.Checked ? true : false;
                    _news.InsertDetail(int.Parse(drpNewsCategoy.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, DateTime.Now, txtAuthor.Text.Trim(), active);
                }
                else
                {
                    //Cập nhật
                    bool active = chkActive.Checked ? true : false;
                    _news.UpdateDetail(int.Parse(hdDelID.Value.ToString()), int.Parse(drpNewsCategoy.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, txtAuthor.Text.Trim(), active);
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
        protected void rptNewsDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _news.GetListByDelID(int.Parse(e.CommandArgument.ToString()));
            switch (e.CommandName.ToString())
            {
                case "update":
                    if (dt.Rows.Count > 0)
                    {
                        drpNewsCategoy.SelectedValue = dt.Rows[0]["CateID"].ToString();
                        txtTitle.Text = dt.Rows[0]["vTitle"].ToString();
                        txtDesc.Text = dt.Rows[0]["vDesc"].ToString();
                        txtContent.Text = dt.Rows[0]["vContent"].ToString();
                        hdImage.Value = dt.Rows[0]["vImage"].ToString();
                        txtAuthor.Text = dt.Rows[0]["vAuthor"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;

                        hdDelID.Value = e.CommandArgument.ToString();
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
                        _news.DeleteDetail(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }

        protected void drpNewsCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNewsDetail();
        }
    }
}