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

        public string ObtenerNombreUsuario(int idUsuario, bool tipoUsuario)
        {
            string NombreUsuario;

            if (tipoUsuario)
            {
                NombreUsuario = dao.ObtenerNombreMedico(idUsuario);
            }
            else
            {
                NombreUsuario = "Administrador";
            }

            return NombreUsuario;
        }
    }
}