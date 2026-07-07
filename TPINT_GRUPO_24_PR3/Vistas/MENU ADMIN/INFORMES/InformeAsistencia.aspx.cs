using Negocio;
using System;
using System.Data;

namespace Vistas
{
    public partial class InformeAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpiarResumen();
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            LimpiarResumen();

            DateTime fechaDesde = Convert.ToDateTime(txtDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtHasta.Text);

            DataTable tablaAsistencia = new NegocioInforme().InformeAsistencia(fechaDesde, fechaHasta, out int total, out int presentes, out int ausentes, out double porcentajeAsistencia);
            int pendientes = total - (presentes + ausentes);

            gvAsistencia.DataSource = tablaAsistencia;
            gvAsistencia.DataBind();

            lblTotal.Text = "Total de turnos: " + total;
            lblPresentes.Text = "Presentes: " + presentes;
            lblAusentes.Text = "Ausentes: " + ausentes;

            if (presentes + ausentes > 0)
            {
                lblPorcentajeAsistencia.Text = "Porcentaje de asistencia: " + porcentajeAsistencia.ToString("0.00") + "%";
            }
            else
            {
                lblPorcentajeAsistencia.Text = "Porcentaje de asistencia: Sin turnos evaluados";
            }

            lblPendientes.Text = "Turnos pendientes: " + pendientes;

        }

        void LimpiarResumen()
        {
            lblPresentes.Text = "";
            lblAusentes.Text = "";
            lblTotal.Text = "";
            lblPorcentajeAsistencia.Text = "";
        }
    }
}