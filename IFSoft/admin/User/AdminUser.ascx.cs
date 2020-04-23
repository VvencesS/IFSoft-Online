﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFSOFT.Dal;

namespace IFSoft.admin.User
{
    public partial class AdminUser : System.Web.UI.UserControl
    {
        clsAdminUser admin = new clsAdminUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                bool active = chkActive.Checked ? true : false;
                admin.Insert(txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtFullName.Text.Trim(), txtAddress.Text.Trim(), byte.Parse(drpRole.SelectedValue.ToString()), active);
                Response.Redirect(Request.Url.ToString());
            }
        }
    }
}