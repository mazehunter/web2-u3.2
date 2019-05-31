using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaWebDatos
{
    public class DatosUsuario
    {

     private SqlConnection cnx =new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

        public int Grabar(SistemaWebEntidades.Entidad EntUsuario)
        {
            SqlCommand cmd=new SqlCommand("SP_USUARIO_GRABA",cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", EntUsuario.Nombre);
            cmd.Parameters.AddWithValue("@ApePat", EntUsuario.Apepat);
            cmd.Parameters.AddWithValue("@ApeMat", EntUsuario.Apemmat);
            cmd.Parameters.AddWithValue("@Login", EntUsuario.Login);
            cmd.Parameters.AddWithValue("@Password", EntUsuario.Password);
            cmd.Parameters.AddWithValue("@Email", EntUsuario.Email);
            cmd.Parameters.AddWithValue("@Celular", EntUsuario.Celular);
            cmd.Parameters.AddWithValue("@Telefono", EntUsuario.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", EntUsuario.Direccion);
            cmd.Parameters.AddWithValue("@Idperfil", EntUsuario.Idperfil);
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

        public int Existe(SistemaWebEntidades.Entidad EntUsuario)
        {
            int Retorno = 0;
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_USUARIO_BUSCA_X_LOGIN", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Login", EntUsuario.Login);
            sda.Fill(Tabla);
            Retorno = Tabla.Rows.Count;
            sda = null;
            return Retorno;
        }
        
        public DataTable Sesion(SistemaWebEntidades.Entidad EntUsuario)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_USUARIO_SESION", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Login", EntUsuario.Login);
            sda.SelectCommand.Parameters.AddWithValue("@Password", EntUsuario.Password);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

        public DataTable UsuarioListado(SistemaWebEntidades.Entidad EntUsuario)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_USUARIO_LISTADO", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@IdUsuario", EntUsuario.Idusuario);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

    }
}
