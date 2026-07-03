using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int _IdTurno;
        private int _Legajo;
        private int _IdPaciente;
        private DateTime _Fecha;
        private TimeSpan _Hora;

        public Turno()
        {

        }

        public int getIdTurno()
        {
            return _IdTurno;
        }

        public void setIdTurno(int IdTurno)
        {
            _IdTurno = IdTurno;
        }

        public int getLegajo()
        {
            return _Legajo;
        }

        public void setLegajo(int Legajo)
        {
            _Legajo = Legajo;
        }

        public int getIdPaciente()
        {
            return _IdPaciente;
        }

        public void setIdPaciente(int IdPaciente)
        {
            _IdPaciente = IdPaciente;
        }

        public DateTime getFecha()
        {
            return _Fecha;
        }

        public void setFecha(DateTime Fecha)
        {
            _Fecha = Fecha;
        }

        public TimeSpan getHora()
        {
            return _Hora;
        }

        public void setHora(TimeSpan Hora)
        {
            _Hora = Hora;
        }
    }
}