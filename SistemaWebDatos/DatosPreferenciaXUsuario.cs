using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SistemaWebEntidades;
using System.Data;
using System.Data.SqlClient;

namespace SistemaWebDatos
{
    public class DatosPreferenciaXUsuario
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

        public int Grabar(SistemaWebEntidades.Entidad EntPrefxUsu)
        {
            SqlCommand cmd = new SqlCommand("SP_PREFERENCIAXUSUARIO_GRABA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TipoPreferencia", EntPrefxUsu.Tipopreferencia);
            cmd.Parameters.AddWithValue("@Login", EntPrefxUsu.Login);
            try
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cnx.Open();
                int Retorno = cmd.ExecuteNonQuery();
                return Retorno;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

               
        public int EliminaXIdUsuario(SistemaWebEntidades.Entidad EntPrefxUsu)
        {
            SqlCommand cmd = new SqlCommand("SP_PREFERENCIAXUSUARIO_ELIMINA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idusuario", EntPrefxUsu.Idusuario);
            try
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cnx.Open();
                int Retorno = cmd.ExecuteNonQuery();
                return Retorno;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }






    }
}
