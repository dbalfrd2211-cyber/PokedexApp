using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexApp
{
    internal class Usuario
    {
         public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
         public bool Espublico { get; set; }

        public Usuario(int idUsuario, string nombreUsuario, string contraseña, bool espublico)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Espublico = espublico;
        }
    }
}
