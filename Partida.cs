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
        public int Fecha { get; set; }

        public Partida(int idPartida, int idJugador1, int idJugador2, int ganador, int fecha)
        {
            IdPartida = idPartida;
            IdJugador1 = idJugador1;
            IdJugador2 = idJugador2;
            Ganador = ganador;
            Fecha = fecha;
        }



    }
}
