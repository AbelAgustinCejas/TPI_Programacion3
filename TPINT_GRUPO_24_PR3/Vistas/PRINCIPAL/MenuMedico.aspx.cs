using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuMedico : System.Web.UI.Page
    {
        NegocioTurno negocio = new NegocioTurno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblUsuario.Text = Session["NombreUsuario"].ToString();
                Session["Filtros"] = "Pendientes";
                CargarTurnosPendientes();
            }
        }

        private void CargarTurnosPendientes()
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

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
        private void CargarTurnosHistorial() /// CARGAR TURNOS Historial
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

            DataTable tabla = negocio.ObtenerTurnosHistorial(usuario);

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

        private void BuscarTurnos(string busqueda) /// BUSCAR TURNOS POR NOMBRE O APELLIDO
        {
            int usuario = Convert.ToInt32(Session["IdUsuario"]);

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

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs evento) /// ACTUALIZAR ASISTENCIA DE TURNOS
        {
            if (evento.CommandName == "Presente" || evento.CommandName == "Ausente")
            {
                int fila = Convert.ToInt32(evento.CommandArgument); ///CONVERTIMOS A INT EL ARGUMENTO DEL COMANDO
                int idTurno = Convert.ToInt32(gvTurnos.DataKeys[fila].Value); ///

                bool asistencia = (evento.CommandName == "Presente"); /// PREGUNTAMOS SI ES PRESENTE Y SE GUARDA TRUE

                if (negocio.ActualizarAsistencia(idTurno, asistencia))
                {
                    lblMensaje.Text = "Asistencia actualizada!";

                    Session["Filtros"] = "Pendientes";
                    CargarTurnosPendientes();
                }
                else
                {
                    lblMensaje.Text = "Error al actualizar asistencia!";
                }
            }
        }


        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e) /// PAGINACION DE GRILLA
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            string filtro = Session["Filtros"].ToString();

            switch (filtro)
            {
                case "Buscar":
                    BuscarTurnos(Session["Busqueda"].ToString());
                    break;

                case "Historial":
                    CargarTurnosHistorial();
                    break;

                default:
                    CargarTurnosPendientes();
                    break;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) 
        {
            Session["Filtros"] = "Buscar";
            Session["Busqueda"] = txtBuscar.Text.Trim();
            lblMensaje.Text = "";
            string busqueda = txtBuscar.Text;
            BuscarTurnos(busqueda);
            txtBuscar.Text = "";
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            Session["Filtros"] = "Pendientes";
            lblMensaje.Text = "";
            CargarTurnosPendientes();
            txtBuscar.Text = "";
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Session["Filtros"] = "Historial";
            lblMensaje.Text = "";
            CargarTurnosHistorial();
            txtBuscar.Text = "";
        }

        protected void btnLogout_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/Login.aspx");

        }
    }
}