using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SistemaWebDatos
{
    public class DatosPedidos
    {
        private SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);


        public DataTable ListaPedidoXIdPedido(SistemaWebEntidades.Entidad Ent)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_PEDIDOS_X_IDPEDIDO", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Idpedido", Ent.Idpedido);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

        public DataTable ListaPedidoXUsuario(SistemaWebEntidades.Entidad EntUsuario)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_PEDIDOS_X_USUARIO", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@IdUsuario", EntUsuario.Idusuario);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

        public DataTable ListaPedidoDetalle(SistemaWebEntidades.Entidad Ent)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_PEDIDO_DETALLE_LISTA", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@IdPedido", Ent.Idpedido);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }
              
        public DataTable ListaItemXId(SistemaWebEntidades.Entidad Ent)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_X_ID", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@IdItem", Ent.Iditem);
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

        public DataTable ListaItem()
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SP_ITEM_LISTA", cnx);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.Fill(Tabla);
            sda = null;
            return Tabla;
        }

        public int GrabarPedido(SistemaWebEntidades.Entidad Ent)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDOS_GRABA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPedido", Ent.Idpedido);
            cmd.Parameters.AddWithValue("@IdUsuario", Ent.Idusuario);
            cmd.Parameters.AddWithValue("@FechaReg", Ent.FechaReg);
            cmd.Parameters.AddWithValue("@FormaPago", Ent.Formapago);
            cmd.Parameters.AddWithValue("@FormaEnvio", Ent.Formaenvio);
            cmd.Parameters.AddWithValue("@Direccion", Ent.Direccion);
            cmd.Parameters.AddWithValue("@Telefono", Ent.Telefono);
            try
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }
                cnx.Open();
                int Retorno =int.Parse(cmd.ExecuteScalar().ToString());
                return Retorno;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int GrabarPedidoDetalle(SistemaWebEntidades.Entidad Ent)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDO_DETALLE_GRABA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPedido", Ent.Idpedido);
            cmd.Parameters.AddWithValue("@IdItem", Ent.Iditem);
            cmd.Parameters.AddWithValue("@Cantidad", Ent.Cantidad);
            cmd.Parameters.AddWithValue("@Precio", Ent.Precio);
            cmd.Parameters.AddWithValue("@Importe", Ent.Importe);
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

        public int EliminarPedido(SistemaWebEntidades.Entidad Ent)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDOS_ELIMINA", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPedido", Ent.Idpedido);
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

        public int ComprarPedido(SistemaWebEntidades.Entidad Ent)
        {
            SqlCommand cmd = new SqlCommand("SP_PEDIDOS_COMPRAR", cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPedido", Ent.Idpedido);
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
