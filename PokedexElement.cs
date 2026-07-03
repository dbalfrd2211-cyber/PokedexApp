namespace PokedexApp
{
    public abstract class PokedexElement
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        protected PokedexElement() { }

        public abstract string ObtenerDetalles();
    }



}



