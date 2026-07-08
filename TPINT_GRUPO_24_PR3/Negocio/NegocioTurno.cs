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

        public DataTable ObtenerTablaTurnos(int usuario)
        {
            DataTable tablaTurnos = new DaoClinica().ObtenerTablaTurnos(usuario);

            return tablaTurnos;
        }
        public DataTable ObtenerTablaTurnos(int usuario, string busqueda)
        {
            DataTable tablaTurnos = new DaoClinica().ObtenerTablaTurnos(usuario, busqueda);

            return tablaTurnos;
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
