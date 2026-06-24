using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SQLite;


namespace PokedexApp
{
    public class PokedexManager
    {
        private List<Pokemon> pokemones;
        private string connectionString = "Data Source=PokemonTCG.db;Version=3"; //aqui va mi base de datos, pero aun no se como subirla

        public PokedexManager()
        {
            pokemones = new List<Pokemon>();
           // CargarPokemonesDesdeDB();

        }

        public bool ValidarCredenciales(string usuario, string contraseña)
        {

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario AND Contraseña = @contraseña";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0; //retorna true si se encontró un usuario con las credenciales proporcionadas, de lo contrario false
                }
            }
        }

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


