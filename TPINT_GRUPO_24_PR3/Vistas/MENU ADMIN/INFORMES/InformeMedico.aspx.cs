using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class InformeMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuarioIngresado.Text = Session["NombreBienvenida"].ToString();
                CargarMedicos();
                LimpiarResumen();
            }
        }

        private void CargarMedicos()
        {
            ddlMedicos.Items.Clear();
            ddlMedicos.DataSource = new NegocioInforme().GetTablaMedico();
            ddlMedicos.DataTextField = "Medico";
            ddlMedicos.DataValueField = "Legajo_MED";
            ddlMedicos.DataBind();
            ddlMedicos.Items.Insert(0, new ListItem("Todos los médicos", "0"));
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
            int legajo = Convert.ToInt32(ddlMedicos.SelectedValue);
            DateTime fechaDesde = Convert.ToDateTime(txtDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtHasta.Text);

            DataTable tabla = new NegocioInforme().InformeTurnosMedico(
                legajo,
                fechaDesde,
                fechaHasta,
                out int totalTurnos,
                out string medicoMayor,
                out int cantidadMayor,
                out string medicoMenor,
                out int cantidadMenor);

            gvInforme.DataSource = tabla;
            gvInforme.DataBind();

            if (mostrarResumen && legajo == 0)
            {
                lblTotal.Text = "Total de turnos: " + totalTurnos;

                if (tabla.Rows.Count > 0)
                {
                    lblMayor.Text = "Médico con más turnos: " + medicoMayor + " (" + cantidadMayor + ")";
                    lblMenor.Text = "Médico con menos turnos: " + medicoMenor + " (" + cantidadMenor + ")";
                }
                else
                {
                    lblMayor.Text = "Médico con más turnos: Sin datos";
                    lblMenor.Text = "Médico con menos turnos: Sin datos";
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
