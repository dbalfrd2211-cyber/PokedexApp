using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


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

        public bool RegistrarUsuario(string usuario, string contraseña, string confirmar)
        {

            if (contraseña != confirmar)
            {
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

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT  IdUsuario, NombreUsuario,Contrasena FROM Usuarios WHERE NombreUsuario=@nombre";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombreUsuario);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario(
                                Convert.ToInt32(reader["IdUsuario"]),
                                reader["NombreUsuario"].ToString(),
                                reader["Contrasena"].ToString()
                            //Convert.ToBoolean(reader["EsPublico"])
                            );

                        }
                    }
                }

            }
            return null;

        }

        public InfoUsuario ObtenerInfoUsuario(int idUsuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT IdInfo, IdUsuario, Nivel, BatallasGanadas, BatallasPerdidas, NumeroCartas FROM InfoUsuario WHERE IdUsuario=@id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InfoUsuario(
                                Convert.ToInt32(reader["IdInfo"]),
                                Convert.ToInt32(reader["IdUsuario"]),
                                Convert.ToInt32(reader["Nivel"]),
                                Convert.ToInt32(reader["BatallasGanadas"]),
                                Convert.ToInt32(reader["BatallasPerdidas"]),
                                Convert.ToInt32(reader["NumeroCartas"])
                            );
                        }
                    }
                }
            }
            return null;
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





        public List<Cartas> BuscarCartasPorNombre(string nombre)
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                // Agregamos el JOIN para obtener el Nombre y el alias necesario
                string query = @"SELECT C.*, P.Nombre 
                         FROM Cartas C
                         JOIN Pokemon P ON C.IdPokemon = P.IdPokemon
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
                                Convert.ToInt32(reader["HP"]),
                                reader["Rareza"].ToString(),
                                Convert.ToInt32(reader["NumeroColeccion"]),
                                reader["Nombre"].ToString(),
                                "Sin ataques"
                            ));
                        }
                    }
                }
            }
            return lista;
        }


        public bool AgregarCartaColeccion(int idPokemon, int hp, string rareza, int numeroDeColeccion)
        {
            if (!Sesion.HaySesionActiva())
            {
                return false;
            }
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon)VALUES(@idUsuario, @idPokemon)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuarioActual);
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    return cmd.ExecuteNonQuery() > 0;

                }


            }
        }


        public List<Cartas> AllDatoPokemon()
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                // Usamos LEFT JOIN para no perder ninguna carta, incluso si no tienen ataques asociados
                string query = @"SELECT C.IdCarta, C.IdPokemon, C.HP, C.Rareza, C.NumeroColeccion, P.Nombre, 
                                GROUP_CONCAT(A.Nombre ||': '||E.Descripcion, '|') AS DetallesAtaques
                         FROM Cartas C
                         LEFT JOIN Pokemon P ON C.IdPokemon = P.IdPokemon
                         LEFT JOIN PokemonAtaque PA ON P.IdPokemon = PA.IdPokemon
                         LEFT JOIN Ataques A ON PA.IdAtaque = A.IdAtaque
                         LEFT JOIN Efectos E ON A.IdEfecto = E.IdEfecto
                         GROUP BY C.IdCarta";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Cartas(
                            Convert.ToInt32(reader["IdCarta"]),
                            Convert.ToInt32(reader["IdPokemon"]),
                            Convert.ToInt32(reader["HP"]),
                            reader["Rareza"].ToString(),
                            Convert.ToInt32(reader["NumeroColeccion"]),
                            reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : "Desconocido",
                            reader["DetallesAtaques"] != DBNull.Value ? reader["DetallesAtaques"].ToString() : "Sin ataques"
                        ));
                    }
                }
            }
            return lista;
        }

            public VistaCartasMaestra ObtenerDetallesCarta(int idPokemon)

        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT * FROM VistaCartasMaestra WHERE IdPokemon=@id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idPokemon);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new VistaCartasMaestra(
                                reader["Nombre"].ToString(),
                                Convert.ToInt32(reader["IdPokemon"]),
                                Convert.ToInt32(reader["Pokedex"]),
                                reader["Tipo1"].ToString(),
                                reader["Tipo2"] != DBNull.Value ? reader["Tipo2"].ToString() : "Ninguno",
                                reader["Region"] != DBNull.Value ? reader["Region"].ToString() : "Desconocida",
                                reader["Altura"] != DBNull.Value ? Convert.ToDouble(reader["Altura"]) : 0,
                                reader["Peso"] != DBNull.Value ? Convert.ToDouble(reader["Peso"]) : 0,
                                reader["HPBase"] != DBNull.Value ? Convert.ToInt32(reader["HPBase"]) : 0,
                                Convert.ToInt32(reader["HP"]),
                                reader["Rareza"].ToString(),
                                Convert.ToInt32(reader["NumeroColeccion"]),
                                 reader["DetallesAtaques"] != DBNull.Value ? reader["DetallesAtaques"].ToString() : "Sin ataques"
                                 );
                        }
                    }
                }

            }

            return null;
        }



        public List<Cartas> ObtenerCartasUsuario(int idUsuario)
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT C.IdCarta, C.IdPokemon, C.HP, C.Rareza, C.NumeroColeccion, P.Nombre
                               FROM ColeccionUsuario CU
                               JOIN Cartas C ON CU.IdPokemon = C.IdPokemon
                               JOIN Pokemon P ON C.IdPokemon = P.IdPokemon
                               WHERE CU.IdUsuario = @idUsuario
                               ORDER BY C.NumeroColeccion";

                using (var cmd = new SQLiteCommand(query, conn))
                {

                    
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cartas(
                                Convert.ToInt32(reader["IdCarta"]),
                                Convert.ToInt32(reader["IdPokemon"]),
                                Convert.ToInt32(reader["HP"]),
                                reader["Rareza"].ToString(),
                                Convert.ToInt32(reader["NumeroColeccion"]),
                                reader["Nombre"].ToString(),
                                "Sin ataques"
                            ));
                        }
                    }
                }
            }
            return lista;
        }
    }

   
}







//data.NombreAtaque = reader["NombreAtaque"] != DBNull.Value ? reader["NombreAtaque"].ToString() : "Ninguno";
//data.DanioAtaque = reader["DanioAtaque"] != DBNull.Value ? Convert.ToInt32(reader["DanioAtaque"]) : 0;
//lista.Add(data);
//return null;
//return lista;