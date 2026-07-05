using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioProvincia
    {

        public DataTable GetTablaProvincia()
        {
            DataTable tablaProvincias = new DaoClinica().ListarProvincias();

            return tablaProvincias;
        }

        public DataTable GetTablaLocalidadPorProvincia(int idProvincia)
        {
            DataTable tablaLocalidades = new DaoClinica().ListarLocalidadesPorProvincia(idProvincia);

            return tablaLocalidades;
        }
    }
}