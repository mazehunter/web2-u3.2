using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaWebDatos
{
    public class DatosProductos
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
               

       public DataTable ListaCategorias()
       {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_CATEGORIA_LISTA", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
       }

       public DataTable ListaProductos()
       {
           DataTable Tabla = new DataTable();
           SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_PRODUCTOS", cnx);
           sda.SelectCommand.CommandType = CommandType.StoredProcedure;
           sda.Fill(Tabla);
           sda = null;
           return Tabla;
       }

       public DataTable ListaProductosChk()
       {
           DataTable Tabla = new DataTable();
           SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_PRODUCTOS_CHK", cnx);
           sda.SelectCommand.CommandType = CommandType.StoredProcedure;
           sda.Fill(Tabla);
           sda = null;
           return Tabla;
       }


       public DataTable ListaServicios()
       {
           DataTable Tabla = new DataTable();
           SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_SERVICIOS", cnx);
           sda.SelectCommand.CommandType = CommandType.StoredProcedure;
           sda.Fill(Tabla);
           sda = null;
           return Tabla;
       }

       public DataTable ListaServiciosChk()
       {
           DataTable Tabla = new DataTable();
           SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_SERVICIOS_CHK", cnx);
           sda.SelectCommand.CommandType = CommandType.StoredProcedure;
           sda.Fill(Tabla);
           sda = null;
           return Tabla;
       }

       public int GrabarItem(SistemaWebEntidades.Entidad Ent)
       {
           SqlCommand cmd = new SqlCommand("SP_ITEM_GRABA", cnx);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@IdItem", Ent.Iditem);
           cmd.Parameters.AddWithValue("@Nombre", Ent.Nombre);
           cmd.Parameters.AddWithValue("@Precio", Ent.Precio);
           cmd.Parameters.AddWithValue("@TipoDeItem", Ent.Tipodeitem);
           cmd.Parameters.AddWithValue("@IdCategoria", Ent.Idcategoria);
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



       public int EliminarItem(SistemaWebEntidades.Entidad Ent)
       {
           SqlCommand cmd = new SqlCommand("SP_ITEM_ELIMINA", cnx);
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@IdItem", Ent.Iditem);
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
