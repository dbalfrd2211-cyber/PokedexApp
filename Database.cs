using System.Data.SQLite;



namespace PokedexApp

{
    public class Database
    {
        public string cadenaConexion = "Data Source=PokemonTCGI.db;Version=3;";

        public SQLiteConnection ObtenerConexion()
        {
            return new SQLiteConnection(cadenaConexion);
        }
    }
}

