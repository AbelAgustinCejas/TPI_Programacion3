using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas.MENU_ADMIN
{
    public partial class GestionPacientes_Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string DNI = txtBuscarDNI.Text;

            DataTable dataTablePaciente = new NegocioPaciente().GetTablaPacientePorDNI(DNI);

            if (dataTablePaciente != null && dataTablePaciente.Rows.Count > 0)
            {
                Session["Paciente"] = dataTablePaciente;
                gvPaciente.Visible = true;
                gvPaciente.DataSource = dataTablePaciente;
                gvPaciente.DataBind();
                btnSeleccionar.Visible = true;
            }
            else
            {
                gvPaciente.Visible = false;
                LblMensaje.Text = "No se encontró paciente";
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

            Paciente paciente = new Paciente();

            DataRow rowPaciente = ((DataTable)Session["Paciente"]).Rows[0];

            paciente.setIdPaciente(Convert.ToInt32(rowPaciente["IdPaciente_PAC"]));
            paciente.setDNI(txtDNI.Text.Trim());
            paciente.setNombre(txtNombre.Text.Trim());
            paciente.setApellido(txtApellido.Text.Trim());
            paciente.setSexo(Convert.ToChar(ddlSexo.SelectedValue));
            paciente.setNacionalidad(txtNacionalidad.Text.Trim());
            paciente.setFechaNacimiento(Convert.ToDateTime(txtFechaNacimiento.Text));
            paciente.setDireccion(txtDireccion.Text);
            paciente.setEmail(txtEmail.Text.Trim());
            paciente.setTelefono(txtTelefono.Text.Trim());
            paciente.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            paciente.setEstado(true);

            int filasAfectadas = new NegocioPaciente().ModificarPaciente(paciente);

            if (filasAfectadas > 0)
            {
                LblMensaje.Text = "Paciente modificado correctamente.";
                Session["Paciente"] = null;
                DeshabilitarFormulario();
                LimpiarFomulario();
                btnSeleccionar.Visible = false;
                gvPaciente.Visible = false;
                ddlLocalidad.SelectedIndex = 0;
                ddlProvincia.SelectedIndex = 0;
                ddlSexo.SelectedIndex = 0;
            }
            else
            {
                LblMensaje.Text = "No se pudo modificar el paciente.";
            }
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            DeshabilitarFormulario();

            gvPaciente.Visible = false;
            btnSeleccionar.Visible= false;

            LimpiarFomulario();

            ddlSexo.SelectedValue = "-1";
            ddlProvincia.SelectedValue = "-1";

            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", "-1"));

            Session["Paciente"] = null;

            LblMensaje.Text = "Edición cancelada.";
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario();
            DataTable dataTablePaciente = (DataTable)Session["Paciente"];
            DataRow dataRowPaciente = dataTablePaciente.Rows[0];

            txtDNI.Text = dataRowPaciente ["DNI_PAC"].ToString();
            txtNombre.Text = dataRowPaciente ["Nombre_PAC"].ToString();
            txtApellido.Text = dataRowPaciente ["Apellido_PAC"].ToString();
            ddlSexo.SelectedValue = dataRowPaciente ["Sexo_PAC"].ToString();
            txtNacionalidad.Text = dataRowPaciente ["Nacionalidad_PAC"].ToString();
     
            txtFechaNacimiento.Text = Convert.ToDateTime(dataRowPaciente ["FechaNacimiento_PAC"]).ToString("yyyy-MM-dd");

            txtDireccion.Text = dataRowPaciente ["Direccion_PAC"].ToString();
            txtEmail.Text = dataRowPaciente ["Email_PAC"].ToString();
            txtTelefono.Text = dataRowPaciente ["Telefono_PAC"].ToString();

          
            ddlProvincia.SelectedValue = dataRowPaciente["IdProvincia_PRO"].ToString();
            CargarLocalidades(Convert.ToInt32(dataRowPaciente["IdProvincia_PRO"]));
            ddlLocalidad.SelectedValue = dataRowPaciente["IdLocalidad_PAC"].ToString();

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
            Response.Redirect("GestionPacientes.aspx");
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