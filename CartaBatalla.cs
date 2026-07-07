using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class CartaBatalla : Cartas
    {
        public int HpActual { get; set; }

        public int ModificadorAtaque { get; set; }
        public int ModificadorDefensa { get; set; }
        public int ModificadorVelocidad { get; set; }
        public int ModificadorEspecial { get; set; }

        public string Estado { get; set; } = "Normal"; 
        public int TurnosDormido { get; set; }
        public bool TieneReflejo { get; set; }
        public int TurnosReflejo { get; set; }
        public bool TieneDrenadoras { get; set; }

        public CartaBatalla(Cartas cartaBase) : base(cartaBase.IdCarta,             
                                                     cartaBase.IdPokemon,           
                                                     cartaBase.Hp,                  
                                                     cartaBase.Rareza,              
                                                     cartaBase.NumeroDeColeccion,   
                                                     cartaBase.Nombre,              
                                                     cartaBase.DetallesAtaque,      
                                                     cartaBase.Imagen)
        {
            this.HpActual = cartaBase.Hp;
            this.ModificadorAtaque = 0;
            this.ModificadorDefensa = 0;
            this.ModificadorVelocidad = 0;
            this.ModificadorEspecial = 0;
            this.Ataques = cartaBase.Ataques;
        }
    }
}
