using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Regiones
    {
       
        public int IdRegion { get; }
        public string NombreRegion { get; }

        public Regiones(int idRegion, string nombreRegion)
        {
            IdRegion = idRegion;
            NombreRegion = nombreRegion;
        }

    }
}
