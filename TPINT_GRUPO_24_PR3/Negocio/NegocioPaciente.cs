using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPaciente
    {
        public DataTable GetTablaPaciente()
        {
            DataTable tablaPacientes = new DaoClinica().ListarPacientes();

            return tablaPacientes;
        }

        public DataTable GetTablaPacientePorDNI(string DNI)
        {
            DataTable tablaPacientes = new DaoClinica().BuscarPaciente(DNI);

            return tablaPacientes;
        }

        public void EliminarPaciente(int id)
        {
            new DaoClinica().BajaLogicaPaciente(id);
        }
        public bool AgregarPaciente(Paciente pac)
        {
            DaoClinica dao = new DaoClinica();

            if (dao.AgregarPaciente(pac) > 0) ///valida el insert
            {
                return true;
            }

            return false;
        }
        public int ModificarPaciente(Paciente paciente)
        {
            return new DaoClinica().ModificarPaciente(paciente);
        }

        public bool ExistePaciente(String dni) /// validacion que evita repetidos
        {
            return new DaoClinica().ExistePaciente(dni);
        }

        public DataTable BuscarPacientePorDni(string dni)
        {
            DaoClinica datos = new DaoClinica();
            return datos.BuscarPacientePorDni(dni);
        }


    }
}
