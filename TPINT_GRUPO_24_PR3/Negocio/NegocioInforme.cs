using Datos;
using System;
using System.Data;

namespace Negocio
{
    public class NegocioInforme
    {
        public DataTable InformeTurnosEspecialidad(
            int idEspecialidad,
            DateTime fechaDesde,
            DateTime fechaHasta,
            out int totalTurnos,
            out string especialidadMayor,
            out int cantidadMayor,
            out string especialidadMenor,
            out int cantidadMenor)
        {
            DataTable tabla = new DaoClinica().InformeTurnosEspecialidad(idEspecialidad, fechaDesde, fechaHasta);

            totalTurnos = 0;
            especialidadMayor = "";
            especialidadMenor = "";
            cantidadMayor = 0;
            cantidadMenor = 0;
            bool primerRegistro = true;

            foreach (DataRow fila in tabla.Rows)
            {
                int cantidad = Convert.ToInt32(fila["Cantidad"]);
                string especialidad = fila["Especialidad"].ToString();

                totalTurnos += cantidad;

                if (primerRegistro)
                {
                    cantidadMayor = cantidad;
                    cantidadMenor = cantidad;
                    especialidadMayor = especialidad;
                    especialidadMenor = especialidad;
                    primerRegistro = false;
                }
                else
                {
                    if (cantidad > cantidadMayor)
                    {
                        cantidadMayor = cantidad;
                        especialidadMayor = especialidad;
                    }

                    if (cantidad < cantidadMenor)
                    {
                        cantidadMenor = cantidad;
                        especialidadMenor = especialidad;
                    }
                }
            }

            return tabla;
        }

        public DataTable GetTablaEspecialidad()
        {
            return new DaoClinica().ObtenerEspecialidades();
        }

        public DataTable InformeTurnosMedico(
            int legajo,
            DateTime fechaDesde,
            DateTime fechaHasta,
            out int totalTurnos,
            out string medicoMayor,
            out int cantidadMayor,
            out string medicoMenor,
            out int cantidadMenor)
        {
            DataTable tabla = new DaoClinica().InformeTurnosMedico(legajo, fechaDesde, fechaHasta);

            totalTurnos = 0;
            medicoMayor = "";
            medicoMenor = "";
            cantidadMayor = 0;
            cantidadMenor = 0;
            bool primerRegistro = true;

            foreach (DataRow fila in tabla.Rows)
            {
                int turnos = Convert.ToInt32(fila["Turnos"]);
                string medico = fila["Nombre"].ToString() + " " + fila["Apellido"].ToString();

                totalTurnos += turnos;

                if (primerRegistro)
                {
                    cantidadMayor = turnos;
                    cantidadMenor = turnos;
                    medicoMayor = medico;
                    medicoMenor = medico;
                    primerRegistro = false;
                }
                else
                {
                    if (turnos > cantidadMayor)
                    {
                        cantidadMayor = turnos;
                        medicoMayor = medico;
                    }

                    if (turnos < cantidadMenor)
                    {
                        cantidadMenor = turnos;
                        medicoMenor = medico;
                    }
                }
            }

            return tabla;
        }

        public DataTable GetTablaMedico()
        {
            return new DaoClinica().ObtenerMedicosDDL();
        }

        public DataTable InformeAsistencia(DateTime fechaDesde, DateTime fechaHasta,
            out int total, out int presentes, out int ausentes, out double porcentajeAsistencia)
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
                    presentes++;
                else if (estado == "Ausente")
                    ausentes++;
            }

            if (presentes + ausentes > 0)
                porcentajeAsistencia = (double)(presentes * 100) / (presentes + ausentes);

            return tablaAsistencia;
        }
    }
}