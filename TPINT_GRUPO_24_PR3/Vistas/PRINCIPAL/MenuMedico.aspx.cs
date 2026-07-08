using Entidades;
using Negocio;
using System;
using System.Data;
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
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.ObtenerTablaTurnos(usuario);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla == null && tabla.Rows.Count <= 0)
            {
                lblMensaje.Text = "No hay registros";
            }
        }

        private void CargarTurnos(string busqueda)
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.ObtenerTablaTurnos(usuario, busqueda);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla == null && tabla.Rows.Count <= 0)
            {
                lblMensaje.Text = "No hay registros";
            }
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs evento)
        {
            if (evento.CommandName == "Presente" || evento.CommandName == "Ausente")
            {
                int fila = Convert.ToInt32(evento.CommandArgument);
                int idTurno = Convert.ToInt32(gvTurnos.DataKeys[fila].Value);

                bool asistencia = (evento.CommandName == "Presente");

                NegocioTurno negocio = new NegocioTurno();

                if (negocio.ActualizarAsistencia(idTurno, asistencia))
                {
                    lblMensaje.Text = "Asistencia actualizada";

                    int usuario = Convert.ToInt32(Session["IdUsuario"]);

                    gvTurnos.DataSource = negocio.ObtenerTablaTurnos(usuario);
                    gvTurnos.DataBind();
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar asistencia";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/Login.aspx");
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            CargarTurnos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            CargarTurnos(busqueda);
            txtBuscar.Text = "";
        }
    }
}