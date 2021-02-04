﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppDenuncias.model;

namespace WebAppDenuncias
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dataUser"] != null)
            {
                Usuario usuario = (Usuario)Session["dataUser"];
                lblUser.Text = usuario.nombre + " " + usuario.apellidoPaterno;
            } else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("dataUser");
            Response.Redirect("Login.aspx");

        }
    }
}