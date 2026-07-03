using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        private int _IdEspecialidad;
        private string _DescripcionEspecialidad;

        public Especialidad()
        {

        }

        public int getIdEspecialidad()
        {
            return _IdEspecialidad;
        }

        public void setIdEspecialidad(int IdEspecialidad)
        {
            _IdEspecialidad = IdEspecialidad;
        }

        public string getDescripcionEspecialidad()
        {
            return _DescripcionEspecialidad;
        }

        public void setDescripcionEspecialidad(string DescripcionEspecialidad)
        {
            _DescripcionEspecialidad = DescripcionEspecialidad;
        }
    }
}