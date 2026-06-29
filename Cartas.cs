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
        public int IdUsuario { get; set; }
        public int IdPokemon { get; set; }
        public int Hp { get; set; }
        public string Rareza { get; set; }
        public int NumeroDeColeccion { get; set; }

        public string Nombre { get; set; }
       public string DetallesAtaque { get; set; }
        public Cartas(int idCarta, int idUsuario, int idPokemon, int hp, string rareza, int numeroDeColeccion, string nombre, string detallesAtaque)
        {
            IdCarta = idCarta;
            IdPokemon = idPokemon;
            Hp = hp;
            Rareza = rareza;
            NumeroDeColeccion = numeroDeColeccion;
            Nombre = nombre;
            DetallesAtaque = detallesAtaque;
        }


    }
}
