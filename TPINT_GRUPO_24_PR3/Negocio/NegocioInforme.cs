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

        public DataTable InformeAsistencia(DateTime fechaDesde, DateTime fechaHasta, out int total, out int presentes, out int ausentes, out double porcentajeAsistencia)
        {
            DataTable tablaAsistencia = new DaoClinica().ObtenerInformeAsistencia(fechaDesde, fechaHasta);

            total = tablaAsistencia.Rows.Count;
            presentes = 0;
            ausentes = 0;
            porcentajeAsistencia = 0;

            foreach (DataRow turno in tablaAsistencia.Rows)
            {
                string estado = turno["Asistencia"].ToString();

                if (estado == "Presente")
                {
                    presentes++;
                }
                else if (estado == "Ausente")
                {
                    ausentes++;
                }
            }

            if (total > 0) /// Evitamos division por 0 rompiendo el sistema.
            {
                porcentajeAsistencia = (double)(presentes * 100) / (presentes + ausentes);
            }
            else
            {
                porcentajeAsistencia = 0;
            }

            return tablaAsistencia;
        }


    }
}
