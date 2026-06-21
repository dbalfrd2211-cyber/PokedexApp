using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class PokemonAtaque
    {
        public int IdPokemonAtaque { get; set; }
        public int IdPokemon { get; set; } 
        public int IdAtaque { get; set; }
        public PokemonAtaque(int idPokemonAtaque, int idPokemon, int idAtaque)
        {
            IdPokemonAtaque = idPokemonAtaque;
            IdPokemon = idPokemon;
            IdAtaque = idAtaque;
        }   

    }
}
