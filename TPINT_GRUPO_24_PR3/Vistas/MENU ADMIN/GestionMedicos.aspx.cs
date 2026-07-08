using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas.MENU_ADMIN
{
    public partial class GestionMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                CargarEspecialidades();
                CargarMedicosDDL();
                CargarDias();
                CargarHoras();
                // lblUsuarioIngresado.Text = Session["NombreBienvenida"].ToString();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            Medico medico = new Medico();

            medico.setDNI(txtDNI.Text.Trim());
            medico.setNombre(txtNombre.Text.Trim());
            medico.setApellido(txtApellido.Text.Trim());
            medico.setSexo(Convert.ToChar(ddlSexo.SelectedValue));
            medico.setNacionalidad(txtNacionalidad.Text.Trim());
            medico.setFechaNacimiento(Convert.ToDateTime(txtFechaNacimiento.Text));
            medico.setDireccion(txtDireccion.Text.Trim());
            medico.setEmail(txtEmail.Text.Trim());
            medico.setTelefono(txtTelefono.Text.Trim());
            medico.setIdEspecialidad(Convert.ToInt32(ddlEspecialidad.SelectedValue));
            medico.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            medico.setEstado(true);

            NegocioMedico negocio = new NegocioMedico();

            if (negocio.ExisteMedico(medico.getDNI()))
            {
                lblMensaje.Text = "Ya existe un médico con ese DNI.";
                return;
            }

            int legajo = negocio.AgregarMedico(medico);

            if (legajo > 0)
            {
                lblMensaje.Text = "Médico agregado correctamente. Número de Legajo: " + legajo;
                LimpiarFormulario();
            }
            else
            {
                lblMensaje.Text = "No se pudo agregar el médico.";
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);

            if (idProvincia == -1)
            {
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
                return;
            }

            CargarLocalidades(idProvincia);
        }

        private void CargarProvincias()
        {
            ddlProvincia.Items.Clear();
            ddlProvincia.DataSource = new NegocioProvincia().GetTablaProvincia();
            ddlProvincia.DataTextField = "Nombre_PRO";
            ddlProvincia.DataValueField = "IdProvincia_PRO";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }

        private void CargarLocalidades(int idProvincia)
        {
            ddlLocalidad.Items.Clear();
            ddlLocalidad.DataSource = new NegocioProvincia().GetTablaLocalidadPorProvincia(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_LOC";
            ddlLocalidad.DataValueField = "IdLocalidad_LOC";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
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

        private void LimpiarFormulario()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";

            ddlSexo.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));

            ddlEspecialidad.SelectedIndex = 0;
        }

        private void CargarMedicosDDL()
        {
            ddlMedicoHorario.Items.Clear();
            ddlMedicoUsuario.Items.Clear();

            DataTable tablaMedicos = new NegocioMedico().GetMedicosDDL();

            ddlMedicoHorario.DataSource = tablaMedicos;
            ddlMedicoHorario.DataTextField = "Medico";
            ddlMedicoHorario.DataValueField = "Legajo_MED";
            ddlMedicoHorario.DataBind();

            ddlMedicoUsuario.DataSource = tablaMedicos;
            ddlMedicoUsuario.DataTextField = "Medico";
            ddlMedicoUsuario.DataValueField = "Legajo_MED";
            ddlMedicoUsuario.DataBind();

            ddlMedicoHorario.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
            ddlMedicoUsuario.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
        }

        private void CargarDias()
        {
            ddlDias.Items.Clear();

            ddlDias.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
            ddlDias.Items.Add(new ListItem("Lunes", "1"));
            ddlDias.Items.Add(new ListItem("Martes", "2"));
            ddlDias.Items.Add(new ListItem("Miércoles", "3"));
            ddlDias.Items.Add(new ListItem("Jueves", "4"));
            ddlDias.Items.Add(new ListItem("Viernes", "5"));
        }

        private void CargarHoras()
        {
            ddlHoraInicio.Items.Clear();
            ddlHoraFinal.Items.Clear();

            ddlHoraInicio.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
            ddlHoraFinal.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));

            for (int hora = 8; hora <= 17; hora++)
            {
                string valor = hora.ToString("00") + ":00";

                ddlHoraInicio.Items.Add(new ListItem(valor, valor));
                ddlHoraFinal.Items.Add(new ListItem(valor, valor));
            }
        }

        private void CargarMedicosGrid()
        {
            NegocioMedico negocio = new NegocioMedico();

            DataTable tablaMedicos = negocio.GetTablaMedico();

            gvMedicos.DataSource = tablaMedicos;
            gvMedicos.DataBind();
            gvMedicos.Visible = true;

            if (tablaMedicos != null && tablaMedicos.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                lblMensaje.Text = "No hay médicos registrados.";
                btnEliminar.Enabled = false;
            }

            gvHorarios.Visible = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMedicos_Modificar.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            gvMedicos.Columns[10].Visible = true;
            btnConfirmarEliminar.Visible = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            NegocioMedico negocio = new NegocioMedico();
            /// En este caso creo el objeto negocio para evitar crearlo en cada iteracion del bucle

            foreach (GridViewRow filaMedico in gvMedicos.Rows)
            {
                CheckBox checkSeleccion = (CheckBox)filaMedico.FindControl("checkSeleccion");

                if (checkSeleccion != null && checkSeleccion.Checked == true)
                {
                    int legajo = (int)gvMedicos.DataKeys[filaMedico.RowIndex].Value;

                    negocio.EliminarMedico(legajo);
                }
            }

            DataTable tablaMedicos = new NegocioMedico().GetTablaMedico();

            gvMedicos.DataSource = tablaMedicos;
            gvMedicos.DataBind();
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarMedicosGrid();
            gvMedicos.Columns[10].Visible = false;
        }

        protected void ddlMedicoHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajeHorario.Text = "";

            if (ddlMedicoHorario.SelectedValue == "-1")
            {
                gvHorarios.DataSource = null;
                gvHorarios.DataBind();
                return;
            }

            int legajo = Convert.ToInt32(ddlMedicoHorario.SelectedValue);

            DataTable tablaHorarios = new NegocioMedico().GetHorariosMedico(legajo);

            gvHorarios.DataSource = tablaHorarios;
            gvHorarios.DataBind();
            gvHorarios.Visible = true;
        }

        protected void btnAgregarHorario_Click(object sender, EventArgs e)
        {
            lblMensajeHorario.Text = "";

            if (ddlMedicoHorario.SelectedValue == "-1")
            {
                lblMensajeHorario.Text = "Debe seleccionar un médico.";
                return;
            }

            if (ddlDias.SelectedValue == "-1" || ddlHoraInicio.SelectedValue == "-1" || ddlHoraFinal.SelectedValue == "-1")
            {
                lblMensajeHorario.Text = "Debe seleccionar día, hora de inicio y hora final.";
                return;
            }

            int legajo = Convert.ToInt32(ddlMedicoHorario.SelectedValue);
            int diaSemana = Convert.ToInt32(ddlDias.SelectedValue);
            TimeSpan horaInicio = TimeSpan.Parse(ddlHoraInicio.SelectedValue);
            TimeSpan horaFin = TimeSpan.Parse(ddlHoraFinal.SelectedValue);

            if (horaFin <= horaInicio)
            {
                lblMensajeHorario.Text = "La hora final debe ser mayor que la hora de inicio.";
                return;
            }

            NegocioMedico negocio = new NegocioMedico();

            int filasModificadas = negocio.AgregarHorarioMedico(legajo, diaSemana, horaInicio, horaFin);

            if (filasModificadas > 0)
            {
                gvHorarios.DataSource = negocio.GetHorariosMedico(legajo);
                gvHorarios.DataBind();
                lblMensajeHorario.Text = "Horario agregado correctamente.";
            }
            else
            {
                lblMensajeHorario.Text = "No se pudo agregar el horario.";
            }
        }

        protected void btnEliminarHorario_Click(object sender, EventArgs e)
        {
            NegocioMedico negocio = new NegocioMedico();

            bool horarioEliminado = false;

            foreach (GridViewRow filaHorario in gvHorarios.Rows)
            {
                CheckBox checkSeleccion = (CheckBox)filaHorario.FindControl("checkEliminarHorario");

                if (checkSeleccion != null && checkSeleccion.Checked == true)
                {
                    int idHorario = (int)gvHorarios.DataKeys[filaHorario.RowIndex].Value;
                    negocio.EliminarHorarioMedico(idHorario);
                    horarioEliminado = true;
                }
            }

            if (horarioEliminado != true)
            {
                lblMensajeHorario.Text = "Seleccione un horario";
            }
            else
            {
                int legajo = Convert.ToInt32((ddlMedicoHorario.SelectedValue));
                gvHorarios.DataSource = negocio.GetHorariosMedico(legajo);
                gvHorarios.DataBind();
                lblMensajeHorario.Text = "Horario eliminado correctamente.";
            }
        }
     

        protected void ddlMedicoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            lblMensajeUsuario.Text = "";

            if (ddlMedicoUsuario.SelectedValue == "-1")
            {
                lblMensajeUsuario.Text = "Debe seleccionar un médico.";
                return;
            }

            int legajo = Convert.ToInt32(ddlMedicoUsuario.SelectedValue);

            NegocioMedico negocioMedico = new NegocioMedico();

            if (negocioMedico.ObtenerIdUsuarioMedico(legajo) > 0)
            {
                lblMensajeUsuario.Text = "El médico seleccionado ya tiene usuario.";
                return;
            }

            Usuario usuarioNuevo = new Usuario();
            usuarioNuevo.setNombreUsuario(txtNombreUsuario.Text);
            usuarioNuevo.setPassword(txtPassword.Text);

            NegocioUsuario negocioUsuario = new NegocioUsuario();

            int idUsuario = negocioUsuario.CrearUsuarioMedico(usuarioNuevo, txtConfirmarPassword.Text);

            if (idUsuario == -1)
            {
                lblMensajeUsuario.Text = "Las contraseñas no coinciden.";
                return;
            }

            if (idUsuario == -2)
            {
                lblMensajeUsuario.Text = "El nombre de usuario ya existe.";
                return;
            }

            int filas = negocioMedico.VincularUsuarioMedico(legajo, idUsuario);

            if (filas > 0)
            {
                lblMensajeUsuario.Text = "Usuario creado y vinculado correctamente.";
            }
            else
            {
                lblMensajeUsuario.Text = "El usuario fue creado, pero no se pudo vincular al médico.";
            }
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            lblMensajeUsuario.Text = "";

            if (ddlMedicoUsuario.SelectedValue == "-1")
            {
                lblMensajeUsuario.Text = "Debe seleccionar un médico.";
                return;
            }

            int legajo = Convert.ToInt32(ddlMedicoUsuario.SelectedValue);

            NegocioMedico negocioMedico = new NegocioMedico();
            int idUsuario = negocioMedico.ObtenerIdUsuarioMedico(legajo);

            if (idUsuario == 0)
            {
                lblMensajeUsuario.Text = "El médico seleccionado no posee usuario.";
                return;
            }

            NegocioUsuario negocioUsuario = new NegocioUsuario();
            DataTable tablaUsuario = negocioUsuario.GetUsuarioPorId(idUsuario);

            txtNombreUsuario.Text = tablaUsuario.Rows[0]["NombreUsuario_USU"].ToString();

            txtPassword.Text = "";
            txtConfirmarPassword.Text = "";

            Session["IdUsuarioModificar"] = idUsuario;

            btnGuardarCambios.Visible = true;
            lblMensajeUsuario.Text = "Modifique los datos y guarde los cambios.";
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            lblMensajeUsuario.Text = "";

            if (Session["IdUsuarioModificar"] == null)
            {
                lblMensajeUsuario.Text = "Primero debe seleccionar un usuario para modificar.";
                return;
            }

            Usuario usuarioModificado = new Usuario();
            usuarioModificado.setNombreUsuario(txtNombreUsuario.Text);
            usuarioModificado.setPassword(txtPassword.Text);

            int idUsuario = Convert.ToInt32(Session["IdUsuarioModificar"]);

            NegocioUsuario negocioUsuario = new NegocioUsuario();

            if (negocioUsuario.ModificarUsuario(idUsuario, usuarioModificado, txtConfirmarPassword.Text))
            {
                lblMensajeUsuario.Text = "Usuario modificado correctamente.";

                txtNombreUsuario.Text = "";
                txtPassword.Text = "";
                txtConfirmarPassword.Text = "";

                Session["IdUsuarioModificar"] = null;

                btnGuardarCambios.Visible = false;
            }
            else
            {
                lblMensajeUsuario.Text = "No se pudo modificar el usuario. Verifique que las contraseñas coincidan.";
            }
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/MenuAdmin.aspx");
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;

            CargarMedicosGrid();
            gvMedicos.Columns[10].Visible = false;
        }
    }
}