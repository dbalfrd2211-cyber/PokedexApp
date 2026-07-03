using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class VistaCartasMaestra:PokedexElement
    {

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

        public VistaCartasMaestra(string nombre, int idPokemon, int pokedex, string tipo1, string tipo2,
                                  string region, double altura, double peso, int hpBase, int hpCarta,
                                  string rareza, int numColeccion, string detalles)
        {
            this.Nombre = nombre;      
            this.Id = idPokemon;       

            this.IdPokemon = idPokemon;
            this.Pokedex = pokedex;
            this.Tipo1 = tipo1;
            this.Tipo2 = tipo2;
            this.Region = region;
            this.Altura = altura;
            this.Peso = peso;
            this.HPBase = hpBase;
            this.HPCarta = hpCarta;
            this.Rareza = rareza;
            this.NumeroColeccion = numColeccion;
            this.DetallesAtaques = detalles;
        }

        public override string ObtenerDetalles()
        {
            return $"#{Pokedex} - {Nombre} ({Region})";
        }
    }
}
