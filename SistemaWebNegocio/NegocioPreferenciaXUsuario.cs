using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using SistemaWebDatos;
using SistemaWebEntidades;

namespace SistemaWebNegocio
{
    public class NegocioPreferenciaXUsuario
    {
        private DatosPreferenciaXUsuario DatPrefxUsu = new DatosPreferenciaXUsuario();

        public void Grabar(List<Entidad> EntPrefxUsuLista)
        {
            Entidad EntPrefxUsu=new Entidad();
            for (int i = 0; i < EntPrefxUsuLista.Count ; i++)
            {
                EntPrefxUsu.Tipopreferencia = EntPrefxUsuLista.ElementAt(i).Tipopreferencia;
                EntPrefxUsu.Login = EntPrefxUsuLista.ElementAt(i).Login;
                DatPrefxUsu.Grabar(EntPrefxUsu);
            }
        }

        public int EliminaXIdUsuario(SistemaWebEntidades.Entidad EntPrefxUsu)
        {
            return DatPrefxUsu.EliminaXIdUsuario(EntPrefxUsu);
        }
    }
}
