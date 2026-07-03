using Datos;
using System.Data;

namespace Negocio
{
    public class NegocioProvincia
    {

        public DataTable getTablaProvincia()
        {
            DataTable tablaProvincias = new DaoClinica().ListarProvincias();

            return tablaProvincias;
        }

        public DataTable getTablaLocalidadPorProvincia(int idProvincia)
        {
            DataTable tablaLocalidades = new DaoClinica().ListarLocalidadesPorProvincia(idProvincia);

            return tablaLocalidades;
        }
    }
}