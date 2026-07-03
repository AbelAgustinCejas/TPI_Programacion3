using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private int _IdPaciente;
        private int _IdLocalidad;
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

        public Paciente()
        {

        }

        public int getIdPaciente()
        {
            return _IdPaciente;
        }

        public void setIdPaciente(int IdPaciente)
        {
            _IdPaciente = IdPaciente;
        }

        public int getIdLocalidad()
        {
            return _IdLocalidad;
        }

        public void setIdLocalidad(int IdLocalidad)
        {
            _IdLocalidad = IdLocalidad;
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
    }
}
