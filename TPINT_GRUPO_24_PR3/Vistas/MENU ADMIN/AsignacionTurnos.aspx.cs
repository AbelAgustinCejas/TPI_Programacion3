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

            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        private void CargarMedicos(int idEspecialidad)
        {
            ddlMedico.Items.Clear();

            ddlMedico.DataSource = new NegocioMedico().GetMedicosDDL();
            ddlMedico.DataTextField = "Medico";
            ddlMedico.DataValueField = "Legajo_MED";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
        protected void CargarHorarios()
        {
            ddlHorario.Items.Clear();

            if (ddlMedico.SelectedIndex == 0)
                return;

            if (Calendar1.SelectedDate == DateTime.MinValue)
                return;

            NegocioTurno negocio = new NegocioTurno();

            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);

            List<TimeSpan> horarios =
                negocio.ObtenerHorariosDisponibles(legajo, Calendar1.SelectedDate);

            foreach (TimeSpan hora in horarios)
            {
                ddlHorario.Items.Add(new ListItem(
                    hora.ToString(@"hh\:mm"),
                    hora.ToString(@"hh\:mm")));
            }
        }

        protected void gvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idPaciente = Convert.ToInt32(gvPaciente.SelectedDataKey.Value);
            ViewState["idPaciente"] = idPaciente;

            GridViewRow fila = gvPaciente.SelectedRow;

            lblDniResumen.Text = fila.Cells[1].Text;
            lblPacienteResumen.Text = fila.Cells[2].Text + " " + fila.Cells[3].Text;

            ActualizarResumen();
        }

        private void ActualizarResumen()
        {
            if (ddlEspecialidad.Items.Count > 0 && ddlEspecialidad.SelectedIndex >= 0)
                lblEspecialidadResumen.Text = ddlEspecialidad.SelectedItem.Text;
            else
                lblEspecialidadResumen.Text = "";

            if (ddlMedico.Items.Count > 0 && ddlMedico.SelectedIndex >= 0)
                lblMedicoResumen.Text = ddlMedico.SelectedItem.Text;
            else
                lblMedicoResumen.Text = "";

            if (Calendar1.SelectedDate != DateTime.MinValue)
                lblFechaResumen.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            else
                lblFechaResumen.Text = "";

            if (ddlHorario.Items.Count > 0 && ddlHorario.SelectedIndex >= 0)
                lblHorarioResumen.Text = ddlHorario.SelectedItem.Text;
            else
                lblHorarioResumen.Text = "";
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
                CargarHorarios();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ViewState["idPaciente"] == null)
            {
                lblMensaje.Text = "Debe seleccionar un paciente.";
                return;
            }

            if (ddlHorario.SelectedIndex == -1)
            {
                lblMensaje.Text = "Seleccione un horario.";
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);
            int idPaciente = Convert.ToInt32(ViewState["idPaciente"]);

            DateTime fecha = Calendar1.SelectedDate;

            TimeSpan hora = TimeSpan.Parse(ddlHorario.SelectedValue);

            bool agregado = negocio.ConfirmarTurno(
                legajo,
                idPaciente,
                fecha,
                hora);

            if (agregado)
            {
                lblMensaje.Text = "Turno registrado correctamente.";

                if (agregado)
                {
                    lblMensaje.Text = "Turno registrado correctamente.";

                    // Limpiar búsqueda
                    txtDNI.Text = "";

                    // Ocultar o vaciar el GridView
                    gvPaciente.DataSource = null;
                    gvPaciente.DataBind();

                    // limpiar ddl
                    ddlEspecialidad.SelectedIndex = 0;
                    ddlMedico.Items.Clear();
                    ddlHorario.Items.Clear();

                    // Limpiar calendario
                    Calendar1.SelectedDates.Clear();
                    Calendar1.SelectedDate = DateTime.MinValue;

                    // Limpiar ViewState
                    ViewState["idPaciente"] = null;

                    // Limpiar resumen
                    lblPacienteResumen.Text = "";
                    lblDniResumen.Text = "";
                    lblEspecialidadResumen.Text = "";
                    lblMedicoResumen.Text = "";
                    lblFechaResumen.Text = "";
                    lblHorarioResumen.Text = "";
                }

                ViewState["idPaciente"] = null;
            }
            else
            {
                lblMensaje.Text = "No se pudo registrar el turno.";
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            lblMensaje.Text = "";
            ddlHorario.Items.Clear();

            // No permitir fechas anteriores a hoy
            if (Calendar1.SelectedDate.Date < DateTime.Today)
            {
                lblMensaje.Text = "No puede seleccionar una fecha anterior al día de hoy.";
                return;
            }

            if (ddlMedico.SelectedIndex <= 0)
            {
                lblMensaje.Text = "Seleccione un médico.";
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);

            // Verificar si el médico atiende ese día
            if (!negocio.MedicoAtiendeEseDia(legajo, Calendar1.SelectedDate))
            {
                lblMensaje.Text = "El médico seleccionado no atiende ese día.";
                return;
            }

            CargarHorarios();

            if (ddlHorario.Items.Count == 0)
            {
                lblMensaje.Text = "No hay horarios disponibles para esa fecha.";
            }
        }

        protected void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            NegocioTurno negocio = new NegocioTurno();

            DataTable dt = negocio.BuscarTurnoPorDni(Convert.ToInt32(txtBuscarDni.Text));

            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró ningún turno.";
            }
        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["IdTurno"] = gvTurnos.DataKeys[gvTurnos.SelectedIndex].Value;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (ViewState["IdTurno"] == null)
            {
                lblMensaje.Text = "Seleccione un turno.";
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            bool eliminado = negocio.EliminarTurno(Convert.ToInt32(ViewState["IdTurno"]));

            if (eliminado)
            {
                lblMensaje.Text = "Turno eliminado correctamente.";

                gvTurnos.DataSource = null;
                gvTurnos.DataBind();

                txtBuscarDni.Text = "";

                ViewState["IdTurno"] = null;
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar el turno.";
            }
        }
    }
}