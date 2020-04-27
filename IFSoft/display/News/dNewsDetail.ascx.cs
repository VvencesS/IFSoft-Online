using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IFSOFT.Dal;

namespace IFSoft.display.News
{
    public partial class dNewsDetail : System.Web.UI.UserControl
    {
        clsNews _news = new clsNews();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDetail();
            }
        }
        void LoadDetail()
        {
            string id = Request["id"];
            DataTable dt = new DataTable();
            dt = _news.GetNewsDetail(int.Parse(id));
            if (dt.Rows.Count > 0)
            {
                ltTitle.Text = dt.Rows[0]["vTitle"].ToString();
                ltDesc.Text = dt.Rows[0]["vDesc"].ToString();
                ltContent.Text = dt.Rows[0]["vContent"].ToString();
                ltAuthor.Text = dt.Rows[0]["vAuthor"].ToString();

                //Tin tức khác
                dt = _news.GetNewsDetailOrther(int.Parse(id));
                if (dt.Rows.Count > 0)
                {
                    rptNewsList.DataSource = dt;
                    rptNewsList.DataBind();
                }
            }
        }
    }
}