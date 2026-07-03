using System;
using System.Data;

namespace Vistas
{
    public partial class InformeAsistencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            lblTotal.Text = "Total de turnos: 10";
            lblPresentes.Text = "Presentes: 7 (70%)";
            lblAusentes.Text = "Ausentes: 3 (30%)";

            DataTable dt = new DataTable();

            dt.Columns.Add("Fecha");
            dt.Columns.Add("Paciente");
            dt.Columns.Add("Medico");
            dt.Columns.Add("Estado");

            dt.Rows.Add("01/06/2026", "Juan Pérez", "Ana Gómez", "Presente");
            dt.Rows.Add("02/06/2026", "María López", "Carlos Díaz", "Presente");
            dt.Rows.Add("03/06/2026", "Pedro Fernández", "Ana Gómez", "Ausente");
            dt.Rows.Add("04/06/2026", "Sofía Martínez", "Juan García", "Presente");
            dt.Rows.Add("05/06/2026", "Lucas Ruiz", "Carlos Díaz", "Ausente");
            dt.Rows.Add("06/06/2026", "Carla Torres", "Ana Gómez", "Presente");
            dt.Rows.Add("07/06/2026", "Martín Rojas", "Juan García", "Presente");
            dt.Rows.Add("08/06/2026", "Laura Silva", "Carlos Díaz", "Presente");
            dt.Rows.Add("09/06/2026", "Diego Castro", "Ana Gómez", "Ausente");
            dt.Rows.Add("10/06/2026", "Paula Herrera", "Juan García", "Presente");

            gvAsistencia.DataSource = dt;
            gvAsistencia.DataBind();
        }
    }
}