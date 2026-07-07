namespace PokedexApp
{
    public class Usuario
    {
        public InfoUsuario Info { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        //public bool EsPublico { get; set; }

        public int Nivel { get; set; }
        public int Experiencia { get; set; }

        public Usuario(int idUsuario, string nombreUsuario, string contraseña, int nivel = 1, int experiencia = 0)
        {
            IdUsuario = idUsuario;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Nivel = nivel;
            Experiencia = experiencia;
        }
    }
}
