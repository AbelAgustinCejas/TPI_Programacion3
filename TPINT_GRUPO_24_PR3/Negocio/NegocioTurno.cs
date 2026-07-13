using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoClinica dao = new DaoClinica();

        public DataTable BuscarTurnos(int usuario, string busqueda)
        {
            return dao.BuscarTurnos(usuario, busqueda);
        }

        public DataTable ObtenerTurnosPendientes(int usuario)
        {
            return dao.ObtenerTurnosPendientes(usuario);
        }

        public DataTable ObtenerTurnosHistorial(int usuario)
        {
            return dao.ObtenerTurnosHistorial(usuario);
        }

        public bool ConfirmarTurno(int legajo, int idPaciente, DateTime fecha, TimeSpan hora)
        {
            return dao.AgregarTurno(legajo, idPaciente, fecha, hora);
        }

        public List<TimeSpan> ObtenerHorariosDisponibles(int legajo, DateTime fecha)
        {
            return dao.ObtenerHorariosDisponibles(legajo, fecha);
        }

        public bool MedicoAtiendeEseDia(int legajo, DateTime fecha)
        {
            DaoClinica dao = new DaoClinica();
            return dao.MedicoAtiendeEseDia(legajo, fecha);
        }

        public DataTable BuscarTurnoPorDni(int dni)
        {
            DaoClinica dao = new DaoClinica();
            return dao.BuscarTurnoPorDni(dni);
        }

        public bool EliminarTurno(int idTurno)
        {
            DaoClinica dao = new DaoClinica();
            return dao.EliminarTurno(idTurno);
        }

        public bool ActualizarAsistencia(int idTurno, bool asistencia)
        {
            DaoClinica dao = new DaoClinica();
            return dao.ActualizarAsistencia(idTurno, asistencia);
        }
    }
}
