using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int _IdLocalidad;
        private int _IdProvincia;
        private string _NombreLocalidad;

        public Localidad()
        {

        }

        public int getIdLocalidad()
        {
            return _IdLocalidad;
        }

        public void setIdLocalidad(int IdLocalidad)
        {
            _IdLocalidad = IdLocalidad;
        }

        public int getIdProvincia()
        {
            return _IdProvincia;
        }

        public void setIdProvincia(int IdProvincia)
        {
            _IdProvincia = IdProvincia;
        }

        public string getNombreLocalidad()
        {
            return _NombreLocalidad;
        }

        public void setNombreLocalidad(string NombreLocalidad)
        {
            _NombreLocalidad = NombreLocalidad;
        }
    }
}
