using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        private string cadenaConexion = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Clinica_DB;Integrated Security=True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);

            return sqlConnection;
        }
    }
}

