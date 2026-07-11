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
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("~/PRINCIPAL/Login.aspx");
                return;
            }

            if(!IsPostBack)
            {
                lblUsuario.Text = Session["NombreBienvenida"].ToString();
                Session["FiltroTurnos"] = "Pendientes";
                CargarTurnosPendientes();
            }
        }

        private void CargarTurnosPendientes()
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.ObtenerTurnosPendientes(usuario);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No hay turnos pendientes...";
            }
            else
            {
                lblMensaje.Text = "";
            }
        }
        private void CargarTurnosAnteriores()
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.ObtenerTurnosAnteriores(usuario);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No hay turnos en el historial...";
            }
            else
            {
                lblMensaje.Text = "";
            }
        }

        private void BuscarTurnos(string busqueda)
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            NegocioTurno negocio = new NegocioTurno();

            DataTable tabla = negocio.BuscarTurnos(usuario, busqueda);

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron turnos...";
            }
            else
            {
                lblMensaje.Text = "";
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
                    lblMensaje.Text = "Asistencia actualizada!";

                    Session["FiltroTurnos"] = "Pendientes";
                    CargarTurnosPendientes();
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar asistencia!";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/PRINCIPAL/Login.aspx");
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            string filtro = Session["FiltroTurnos"].ToString();

            switch (filtro)
            {
                case "Buscar":
                    BuscarTurnos(Session["Busqueda"].ToString());
                    break;

                case "Anteriores":
                    CargarTurnosAnteriores();
                    break;

                default:
                    CargarTurnosPendientes();
                    break;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["FiltroTurnos"] = "Buscar";
            Session["Busqueda"] = txtBuscar.Text.Trim();
            lblMensaje.Text = "";
            string busqueda = txtBuscar.Text;
            BuscarTurnos(busqueda);
            txtBuscar.Text = "";
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            Session["FiltroTurnos"] = "Pendientes";
            lblMensaje.Text = "";
            CargarTurnosPendientes();
            txtBuscar.Text = "";
        }

        protected void btnAnteriores_Click(object sender, EventArgs e)
        {
            Session["FiltroTurnos"] = "Anteriores";
            lblMensaje.Text = "";
            CargarTurnosAnteriores();
            txtBuscar.Text = "";
        }
    }
}