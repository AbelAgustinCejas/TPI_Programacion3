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
                lblUsuarioIngresado.Text = Session["NombreUsuario"].ToString();
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

        protected void btnInformeEspecialidad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/INFORMES/InformeEspecialidad.aspx");
        }

        protected void btnInformeAsistencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/INFORMES/InformeAsistencia.aspx");
        }

        protected void btnInformeMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MENU ADMIN/INFORMES/InformeMedico.aspx");
        }

        protected void btnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/PRINCIPAL/Login.aspx");
        }
    }
}