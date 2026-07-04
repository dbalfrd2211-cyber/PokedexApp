namespace PokedexApp
{
    public class Regiones
    {

        public int IdRegion { get; }
        public string NombreRegion { get; }

        public Regiones(int idRegion, string nombreRegion)
        {
            IdRegion = idRegion;
            NombreRegion = nombreRegion;
        }

    }
}
