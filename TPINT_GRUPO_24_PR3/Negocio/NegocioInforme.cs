using Datos;
using System;
using System.Data;

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
        public DataTable InformeTurnosMedico(int legajo)
        {
            DaoClinica dao = new DaoClinica();

            return dao.InformeTurnosMedico(legajo);
        }
        public DataTable GetTablaMedico()
        {
            DaoClinica dao = new DaoClinica();
            return dao.ObtenerMedicosDDL();
        }
    }
}
