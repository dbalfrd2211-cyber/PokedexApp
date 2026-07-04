namespace PokedexApp
{
    public class Cartas : PokedexElement
    {
        public int IdCarta { get; set; }
        public int IdPokemon { get; set; }
        public int Hp { get; set; }
        public string Rareza { get; set; }
        public int NumeroDeColeccion { get; set; }
        public string DetallesAtaque { get; set; }
        public string Imagen { get; set; }


        public Cartas(int idCarta, int idPokemon, int hp, string rareza, int numeroDeColeccion, string nombre, string detallesAtaque, string imagen)
        {
            this.Id = idCarta;
            this.Nombre = nombre;

            this.IdCarta = idCarta;
            this.IdPokemon = idPokemon;
            this.Hp = hp;
            this.Rareza = rareza;
            this.NumeroDeColeccion = numeroDeColeccion;
            this.DetallesAtaque = detallesAtaque;
            this.Imagen = imagen;
        }

        public override string ObtenerDetalles()
        {
            return $"Carta: {Nombre} | HP: {Hp} | Rareza: {Rareza}";
        }
    }
}