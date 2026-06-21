using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Pokemon

    {  
        //Nombre, Hp, Tipo, Puntos de ataque, Puntos de defensa, Numero de carta, Descripción. 

        
        public string Nombre { get; }
        public int Hp { get; }
        public string Tipo { get; }
        public int PuntosDeAtaque { get; }
        public int PuntosDeDefensa { get; }
        public int NumeroDeCarta { get; }
        public string Descripción { get; }
        public Pokemon(string nombre, int hp, string tipo, int puntosDeAtaque, int puntosDeDefensa, int numeroDeCarta, string descripción)
        {
            
            Nombre = nombre;
            Hp = hp;
            Tipo = tipo;
            PuntosDeAtaque = puntosDeAtaque;
            PuntosDeDefensa = puntosDeDefensa;
            NumeroDeCarta = numeroDeCarta;
            Descripción = descripción;
        }



    }
}
