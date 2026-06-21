using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Ataques
    {
        
        public int IdAtaque { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Daño { get; set; }
        public int IdEfecto { get; set; }
        public Ataques(int idAtaque, string nombre, string tipo, int daño, int idEfecto)
        {
            IdAtaque = idAtaque;
            Nombre = nombre;
            Tipo = tipo;
            Daño = daño;
            IdEfecto = idEfecto;
        }

    }
}
