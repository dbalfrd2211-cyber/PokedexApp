namespace PokedexApp
{
    public class Cartas
    {

        public int IdCarta { get; set; }
        public int IdPokemon { get; set; }
        public int Hp { get; set; }
        public string Rareza { get; set; }
        public int NumeroDeColeccion { get; set; }
      
        public string Nombre { get; set; }
        public string DetallesAtaque { get; set; }
        public string Imagen { get; set; }
        public Cartas(int idCarta, int idPokemon, int hp, string rareza, int numeroDeColeccion, string nombre, string detallesAtaque, string imagen)
        {
            IdCarta = idCarta;
            
            IdPokemon = idPokemon;
            Hp = hp;
            Rareza = rareza;
            NumeroDeColeccion = numeroDeColeccion;
            Nombre = nombre;
            DetallesAtaque = detallesAtaque;
            Imagen = imagen;
        }


    }
}
