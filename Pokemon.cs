namespace PokedexApp
{
    public sealed class Pokemon : PokedexElement
    {
        public int Pokedex { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public int IdRegion { get; set; }

        // El constructor inicializa al hijo y hereda del padre
        public Pokemon(int id, string nombre, int pokedex, string tipo1, string tipo2, int idRegion)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Pokedex = pokedex;
            this.Tipo1 = tipo1;
            this.Tipo2 = tipo2;
            this.IdRegion = idRegion;
        }

        // Implementación del método de la clase base
        public override string ObtenerDetalles()
        {
            return $"#{Pokedex} - {Nombre} | Tipo: {Tipo1} {Tipo2}";
        }
    }
}
