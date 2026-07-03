using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class AsignacionTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
                ActualizarResumen();



            }
        }
        private void CargarEspecialidades()
        {
            ddlEspecialidad.Items.Clear();
            ddlEspecialidad.DataSource = new NegocioMedico().GetTablaEspecialidad();
            ddlEspecialidad.DataTextField = "Descripcion_ESP";
            ddlEspecialidad.DataValueField = "IdEspecialidad_ESP";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }
        private void CargarMedicos(int idEspecialidad)
        {
            ddlMedico.Items.Clear();

            ddlMedico.DataSource = new NegocioMedico().GetMedicosDDL();
            ddlMedico.DataTextField = "Medico";
            ddlMedico.DataValueField = "Legajo_MED";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }
        private void CargarHorarios(int legajo)
        {
            ddlHorario.Items.Clear();

            ddlHorario.DataSource = new NegocioMedico().ObtenerHorariosMedicoAsignacion(legajo);
            ddlHorario.DataTextField = "Horario";
            ddlHorario.DataValueField = "IdHorario_HM";
            ddlHorario.DataBind();

            ddlHorario.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }


        protected void gvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idPaciente = Convert.ToInt32(gvPaciente.SelectedDataKey.Value);

            GridViewRow fila = gvPaciente.SelectedRow;

            lblDniResumen.Text = fila.Cells[1].Text;
            lblPacienteResumen.Text = fila.Cells[2].Text + " " + fila.Cells[3].Text;

            ActualizarResumen();
        }

        private void ActualizarResumen()
        {
            lblEspecialidadResumen.Text = ddlEspecialidad.SelectedItem.Text;
            lblMedicoResumen.Text = ddlMedico.SelectedItem.Text;

            if (Calendar1.SelectedDate != DateTime.MinValue)
            {
                lblFechaResumen.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            }

            lblHorarioResumen.Text = ddlHorario.SelectedItem.Text;
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                lblMensaje.Text = "Ingrese un DNI.";
                gvPaciente.Visible = false;
                return;
            }

            NegocioPaciente negocio = new NegocioPaciente();
            DataTable dt = negocio.BuscarPacientePorDni(txtDNI.Text.Trim());

            if (dt.Rows.Count > 0)
            {
                gvPaciente.DataSource = dt;
                gvPaciente.DataBind();
                gvPaciente.Visible = true;
            }
            else
            {
                gvPaciente.DataSource = null;
                gvPaciente.DataBind();
                gvPaciente.Visible = false;
                lblMensaje.Text = "No se encontró ningún paciente.";
            }
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEspecialidad.SelectedValue != "0")
            {
                CargarMedicos(Convert.ToInt32(ddlEspecialidad.SelectedValue));
            }
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMedico.SelectedValue != "0")
            {
                CargarHorarios(Convert.ToInt32(ddlMedico.SelectedValue));
            }
        }

        protected void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            NegocioTurno negocio = new NegocioTurno();

            if (gvPaciente.SelectedIndex == -1)
            {
                lblMensaje.Text = "Seleccione un paciente.";
                return;
            }

            if (ddlMedico.SelectedIndex <= 0)
            {
                lblMensaje.Text = "Seleccione un médico.";
                return;
            }

            if (ddlHorario.SelectedIndex <= 0)
            {
                lblMensaje.Text = "Seleccione un horario.";
                return;
            }

            if (Calendar1.SelectedDate == DateTime.MinValue)
            {
                lblMensaje.Text = "Seleccione una fecha.";
                return;
            }

            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);

            int idPaciente = Convert.ToInt32(gvPaciente.SelectedDataKey.Value);

            DateTime fecha = Calendar1.SelectedDate;

            string horario = ddlHorario.SelectedItem.Text;

            TimeSpan hora = TimeSpan.Parse(horario.Split('-')[0].Trim());

            if (negocio.AgregarTurno(legajo, idPaciente, fecha, hora))
            {
                lblMensaje.Text = "Turno asignado correctamente.";
            }
            else
            {
                lblMensaje.Text = "No se pudo asignar el turno.";
            }
        }
    }
}