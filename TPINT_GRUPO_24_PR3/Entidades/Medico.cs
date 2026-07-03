using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private int _Legajo;
        private int _IdEspecialidad;
        private int _IdLocalidad;
        private int _IdProvincia;
        private int _IdUsuario;
        private string _DNI;
        private string _Nombre;
        private string _Apellido;
        private char _Sexo;
        private string _Nacionalidad;
        private DateTime _FechaNacimiento;
        private string _Direccion;
        private string _Email;
        private string _Telefono;
        private bool _Estado;
        private string _DiasAtencion;
        private DateTime _HoraDesde;
        private DateTime _HoraHasta;


        public Medico()
        {

        }

        public int getLegajo()
        {
            return _Legajo;
        }

        public void setLegajo(int Legajo)
        {
            _Legajo = Legajo;
        }

        public int getIdEspecialidad()
        {
            return _IdEspecialidad;
        }

        public void setIdEspecialidad(int IdEspecialidad)
        {
            _IdEspecialidad = IdEspecialidad;
        }

        public int getIdLocalidad()
        {
            return _IdLocalidad;
        }

        public void setIdLocalidad(int IdLocalidad)
        {
            _IdLocalidad = IdLocalidad;
        }

        public int getIdUsuario()
        {
            return _IdUsuario;
        }

        public void setIdUsuario(int IdUsuario)
        {
            _IdUsuario = IdUsuario;
        }

        public string getDNI()
        {
            return _DNI;
        }

        public void setDNI(string DNI)
        {
            _DNI = DNI;
        }

        public string getNombre()
        {
            return _Nombre;
        }

        public void setNombre(string Nombre)
        {
            _Nombre = Nombre;
        }

        public string getApellido()
        {
            return _Apellido;
        }

        public void setApellido(string Apellido)
        {
            _Apellido = Apellido;
        }

        public char getSexo()
        {
            return _Sexo;
        }

        public void setSexo(char Sexo)
        {
            _Sexo = Sexo;
        }

        public string getNacionalidad()
        {
            return _Nacionalidad;
        }

        public void setNacionalidad(string Nacionalidad)
        {
            _Nacionalidad = Nacionalidad;
        }

        public DateTime getFechaNacimiento()
        {
            return _FechaNacimiento;
        }

        public void setFechaNacimiento(DateTime FechaNacimiento)
        {
            _FechaNacimiento = FechaNacimiento;
        }

        public string getDireccion()
        {
            return _Direccion;
        }

        public void setDireccion(string Direccion)
        {
            _Direccion = Direccion;
        }

        public string getEmail()
        {
            return _Email;
        }

        public void setEmail(string Email)
        {
            _Email = Email;
        }

        public string getTelefono()
        {
            return _Telefono;
        }

        public void setTelefono(string Telefono)
        {
            _Telefono = Telefono;
        }

        public bool getEstado()
        {
            return _Estado;
        }

        public void setEstado(bool Estado)
        {
            _Estado = Estado;
        }

        public void setDiasAtencion(string diasAtencion)
        {
            _DiasAtencion = diasAtencion;
        }

        public void setHoraDesde(DateTime horaDesde)
        {
            _HoraDesde = horaDesde;
        }

        public void setHoraHasta(DateTime horaHasta)
        {
            _HoraHasta = horaHasta;
        }

        public int getIdProvincia()
        {
            return _IdProvincia;
        }

        public void setIdProvincia(int idProvincia)
        {
            _IdProvincia = idProvincia;
        }



    }
}