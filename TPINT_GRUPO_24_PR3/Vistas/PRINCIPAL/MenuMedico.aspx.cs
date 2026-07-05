using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblUsuario.Text = Session["NombreBienvenida"].ToString();
                CargarTurnos();
            }
        }

        private void CargarTurnos()
        {
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.GetTablaTurnos(idUsuario);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla != null && tabla.Rows.Count > 0)
            {

            }
            else
            {
                lblMensaje.Text = "No hay registros";
            }
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Presente" || e.CommandName == "Ausente")
            {
                int fila = Convert.ToInt32(e.CommandArgument);
                int idTurno = Convert.ToInt32(gvTurnos.DataKeys[fila].Value);

                bool asistencia = (e.CommandName == "Presente");

                NegocioTurno negocio = new NegocioTurno();

                if (negocio.ActualizarAsistencia(idTurno, asistencia))
                {
                    lblMensaje.Text = "Asistencia actualizada correctamente.";

                    int idUsuario = Convert.ToInt32(Session["IdUsuario"]);

                    gvTurnos.DataSource = negocio.GetTablaTurnos(idUsuario);
                    gvTurnos.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No se pudo actualizar la asistencia.";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/Login.aspx");
        }
    }
}