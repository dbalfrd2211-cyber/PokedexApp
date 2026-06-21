using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class TransaccionDeCartas
    {
        
        public int IdTransaccion { get; set; }
        public int IdUsuarioEmisor { get; set; }
        public int IdUsuarioReceptor { get; set; }
        public int IdPokemonEntregado { get; set; }
        public int IdPokemonRecibido { get; set; }

        public TransaccionDeCartas(int idTransaccion, int idUsuarioEmisor, int idUsuarioReceptor, int idPokemonEntregado, int idPokemonRecibido)
        {
            IdTransaccion = idTransaccion;
            IdUsuarioEmisor = idUsuarioEmisor;
            IdUsuarioReceptor = idUsuarioReceptor;
            IdPokemonEntregado = idPokemonEntregado;
            IdPokemonRecibido = idPokemonRecibido;
        }

    }
}
