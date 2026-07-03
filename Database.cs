


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

