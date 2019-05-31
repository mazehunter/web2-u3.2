using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using SistemaWebDatos;

namespace SistemaWebNegocio
{
    public class NegocioPreferencia
    {
        private DatosPreferencia DatPreferencia = new DatosPreferencia();

        public DataTable ListaPreferencia()
        {
            return DatPreferencia.ListaPreferencia();
        }    



    }
}
