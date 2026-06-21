using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Efectos
    {
     

        public  int IdEfecto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Efectos(int idEfecto, string nombre, string descripcion)
        {
            IdEfecto = idEfecto;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
