using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioUsuario
    {
        DaoClinica dao = new DaoClinica();
        public int CrearUsuarioMedico(Usuario usuario, string confirmarPassword)
        {

            if (usuario.getPassword() != confirmarPassword)
            {
                return -1;
            }

            if (dao.ExisteNombreUsuario(usuario.getNombreUsuario()))
            {
                return -2;
            }

            return dao.AgregarUsuario(usuario);
        }

        public DataTable GetUsuarioPorId(int idUsuario)
        {
            DaoClinica dao = new DaoClinica();

            return dao.ObtenerUsuarioPorId(idUsuario);
        }

        public bool ModificarUsuario(int idUsuario, Usuario usuario, string confirmarPassword)
        {
            DaoClinica dao = new DaoClinica();

            if (usuario.getPassword() != confirmarPassword)
            {
                return false;
            }

            return dao.ModificarUsuario(idUsuario, usuario) > 0;
        }
    }
}