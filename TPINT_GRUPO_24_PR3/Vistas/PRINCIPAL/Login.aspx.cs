using Entidades;
using Negocio;
using System;
using System.Data;

namespace Vistas.PRINCIPAL
{
    public partial class Login : System.Web.UI.Page
    {
        NegocioLogin negocio = new NegocioLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInSesion_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string nombreUsuario = txtUsuario.Text.Trim();
            string contraseña = txtContrasenia.Text.Trim();


            DataTable dataTableUsuario = negocio.Login(nombreUsuario, contraseña);

            if (dataTableUsuario.Rows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dataTableUsuario.Rows[0]["IdUsuario_USU"]);
                bool tipoUsuario = Convert.ToBoolean(dataTableUsuario.Rows[0]["Tipo_USU"]);

                Session["IdUsuario"] = idUsuario;
                Session["TipoUsuario"] = tipoUsuario;
                Session["NombreBienvenida"] = negocio.ObtenerNombreBienvenida(idUsuario, tipoUsuario);

                 
                if (tipoUsuario == false)
                {
                    Response.Redirect("~/PRINCIPAL/MenuAdmin.aspx");
                }
                else
                {
                    Response.Redirect("~/PRINCIPAL/MenuMedico.aspx");
                }
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}