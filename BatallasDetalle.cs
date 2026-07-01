using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class BatallasDetalle
    {
        public int IdDetalle { get; set; }
        public int IdPartida { get; set; }
        public int IdUsuarioGanador { get; set; }
        public int IdPokemonUsado { get; set; }
        public int IdPokemonRival { get; set; }
        public BatallasDetalle(int idDetalle, int idPartida, int idUsuarioGanador, int idPokemonUsado, int idPokemonRival)
        {
            IdDetalle = idDetalle;
            IdPartida = idPartida;
            IdUsuarioGanador = idUsuarioGanador;
            IdPokemonUsado = idPokemonUsado;
            IdPokemonRival = idPokemonRival;
        }


    }
}
