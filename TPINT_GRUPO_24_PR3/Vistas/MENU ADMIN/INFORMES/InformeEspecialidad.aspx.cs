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
                CargarEspecialidades();
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

            NegocioInforme negocio = new NegocioInforme();
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            DataTable dataTable = negocio.InformeTurnosEspecialidad(idEspecialidad);

            gvInforme.DataSource = dataTable;
            gvInforme.DataBind();

            if (Convert.ToInt32(ddlEspecialidad.SelectedValue) == 0)
            {
                MostrarResumen(dataTable);
                divResumen.Visible = true;
            }
            else
            {
                divResumen.Visible = false;
            }
        }
        private void MostrarResumen(DataTable dataTable)
        {
            int total = 0;

            string mayor = "";
            string menor = "";

            int cantMayor = 0;
            int cantMenor = 0;

            bool primerCiclo = true;

            foreach (DataRow fila in dataTable.Rows)
            {
                int cantidad = Convert.ToInt32(fila["Cantidad"]);

                if (primerCiclo)
                {
                    cantMayor = cantidad;
                    cantMenor = cantidad;
                    primerCiclo = false;
                }

                total += cantidad;

                if (cantidad > cantMayor)
                {
                    cantMayor = cantidad;
                    mayor = fila["Especialidad"].ToString();
                }

                if (cantidad < cantMenor)
                {
                    cantMenor = cantidad;
                    menor = fila["Especialidad"].ToString();
                }
            }

            lblTotal.Text = "Total de turnos: " + total;

            lblMayor.Text = "Especialidad con más turnos: " + mayor + " (" + cantMayor + ")";

            lblMenor.Text = "Especialidad con menos turnos: " + menor + " (" + cantMenor + ")";
        }

        protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInforme.PageIndex = e.NewPageIndex;

            NegocioInforme negocio = new NegocioInforme();
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            DataTable dataTable = negocio.InformeTurnosEspecialidad(idEspecialidad);

            gvInforme.DataSource = dataTable;
            gvInforme.DataBind();
        }
    }
}