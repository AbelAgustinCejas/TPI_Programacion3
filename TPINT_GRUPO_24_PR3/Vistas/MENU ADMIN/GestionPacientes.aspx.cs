using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.MENU_ADMIN
{
    public partial class GestionPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarProvincias();
                //lblUsuarioIngresado.Text = Session["NombreBienvenida"].ToString();
            }
        }

        protected void BtnListado_Click(object sender, EventArgs e)
        {
            LblMensaje.Text = "";
            DataTable tablaPacientes = new NegocioPaciente().GetTablaPaciente();

            gvPacientes.DataSource = tablaPacientes;
            gvPacientes.DataBind();
            gvPacientes.Columns[11].Visible = false; /// Se oculta columna de checkBox

            if (tablaPacientes != null && tablaPacientes.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                LblMensaje.Text = "No hay pacientes registrados";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            gvPacientes.Columns[11].Visible = true;
            LblMensaje.Text = "Seleccione paciente a eliminar";
            btnConfirmarEliminar.Visible = true;

        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!Page.IsValid) ///propiedad que valida si los RQF fueron superados
            {
                return;
            }

            Paciente paciente = new Paciente();

            paciente.setIdLocalidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            paciente.setDNI(txtNombre.Text);
            paciente.setNombre(DNI.Text);
            paciente.setApellido(txtApellido.Text);
            paciente.setSexo(Convert.ToChar(ddlSexo.SelectedValue));
            paciente.setNacionalidad(txtNacionalidad.Text);
            paciente.setFechaNacimiento(Convert.ToDateTime(txtFechaNacimiento.Text));
            paciente.setDireccion(txtDireccion.Text);
            paciente.setEmail(txtEmail.Text);
            paciente.setTelefono(txtTelefono.Text);
            paciente.setEstado(true);

            NegocioPaciente negocio = new NegocioPaciente();

            if (negocio.ExistePaciente(paciente.getDNI())) ///valida funcion 
            {
                LblMensaje.Text = "Ya existe un paciente con ese DNI.";
            }

            if (negocio.AgregarPaciente(paciente)) ///limpia
            {
                LblMensaje.Text = "Paciente agregado correctamente.";

                txtNombre.Text = "";
                DNI.Text = "";
                txtApellido.Text = "";
                txtNacionalidad.Text = "";
                txtFechaNacimiento.Text = "";
                txtDireccion.Text = "";
                txtEmail.Text = "";
                txtTelefono.Text = "";

                ddlSexo.SelectedIndex = 0;
                ddlProvincia.SelectedIndex = 0;
                ddlLocalidad.SelectedIndex = 0;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPacientes_Modificar.aspx");
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

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            NegocioPaciente negocio = new NegocioPaciente();
            /// En este caso creo el objeto negocio para evitar crearlo en cada iteracion del bucle

            foreach (GridViewRow filaPaciente in gvPacientes.Rows)
            {
                CheckBox checkSeleccion = (CheckBox)filaPaciente.FindControl("checkSeleccion");

                if (checkSeleccion != null && checkSeleccion.Checked == true)
                {
                    int id = (int)gvPacientes.DataKeys[filaPaciente.RowIndex].Value;

                    negocio.EliminarPaciente(id);
                }
            }

            DataTable tablaPacientes = new NegocioPaciente().GetTablaPaciente();

            gvPacientes.DataSource = tablaPacientes;
            gvPacientes.DataBind();
        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRINCIPAL/MenuAdmin.aspx");
        }
        private void CargarProvincias()
        {
            ddlProvincia.Items.Clear();
            ddlProvincia.DataSource = new NegocioProvincia().GetTablaProvincia();
            ddlProvincia.DataTextField = "Nombre_PRO";
            ddlProvincia.DataValueField = "IdProvincia_PRO";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione --", "-1"));
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

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;

            DataTable tablaPacientes = new NegocioPaciente().GetTablaPaciente();

            gvPacientes.DataSource = tablaPacientes;
            gvPacientes.DataBind();
        }
    }
}

