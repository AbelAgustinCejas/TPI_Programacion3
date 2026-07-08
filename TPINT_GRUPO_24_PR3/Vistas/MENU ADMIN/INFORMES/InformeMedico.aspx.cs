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
                CargarMedicos();
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
            NegocioInforme negocio = new NegocioInforme();

            int legajo = Convert.ToInt32(ddlMedicos.SelectedValue);

            DataTable tabla = negocio.InformeTurnosMedico(legajo);

            gvInforme.DataSource = tabla;
            gvInforme.DataBind();

            if(Convert.ToInt32(ddlMedicos.SelectedValue) == 0)
            {
                MostrarResumen(tabla);
                divResumen.Visible = true;
            }
            else
            {
                divResumen.Visible = false;
            }
        }
        private void MostrarResumen(DataTable tabla)
        {
            int totalTurnos = 0;

            string medicoMayor = "";
            string medicoMenor = "";

            int mayor = 0;
            int menor = 0;

            bool primerRegistro = true;

            foreach (DataRow fila in tabla.Rows)
            {
                int turnos = Convert.ToInt32(fila["Turnos"]);

                string medico = fila["Nombre"].ToString() + " " + fila["Apellido"].ToString();

                totalTurnos += turnos;

                if (primerRegistro)
                {
                    mayor = turnos;
                    menor = turnos;

                    medicoMayor = medico;
                    medicoMenor = medico;

                    primerRegistro = false;
                }

                if (turnos > mayor)
                {
                    mayor = turnos;
                    medicoMayor = medico;
                }

                if (turnos < menor)
                {
                    menor = turnos;
                    medicoMenor = medico;
                }
            }

            lblTotal.Text = "Total de turnos: " + totalTurnos;

            lblMayor.Text = "Médico con más turnos: " + medicoMayor + " (" + mayor + ")";

            lblMenor.Text = "Médico con menos turnos: " + medicoMenor + " (" + menor + ")";
        }

        protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInforme.PageIndex = e.NewPageIndex;

            NegocioInforme negocio = new NegocioInforme();

            int legajo = Convert.ToInt32(ddlMedicos.SelectedValue);

            DataTable tabla = negocio.InformeTurnosMedico(legajo);

            gvInforme.DataSource = tabla;
            gvInforme.DataBind();
        }
    }
}