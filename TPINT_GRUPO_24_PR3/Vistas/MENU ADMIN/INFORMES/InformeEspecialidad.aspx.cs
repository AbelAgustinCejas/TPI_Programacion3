using System;
using System.Data;

namespace Vistas
{
    public partial class InformeEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Especialidad");
            dt.Columns.Add("Turnos");

            dt.Rows.Add("Cardiología", "42");
            dt.Rows.Add("Pediatría", "35");
            dt.Rows.Add("Traumatología", "28");
            dt.Rows.Add("Dermatología", "21");
            dt.Rows.Add("Neurología", "18");
            dt.Rows.Add("Oftalmología", "15");
            dt.Rows.Add("Urología", "13");
            dt.Rows.Add("Ginecología", "11");
            dt.Rows.Add("Endocrinología", "9");
            dt.Rows.Add("Neumonología", "7");

            gvEspecialidades.DataSource = dt;
            gvEspecialidades.DataBind();

            lblTotal.Text =
                "Total de turnos registrados: 199";

            lblMayor.Text =
                "Especialidad más solicitada: Cardiología (42)";

            lblMenor.Text =
                "Especialidad menos solicitada: Neumonología (7)";
        }
    }
}