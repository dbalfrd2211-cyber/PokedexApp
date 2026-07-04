namespace PokedexApp
{
    internal class EstadisticasPokemon
    {
        public int IdPokemon { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public int HPBase { get; set; }

        public EstadisticasPokemon(int idPokemon, double altura, double peso, int hPBase)
        {
            IdPokemon = idPokemon;
            Altura = altura;
            Peso = peso;
            HPBase = hPBase;
        }


    }
}
