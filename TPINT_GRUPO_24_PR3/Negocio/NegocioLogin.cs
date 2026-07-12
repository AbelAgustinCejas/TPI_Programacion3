using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class NegocioLogin
    {
        DaoClinica dao = new DaoClinica();

        public SqlDataReader Login(string nombreUsuario, string contraseña)
        {
            return dao.Login(nombreUsuario, contraseña);
        }

        public string ObtenerNombreBienvenida(int idUsuario, bool tipoUsuario)
        {
            string nombreBienvenida;

            if (tipoUsuario)
            {
                nombreBienvenida = dao.ObtenerNombreMedico(idUsuario);
            }
            else
            {
                nombreBienvenida = "Administrador";
            }

            return nombreBienvenida;
        }
    }
}