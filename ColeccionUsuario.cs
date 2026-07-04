namespace PokedexApp
{
    internal class ColeccionUsuario
    {

        public int IdUsuario { get; set; }
        public int IdPokemon { get; set; }
        public int Cantidades { get; set; }

        public ColeccionUsuario(int idUsuario, int idPokemon, int cantidades)
        {
            IdUsuario = idUsuario;
            IdPokemon = idPokemon;
            Cantidades = cantidades;
        }


    }
}
