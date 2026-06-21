using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class InfoUsuario
    {
        public int IdInfo{get; set; }
        public int IDUsuario { get; set; }
        public int Nivel { get; set; }
        public int BatallasGanadas { get; set; }
        public int BatallasPerdidas { get; set; }
        public int NumeroCartas { get; set; }

        public InfoUsuario(int idInfo, int iDUsuario, int nivel, int batallasGanadas, int batallasPerdidas, int numeroCartas)
        {
            IdInfo = idInfo;
            IDUsuario = iDUsuario;
            Nivel = nivel;
            BatallasGanadas = batallasGanadas;
            BatallasPerdidas = batallasPerdidas;
            NumeroCartas = numeroCartas;
        }
    }
}
