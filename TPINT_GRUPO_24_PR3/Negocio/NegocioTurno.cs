using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioTurno
    {


        public bool AgregarTurno(int legajo, int idPaciente, DateTime fecha, TimeSpan hora)
        {
            DaoClinica dao = new DaoClinica();
            return dao.AgregarTurno(legajo, idPaciente, fecha, hora);
        }

    }
}
