using System;
using System.Collections.Generic;
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
                LoadDataDropDownList();
            }
        }
        void LoadDataDropDownList()
        {
            drpNewsCategoy.DataSource = _news.GetList();
            drpNewsCategoy.DataValueField = "CateID";
            drpNewsCategoy.DataTextField = "vName";
            drpNewsCategoy.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Upload image
            string typefile = "";
            string file = "";
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
                        fUp.PostedFile.SaveAs(Server.MapPath("/Images") + file);
                    }
                }
            }

            //Thêm mới
            if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                bool active = chkActive.Checked ? true : false;
                _news.InsertDetail(int.Parse(drpNewsCategoy.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, DateTime.Now, txtAuthor.Text.Trim(), active);
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
}