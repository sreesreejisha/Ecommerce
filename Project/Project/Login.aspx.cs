﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Log_id) from LoginTab where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string i = obj.Fn_Exescalar(s);
            int ci = Convert.ToInt32(i);
            if (ci == 1)
            {
                string iid = "select Log_id from LoginTab where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string logid = obj.Fn_Exescalar(iid);
                string d = "select Usertype from LoginTab where Log_id=" + logid + "";
                string c = obj.Fn_Exescalar(d);
                if (c == "User")
                {
                    Response.Redirect("WebForm1.aspx");
                }
                else if (c == "Admin")
                {
                    Response.Redirect("Category.aspx");
                }
            }
        }
    }
}