using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PokedexApp
{
    public class Pokemon

    {
       
        public int IdPokemon { get; set; }
        public int Pokedex { get; set; }
        public string  Nombre { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public int IdRegion { get; set; }


        public Pokemon(int idPokemon, int pokedex, string nombre, string tipo1, string tipo2, int idRegion)
        {
            IdPokemon = idPokemon;
            Pokedex = pokedex;
            Nombre = nombre;
            Tipo1 = tipo1;
            Tipo2 = tipo2;
            IdRegion = idRegion;
        }


    }
}
