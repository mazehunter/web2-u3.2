using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SistemaWebDatos;
using SistemaWebEntidades;
using System.Data;

namespace SistemaWebNegocio
{
    public class NegocioUsuario
    {
        private DatosUsuario DatUsuario = new DatosUsuario();

        public int Grabar(Entidad EntUsuario)
        {
            return DatUsuario.Grabar(EntUsuario);
        }

        public int Existe(Entidad EntUsuario)
        {
            return DatUsuario.Existe(EntUsuario);
        }

        public DataTable Sesion(SistemaWebEntidades.Entidad EntUsuario)
        {
            return DatUsuario.Sesion(EntUsuario);
        }

        public DataTable UsuarioListado(SistemaWebEntidades.Entidad EntUsuario)
        {
            return DatUsuario.UsuarioListado(EntUsuario);
        }
    }
}
