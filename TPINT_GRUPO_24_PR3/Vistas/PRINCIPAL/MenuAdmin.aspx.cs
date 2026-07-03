using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuAdmin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/PRINCIPAL/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblUsuarioIngresado.Text = Session["NombreBienvenida"].ToString();
            }
        }

        protected void btnGP_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/GestionPacientes.aspx");
        }
        protected void btnGM_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/GestionMedicos.aspx");
        }

        protected void btnAT_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/AsignacionTurnos.aspx");
        }

        protected void btnInformes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/Informes.aspx");
        }
    }
}