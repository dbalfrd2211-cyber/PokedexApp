using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 

namespace PokedexApp
{
    internal class PokedexManager
    {
        private List<Pokemon> pokemones;
        private string connectionString = "Data Source=pokedex.db;Version=3"; //aqui va mi base de datos, pero aun no se como subirla

        public PokedexManager()
        {
            pokemones = new List<Pokemon>();
           // CargarPokemonesDesdeDB();

        }
        //añadir base de datos, pero aun  no se como
        /*
        private void CargarPokemonesDesdeDB()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT*FROM Pokemon";
                using (var cmd = new SQLiteComand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pokemones.Add(new Pokemon(
                            Convert.ToInt32(reader["IdPokemon"]),
                            Convert.ToInt32(reader["Pokedex"]),
                            reader["Nombre"].ToString(),
                            reader["Tipo1"].ToString(),
                            reader["Tipo2"].ToString(),
                            Convert.ToInt32(reader["IdRegion"]),
                             Convert.ToInt32(reader["IdRegion"])
                          ));




                    }
                }

            }
        }
        */
        public Pokemon BuscarPokemon(string texto)
            => pokemones.FirstOrDefault(p =>
            p.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0);

        public List<Pokemon> FindPorTipo(string tipo)
        {
            return pokemones.FindAll(p =>
            (p.Tipo1 != null && p.Tipo1.IndexOf(tipo, StringComparison.OrdinalIgnoreCase) >= 0) ||
            (p.Tipo2 != null && p.Tipo2.IndexOf(tipo, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        public void MostrarDetalle(int index)
        {
            if (index >= 0 && index < pokemones.Count)
            {
                Pokemon p = pokemones[index];
                Console.WriteLine($"\nDetalles del Pokémon:");
                Console.WriteLine($"Tipo:{p.Tipo1}/{p.Tipo2}");



            }
        }
    }


}


