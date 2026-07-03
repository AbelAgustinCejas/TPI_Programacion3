using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int _IdUsuario;
        private string _NombreUsuario;
        private string _Password;
        private bool _Tipo;
        private bool _Estado;

        public Usuario()
        {

        }

        public int getIdUsuario()
        {
            return _IdUsuario;
        }

        public void setIdUsuario(int idUsuario)
        {
            _IdUsuario = idUsuario;
        }

        public string getNombreUsuario()
        {
            return _NombreUsuario;
        }

        public void setNombreUsuario(string nombreUsuario)
        {
            _NombreUsuario = nombreUsuario;
        }

        public string getPassword()
        {
            return _Password;
        }

        public void setPassword(string password)
        {
            _Password = password;
        }

        public bool getTipo()
        {
            return _Tipo;
        }

        public void setTipo(bool tipo)
        {
            _Tipo = tipo;
        }

        public bool getEstado()
        {
            return _Estado;
        }

        public void setEstado(bool estado)
        {
            _Estado = estado;
        }
    }
}