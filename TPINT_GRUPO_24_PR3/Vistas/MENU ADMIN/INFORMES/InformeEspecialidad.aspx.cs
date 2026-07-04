using System;
using Entidades;
using Negocio;
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

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
           
            NegocioInforme negocio = new NegocioInforme();
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            DataTable dt = negocio.InformeTurnosEspecialidad(idEspecialidad);

            gvInforme.DataSource = dt;
            gvInforme.DataBind();

            MostrarResumen(dt);
        }
        private void MostrarResumen(DataTable dt)
        {
            int total = 0;

            string mayor = "";
            string menor = "";

            int cantMayor = 0;
            int cantMenor = 999999;

            foreach (DataRow fila in dt.Rows)
            {
                int cantidad = Convert.ToInt32(fila["Cantidad"]);

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

            lblMayor.Text = "Especialidad con más turnos: " +
                            mayor + " (" + cantMayor + ")";

            lblMenor.Text = "Especialidad con menos turnos: " +
                            menor + " (" + cantMenor + ")";
        }
    }
}