﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTradex.UI.Pages.Investor
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ex = Request.QueryString["ex"];
            lblMsg.Text = ex;

        }
    }
}