using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Partida
    {

        public int IdPartida { get; set; }
        public int IdJugador1 { get; set; }
        public int IdJugador2 { get; set; }
        public int Ganador { get; set; }
        public DateTime Fecha { get; set; }

      
    }
}
