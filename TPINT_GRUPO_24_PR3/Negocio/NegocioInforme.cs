using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioInforme
    {
        public DataTable InformeTurnosEspecialidad(int idEspecialidad)
        {
            DaoClinica dao = new DaoClinica();

            return dao.InformeTurnosEspecialidad(idEspecialidad);
        }
        public DataTable GetTablaEspecialidad()
        {
            DaoClinica dao = new DaoClinica();
            return dao.ObtenerEspecialidades();
        }
    }
}
