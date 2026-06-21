using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PokedexApp
{
    internal class Pokemon

    {
        public int IdPokemon { get; }
        public string  Nombre { get; }
        public string Tipo1 { get; }
        public string Tipo2 { get; }
        public int IdRegion { get; }

        public Pokemon(int idPokemon, string nombre, string tipo1, string tipo2, int idRegion)
        {
            IdPokemon = idPokemon;
            this.Nombre = nombre;
            Tipo1 = tipo1;
            this.Tipo2 = tipo2;
            IdRegion = idRegion;
        }


    }
}
