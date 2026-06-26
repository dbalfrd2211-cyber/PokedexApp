using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    public class Usuario
    {
        public InfoUsuario Info { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        //public bool EsPublico { get; set; }

        public Usuario(int idUsuario, string nombreUsuario, string contraseña)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            //EsPublico = esPublico;
        }
    }
}
