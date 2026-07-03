using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioLogin
    {
        DaoClinica dao = new DaoClinica();

        public DataTable Login(string nombreUsuario, string contraseña)
        {
            return dao.Login(nombreUsuario, contraseña);
        }

        public string ObtenerNombreBienvenida(int idUsuario, bool tipoUsuario)
        {
            string nombreBienvenida;

            if (tipoUsuario != true) 
            {
                nombreBienvenida = "Administrador";
                return nombreBienvenida;
            }
            else
            {
                nombreBienvenida = dao.ObtenerNombreMedico(idUsuario);
                return nombreBienvenida;
            }
        }
    }
}