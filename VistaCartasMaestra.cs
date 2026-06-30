using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class VistaCartasMaestra
    {
       

        public string Nombre { get; set; }
        public int IdPokemon { get; set; }
        public int Pokedex { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public string Region { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int HPBase { get; set; }
        public int HPCarta { get; set; }
        public string Rareza { get; set; }
        public int NumeroColeccion { get; set; }
        public string DetallesAtaques { get; set; }


        public VistaCartasMaestra(string nombre, int idPokemon, int pokedex, 
            string tipo1, string tipo2, string region, double altura, double peso,
            int hPBase, int hPCarta, string rareza, int numeroColeccion, 
            string detallesAtaques)
        {
            Nombre = nombre;
            IdPokemon = idPokemon;
            Pokedex = pokedex;
            Tipo1 = tipo1;
            Tipo2 = tipo2;
            Region = region;
            Altura = altura;
            Peso = peso;
            HPBase = hPBase;
            HPCarta = hPCarta;
            Rareza = rareza;
            NumeroColeccion = numeroColeccion;
            DetallesAtaques = detallesAtaques;
        }





    }
}
