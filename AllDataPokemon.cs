using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class AllDataPokemon
    {
        public int IdPokemon { get; set; }
        public int Pokedex { get; set; }
        public string Nombre { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }

        public int IdCarta { get; set; }
        public int HP { get; set; }
        public string Rareza { get; set; }
        public int NumeroColeccion { get; set; }

        public double Altura { get; set; }
        public double Peso { get; set; }
        public int HPBase { get; set; }

        public string NombreAtaque { get; set; }
        public int DanioAtaque { get; set; }
    }
}
