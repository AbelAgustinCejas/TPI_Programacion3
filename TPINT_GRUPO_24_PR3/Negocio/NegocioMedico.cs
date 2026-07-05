using Datos;
using Entidades;
using System;
using System.Data;

namespace Negocio
{
    public class NegocioMedico
    {
        public DataTable GetTablaMedico()
        {
            DaoClinica dao = new DaoClinica();
            return dao.ListarMedicos();
        }

        public DataTable GetTablaEspecialidad()
        {
            DaoClinica dao = new DaoClinica();
            return dao.ObtenerEspecialidades();
        }

        public bool ExisteMedico(string DNI)
        {
            DaoClinica dao = new DaoClinica();
            return dao.ExisteMedico(DNI);
        }

        public int AgregarMedico(Medico medico)
        {
            DaoClinica dao = new DaoClinica();

            int legajo = dao.AgregarMedico(medico);

            if (legajo > 0)
            {
                return legajo;
            }

            return 0;
        }

        public void EliminarMedico(int legajo)
        {
            DaoClinica dao = new DaoClinica();
            dao.BajaLogicaMedico(legajo);
        }

        public DataTable GetMedicosDDL()
        {
            DaoClinica dao = new DaoClinica();

            return dao.ObtenerMedicosDDL();
        }

        public int AgregarHorarioMedico(int legajo, int diaSemana, TimeSpan horaInicio, TimeSpan horaFin)
        {
            DaoClinica dao = new DaoClinica();

            return dao.AgregarHorarioMedico(legajo, diaSemana, horaInicio, horaFin);
        }

        public bool EliminarHorarioMedico(int idHorario)
        {
            DaoClinica dao = new DaoClinica();

            if (dao.EliminarHorarioMedico(idHorario) > 0)
            {
                return true;
            }

            return false;
        }

        public DataTable GetHorariosMedico(int legajo)
        {
            DaoClinica dao = new DaoClinica();

            return dao.ObtenerHorariosMedico(legajo);
        }

        public int ObtenerIdUsuarioMedico(int legajo)
        {
            DaoClinica dao = new DaoClinica();

            return dao.ObtenerIdUsuarioMedico(legajo);
        }

        public int VincularUsuarioMedico(int legajo, int idUsuario)
        {
            DaoClinica dao = new DaoClinica();

            return dao.VincularUsuarioMedico(legajo, idUsuario);
        }

        public DataTable GetTablaMedicoPorDNI(string DNI)
        {
            DaoClinica dao = new DaoClinica();

            return dao.BuscarMedico(DNI);
        }

        public int ModificarMedico(Medico medico)
        {
            return new DaoClinica().ModificarMedico(medico);
        }

        public DataTable GetTablaMedicosPorEspecialidad (int idEspecialidad)
        {
            return new DaoClinica().ListarMedicosPorEspecialidad(idEspecialidad);
        }
   



    }
}