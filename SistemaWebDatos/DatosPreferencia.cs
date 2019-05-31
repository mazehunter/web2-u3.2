using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaWebDatos
{
    public class DatosPreferencia
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

        public DataTable ListaPreferencia()
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_PREFERENCIA_LISTA", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }       
 


    }
}
