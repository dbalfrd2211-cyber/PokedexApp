using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;


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
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;

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

        public bool RegistrarUsuario(string usuario, string contraseña, string confirmar)
        {

            if (contraseña != confirmar)
            {
                MessageBox.Show("Las contraseñas no son iguales");

                return false;
            }

            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();

                string query = "INSERT INTO Usuarios (NombreUsuario, Contrasena)VALUES(@usuario, @contrasena)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    return cmd.ExecuteNonQuery() > 0;

                }
            }



        }

        public bool ExisteUsuario(string usuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();

                string queryValidar = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                using (var cmdValidar = new SQLiteCommand(queryValidar, conn))
                {
                    cmdValidar.Parameters.AddWithValue("@usuario", usuario);
                    int conteo = Convert.ToInt32(cmdValidar.ExecuteScalar());

                    if (conteo > 0)
                    {
                        return true; // Detiene el método de inmediato porque el usuario ya está ocupado
                    }
                }
            }

            return false;
        }

        public List<Cartas> BuscarCartasPorNombre(string nombre)
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT C.* FROM Cartas C
                    JOIN Pokemon P ON C.IdPokemon= P.IdPokemon
                    WHERE P.Nombre LIKE @nombre";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cartas(
                                Convert.ToInt32(reader["IdCarta"]),
                                Convert.ToInt32(reader["IdPokemon"]),
                                Convert.ToInt32(reader["Hp"]),
                                reader["Rareza"].ToString(),
                                Convert.ToInt32(reader["NumeroColeccion"])

                                ));
                        }
                    }
                }
            }
            return lista;
        }

        public bool AgregarCartaColeccion(int idPokemon, int hp, string rareza, int numeroDeColeccion)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon)VALUES(@idUsuario, @idPokemon)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", 1);
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    return cmd.ExecuteNonQuery() > 0;

                }


            }
        }


    }
}



