using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas.MENU_ADMIN
{
    public partial class GestionMedicos_Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                CargarEspecialidades();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string DNI = txtBuscarDNI.Text;

            DataTable dataTableMedico = new NegocioMedico().GetTablaMedicoPorDNI(DNI);

            if (dataTableMedico != null && dataTableMedico.Rows.Count > 0)
            {
                Session["Medico"] = dataTableMedico;
                gvMedico.Visible = true;
                gvMedico.DataSource = dataTableMedico;
                gvMedico.DataBind();
                btnSeleccionar.Visible = true;
            }
            else
            {
                gvMedico.Visible = false;
                LblMensaje.Text = "No se encontró medico";
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico();

            DataRow rowMedico = ((DataTable)Session["Medico"]).Rows[0];

            medico.setLegajo(Convert.ToInt32(rowMedico["Legajo_MED"]));
            medico.setDNI(txtDNI.Text.Trim());
            medico.setNombre(txtNombre.Text.Trim());
            medico.setApellido(txtApellido.Text.Trim());
            medico.setSexo(Convert.ToChar(ddlSexo.SelectedValue));
            medico.setNacionalidad(txtNacionalidad.Text.Trim());
            medico.setFechaNacimiento(Convert.ToDateTime(txtFechaNacimiento.Text));
            medico.setDireccion(txtDireccion.Text);
            medico.setEmail(txtEmail.Text.Trim());
            medico.setTelefono(txtTelefono.Text.Trim());
            medico.setIdEspecialidad(Convert.ToInt32(ddlEspecialidad.SelectedValue));
            medico.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            medico.setEstado(true);

            int filasAfectadas = new NegocioMedico().ModificarMedico(medico);

            if (filasAfectadas > 0)
            {
                LblMensaje.Text = "Médico modificado correctamente.";

                Session["Medico"] = null;

                DeshabilitarFormulario();
                LimpiarFomulario();

                btnSeleccionar.Visible = false;
                gvMedico.Visible = false;

                ddlLocalidad.SelectedIndex = 0;
                ddlProvincia.SelectedIndex = 0;
                ddlSexo.SelectedIndex = 0;
                ddlEspecialidad.SelectedIndex = 0;
            }
            else
            {
                LblMensaje.Text = "No se pudo modificar el médico.";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            DeshabilitarFormulario();

            gvMedico.Visible = false;
            btnSeleccionar.Visible= false;

            LimpiarFomulario();

            ddlSexo.SelectedValue = "-1";
            ddlProvincia.SelectedValue = "-1";

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", "-1"));

            Session["Medico"] = null;

            LblMensaje.Text = "Edición cancelada.";
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario();
            DataTable dataTableMedico = (DataTable)Session["Medico"];
            DataRow dataRowMedico = dataTableMedico.Rows[0];

            txtDNI.Text = dataRowMedico["DNI_MED"].ToString();
            txtNombre.Text = dataRowMedico["Nombre_MED"].ToString();
            txtApellido.Text = dataRowMedico["Apellido_MED"].ToString();
            ddlSexo.SelectedValue = dataRowMedico["Sexo_MED"].ToString();
            txtNacionalidad.Text = dataRowMedico["Nacionalidad_MED"].ToString();

            txtFechaNacimiento.Text = Convert.ToDateTime(dataRowMedico["FechaNacimiento_MED"]).ToString("yyyy-MM-dd");

            txtDireccion.Text = dataRowMedico["Direccion_MED"].ToString();
            txtEmail.Text = dataRowMedico["Email_MED"].ToString();
            txtTelefono.Text = dataRowMedico["Telefono_MED"].ToString();


            ddlEspecialidad.SelectedValue = dataRowMedico["IdEspecialidad_MED"].ToString();
            ddlProvincia.SelectedValue = dataRowMedico["IdProvincia_PRO"].ToString();
            CargarLocalidades(Convert.ToInt32(dataRowMedico["IdProvincia_PRO"]));
            ddlLocalidad.SelectedValue = dataRowMedico["IdLocalidad_MED"].ToString();

        }

        public void CargarEspecialidades()
        {
            ddlEspecialidad.Items.Clear();

            ddlEspecialidad.DataSource = new NegocioMedico().GetTablaEspecialidad();
            ddlEspecialidad.DataTextField = "Descripcion_ESP";
            ddlEspecialidad.DataValueField = "IdEspecialidad_ESP";
            ddlEspecialidad.DataBind();

            ddlEspecialidad.Items.Insert(0, new ListItem("Seleccione", "-1"));
        }

        public void CargarProvincias()
        {
            ddlProvincia.Items.Clear();

            ddlProvincia.DataSource = new NegocioProvincia().GetTablaProvincia();
            ddlProvincia.DataTextField = "Nombre_PRO";
            ddlProvincia.DataValueField = "IdProvincia_PRO";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("Seleccione", "-1"));
        }

        public void CargarLocalidades(int idProvincia)
        {
            ddlLocalidad.Items.Clear();
            ddlLocalidad.DataSource = new NegocioProvincia().GetTablaLocalidadPorProvincia(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_LOC";
            ddlLocalidad.DataValueField = "IdLocalidad_LOC";

            ddlLocalidad.DataBind();


            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", "-1"));
        }

        private void HabilitarFormulario()
        {
            txtDNI.Enabled = true;
            ddlEspecialidad.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            ddlSexo.Enabled = true;
            txtNacionalidad.Enabled = true;
            txtFechaNacimiento.Enabled = true;
            txtDireccion.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;

            ddlProvincia.Enabled = true;
            ddlLocalidad.Enabled = true;
    
            
            btnGuardar.Enabled = true;
            btnLimpiar.Enabled = true;
        }

        private void DeshabilitarFormulario()
        {
            txtDNI.Enabled = false;
            ddlEspecialidad.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            ddlSexo.Enabled = false;
            txtNacionalidad.Enabled = false;
            txtFechaNacimiento.Enabled = false;
            txtDireccion.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;

            ddlProvincia.Enabled = false;
            ddlLocalidad.Enabled = false;

            btnGuardar.Enabled = false;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMedicos.aspx");
        }

        private void LimpiarFomulario()
        {
            txtDNI.Text = "";
            txtBuscarDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }
    }
}