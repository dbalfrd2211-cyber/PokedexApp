using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class Cartas
    {
        
        public int IdCarta { get; set; }
        public int IdPokemon { get; set; }
        public int Hp { get; set; }
        public string Rareza { get; set; }
        public int NumeroDeColeccion { get; set; }

        public Cartas(int idCarta, int idPokemon, int hp, string rareza, int numeroDeColeccion)
        {
            IdCarta = idCarta;
            IdPokemon = idPokemon;
            Hp = hp;
            Rareza = rareza;
            NumeroDeColeccion = numeroDeColeccion;
        }


    }
}
