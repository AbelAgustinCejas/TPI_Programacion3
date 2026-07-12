using Entidades;
using Negocio;
using System;
using System.Data;
using System.Data.SqlClient;

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
            string nombreUsuario = txtUsuario.Text.Trim();
            string contraseña = txtContrasenia.Text.Trim();

            SqlDataReader reader = negocio.Login(nombreUsuario, contraseña);

            if (reader.Read())
            {
                int idUsuario = Convert.ToInt32(reader["IdUsuario_USU"]);
                bool tipoUsuario = Convert.ToBoolean(reader["Tipo_USU"]);

                Session["NombreBienvenida"] = negocio.ObtenerNombreBienvenida(idUsuario, tipoUsuario);
                Session["IdUsuario"] = idUsuario;
                Session["TipoUsuario"] = tipoUsuario;

                if (!tipoUsuario)
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
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}