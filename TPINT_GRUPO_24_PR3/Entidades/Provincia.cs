using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int _IdProvincia;
        private string _NombreProvincia;

        public Provincia()
        {

        }

        public int getIdProvincia()
        {
            return _IdProvincia;
        }

        public void setIdProvincia(int IdProvincia)
        {
            _IdProvincia = IdProvincia;
        }

        public string getNombreProvincia()
        {
            return _NombreProvincia;
        }

        public void setNombreProvincia(string NombreProvincia)
        {
            _NombreProvincia = NombreProvincia;
        }
    }
}
