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
                DesabilitarOpciones();
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
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }

        private void CargarMedicos(int idEspecialidad)
        {
            ddlMedico.Items.Clear();

            ddlMedico.DataSource = new NegocioMedico().GetTablaMedicosPorEspecialidad(idEspecialidad);
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "Legajo_MED";
            ddlMedico.DataBind();

            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
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

            List<TimeSpan> horarios = negocio.ObtenerHorariosDisponibles(legajo, Calendar1.SelectedDate);

            foreach (TimeSpan hora in horarios)
            {
                ddlHorario.Items.Add(new ListItem( hora.ToString(@"hh\:mm"), hora.ToString(@"hh\:mm")));
            }
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

            if (ddlHorario.Items.Count > 0)
                lblHorarioResumen.Text = ddlHorario.SelectedItem.Text;
            else
                lblHorarioResumen.Text = "";
        }

        private void DesabilitarOpciones()
        {
            ddlMedico.Enabled = false;
            ddlEspecialidad.Enabled = false;
            Calendar1.Enabled = false;
            ddlHorario.Enabled = false;
        }

        private void HabilitarOpciones()
        {
            ddlMedico.Enabled = true;
            ddlEspecialidad.Enabled = true;
            Calendar1.Enabled = true;
            ddlHorario.Enabled = true;
        }

        private void LimpiarFormulario()
        {
            lblMensaje.Text = "";

            gvPaciente.Visible = false;
            gvTurnos.Visible = false;

            lblPacienteResumen.Text = "Pendiente";
            lblDniResumen.Text = "Pendiente";
            lblEspecialidadResumen.Text = "Pendiente";
            lblMedicoResumen.Text = "Pendiente";
            lblFechaResumen.Text = "Pendiente";
            lblHorarioResumen.Text = "Pendiente";

            DesabilitarOpciones();
        }

        protected void gvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idPaciente = Convert.ToInt32(gvPaciente.SelectedDataKey.Value);
            Session["idPaciente"] = idPaciente;

            GridViewRow fila = gvPaciente.SelectedRow;

            lblDniResumen.Text = fila.Cells[1].Text;
            lblPacienteResumen.Text = fila.Cells[2].Text + " " + fila.Cells[3].Text;

            HabilitarOpciones();
            ActualizarResumen();
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";

            if (string.IsNullOrWhiteSpace(txtPacienteDNI.Text))
            {
                lblMensaje.Text = "Ingrese un DNI.";
                gvPaciente.Visible = false;
                return;
            }

            NegocioPaciente negocio = new NegocioPaciente();
            DataTable dt = negocio.BuscarPacientePorDni(txtPacienteDNI.Text.Trim());

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
            if (ddlEspecialidad.SelectedValue != "-1")
            {
                CargarMedicos(Convert.ToInt32(ddlEspecialidad.SelectedValue));
                ActualizarResumen();
            }
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMedico.SelectedValue != "-1")
            {
                CargarHorarios();
                ActualizarResumen();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["idPaciente"] == null)
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
            int idPaciente = Convert.ToInt32(Session["idPaciente"]);

            DateTime fecha = Calendar1.SelectedDate;

            TimeSpan hora = TimeSpan.Parse(ddlHorario.SelectedValue);

            bool agregado = negocio.ConfirmarTurno(legajo, idPaciente, fecha, hora);

            if (agregado)
            {
                lblMensaje.Text = "Turno registrado correctamente.";

                // Limpiar búsqueda
                txtPacienteDNI.Text = "";

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

                // Limpiar resumen
                lblPacienteResumen.Text = "";
                lblDniResumen.Text = "";
                lblEspecialidadResumen.Text = "";
                lblMedicoResumen.Text = "";
                lblFechaResumen.Text = "";
                lblHorarioResumen.Text = "";

                // Limpiar Session
                Session["idPaciente"] = null;
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

            ActualizarResumen();
        }

        protected void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPacienteDNI.Text))
            {
                lblMensaje.Text = "Ingrese un DNI.";
                gvPaciente.Visible = false;
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            DataTable dt = negocio.BuscarTurnoPorDni(Convert.ToInt32(txtTurnoDNI.Text));

            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró ningún turno.";
            }

            btnEliminarTurno.Enabled = false;
        }

        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdTurno"] = gvTurnos.DataKeys[gvTurnos.SelectedIndex].Value;
            btnEliminarTurno.Enabled = true;

        }


        protected void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (Session["IdTurno"] == null)
            {
                lblMensaje.Text = "Seleccione un turno.";
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            bool eliminado = negocio.EliminarTurno(Convert.ToInt32(Session["IdTurno"]));

            if (eliminado)
            {
                lblMensaje.Text = "Turno eliminado correctamente.";

                gvTurnos.DataSource = null;
                gvTurnos.DataBind();

                txtTurnoDNI.Text = "";

                Session["IdTurno"] = null;
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar el turno.";
            }
        }

        protected void ddlHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;

            NegocioTurno negocio = new NegocioTurno();

            DataTable dataTable = negocio.BuscarTurnoPorDni(Convert.ToInt32(txtTurnoDNI.Text));

            gvTurnos.DataSource = dataTable;
            gvTurnos.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}