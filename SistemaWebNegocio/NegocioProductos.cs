using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SistemaWebDatos;
using SistemaWebEntidades;
using System.Data;

namespace SistemaWebNegocio
{
    public class NegocioProductos
    {
        private DatosProductos DatProductos = new DatosProductos();
 
        public DataTable ListaCategorias()
        {
            return DatProductos.ListaCategorias();
        }

        public DataTable ListaProductos()
        {
            return DatProductos.ListaProductos();
        }

        public DataTable ListaProductosChk()
        {
            return DatProductos.ListaProductosChk();
        }

        public DataTable ListaServicios()
        {
            return DatProductos.ListaServicios();
        }

        public DataTable ListaServiciosChk()
        {
            return DatProductos.ListaServiciosChk();
        }

        public int GrabarItem(SistemaWebEntidades.Entidad Ent)
        {
            return DatProductos.GrabarItem(Ent);
        }
        public int EliminarItem(SistemaWebEntidades.Entidad Ent)
        {
            return DatProductos.EliminarItem(Ent);
        }
    }

}
