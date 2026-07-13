using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuarioIngresado.Text = Session["NombreUsuario"].ToString();
                CargarEspecialidades();
                LimpiarResumen();
            }
        }

        private void CargarEspecialidades()
        {
            ddlEspecialidad.Items.Clear();
            ddlEspecialidad.DataSource = new NegocioInforme().GetTablaEspecialidad();
            ddlEspecialidad.DataTextField = "Descripcion_ESP";
            ddlEspecialidad.DataValueField = "IdEspecialidad_ESP";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("Todas las especialidades", "0"));
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            gvInforme.PageIndex = 0;
            GenerarInforme(true);
        }

        private void GenerarInforme(bool mostrarResumen)
        {
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue); /// OBTIENE FECHAS INGRESADAS
            DateTime fechaDesde = Convert.ToDateTime(txtDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtHasta.Text);

            DataTable tabla = new NegocioInforme().InformeTurnosEspecialidad(
                idEspecialidad,
                fechaDesde,
                fechaHasta,
                out int totalTurnos,
                out string especialidadMayor,
                out int cantidadMayor,
                out string especialidadMenor,
                out int cantidadMenor);

            gvInforme.DataSource = tabla;
            gvInforme.DataBind();

            if (mostrarResumen && idEspecialidad == 0)
            {
                lblTotal.Text = "Total de turnos: " + totalTurnos;

                if (tabla.Rows.Count > 0)
                {
                    lblMayor.Text = "Especialidad con más turnos: " + especialidadMayor + " (" + cantidadMayor + ")";
                    lblMenor.Text = "Especialidad con menos turnos: " + especialidadMenor + " (" + cantidadMenor + ")";
                }
                else
                {
                    lblMayor.Text = "Especialidad con más turnos: Sin datos";
                    lblMenor.Text = "Especialidad con menos turnos: Sin datos";
                }

                divResumen.Visible = true;
            }
            else if (mostrarResumen)
            {
                LimpiarResumen();
            }
        }

        private void LimpiarResumen()
        {
            lblTotal.Text = "";
            lblMayor.Text = "";
            lblMenor.Text = "";
            divResumen.Visible = false;
        }

        protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInforme.PageIndex = e.NewPageIndex;
            GenerarInforme(false);
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/MenuAdmin.aspx");
        }
    }
}
