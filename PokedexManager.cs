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
        private Database db = new Database(); // Usas tu clase Database aquí

        public PokedexManager()
        {
            pokemones = new List<Pokemon>();
        }

        public bool ValidarCredenciales(string usuario, string contraseña)
        {

            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario AND Contrasena = @contrasena";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    return Convert.ToInt32(cmd.ExecuteScalar())>0;
                     
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

        public bool RegistrarUsuario(string usuario, string contraseña)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO Usuarios (NombreUsuario, Contrasena)VALUES(@usuario, @contrasena)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena",contraseña);
                    return cmd.ExecuteNonQuery() > 0;

                }
            }



        }
    }


}


