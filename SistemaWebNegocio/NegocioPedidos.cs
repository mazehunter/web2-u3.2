using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaWebDatos;
using SistemaWebEntidades;
using System.Data;

namespace SistemaWebNegocio
{
    public class NegocioPedidos
    {
        private DatosPedidos DatPedidos = new DatosPedidos();

        public DataTable ListaPedidoXUsuario(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.ListaPedidoXUsuario(Ent);
        }

        public DataTable ListaPedidoDetalle(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.ListaPedidoDetalle(Ent);
        }

        public DataTable ListaItem()
        {
            return DatPedidos.ListaItem();
        }

        public int GrabarPedido(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.GrabarPedido(Ent);
        }

        public int GrabarPedidoDetalle(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.GrabarPedidoDetalle(Ent);
        }
        
        public DataTable ListaItemXId(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.ListaItemXId(Ent);
        }

        public int EliminarPedido(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.EliminarPedido(Ent);
        }

        public DataTable ListaPedidoXIdPedido(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.ListaPedidoXIdPedido(Ent);
        }

        public int ComprarPedido(SistemaWebEntidades.Entidad Ent)
        {
            return DatPedidos.ComprarPedido(Ent);
        }
    }
}
