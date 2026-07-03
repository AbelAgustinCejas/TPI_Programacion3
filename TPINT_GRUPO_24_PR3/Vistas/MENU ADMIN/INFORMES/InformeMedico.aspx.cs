using System;
using System.Data;

namespace Vistas
{
    public partial class InformeMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Medico");
            dt.Columns.Add("Especialidad");
            dt.Columns.Add("Turnos");

            dt.Rows.Add("Ana Gómez", "Cardiología", "45");
            dt.Rows.Add("Carlos Díaz", "Pediatría", "40");
            dt.Rows.Add("Juan García", "Traumatología", "37");
            dt.Rows.Add("Marta Ruiz", "Dermatología", "34");
            dt.Rows.Add("Diego Castro", "Neurología", "31");
            dt.Rows.Add("Laura Fernández", "Oftalmología", "28");
            dt.Rows.Add("Pablo Torres", "Urología", "25");
            dt.Rows.Add("Sofía López", "Ginecología", "22");
            dt.Rows.Add("Martín Silva", "Endocrinología", "18");
            dt.Rows.Add("Carla Herrera", "Neumonología", "14");

            gvMedicos.DataSource = dt;
            gvMedicos.DataBind();

            lblTotal.Text =
                "Total de turnos: 294";

            lblPromedio.Text =
                "Promedio por médico: 29,4";

            lblMayor.Text =
                "Médico con más turnos: Ana Gómez (45)";

            lblMenor.Text =
                "Médico con menos turnos: Carla Herrera (14)";
        }
    }
}