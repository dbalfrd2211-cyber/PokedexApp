namespace PokedexApp
{
    public static class Sesion
    {
        public static int IdUsuarioActual { get; private set; }
        public static string NombreUsuarioActual { get; private set; }

        public static void Iniciar(int idUsuario, string nombreUsuario)
        {
            IdUsuarioActual = idUsuario;
            NombreUsuarioActual = nombreUsuario;

        }

        public static void Cerrar()
        {
            IdUsuarioActual = 0;
            NombreUsuarioActual = null;
        }

        public static bool HaySesionActiva()
        {
            return IdUsuarioActual > 0;
        }

    }
}
