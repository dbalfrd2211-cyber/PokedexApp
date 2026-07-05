using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;

namespace PokedexApp
{
    public class PokedexManager
    {
        private List<Pokemon> pokemones;
        private Database db = new Database();

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

        // Método 1: ObtenerUsuario
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT IdUsuario, NombreUsuario, Contrasena FROM Usuarios WHERE NombreUsuario=@nombre";
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
                            );
                        }
                    }
                }
            }
            return null;
        }

        // Método 2: ObtenerInfoUsuario
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
        public bool ExisteUsuario(string usuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string queryValidar = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @usuario";
                using (var cmdValidar = new SQLiteCommand(queryValidar, conn))
                {
                    cmdValidar.Parameters.AddWithValue("@usuario", usuario);
                    return Convert.ToInt32(cmdValidar.ExecuteScalar()) > 0;
                }
            }
        }

        public bool RegistrarUsuario(string usuario, string contraseña, string confirmar)
        {
            if (contraseña != confirmar) return false;
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO Usuarios (NombreUsuario, Contrasena) VALUES (@usuario, @contrasena)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<Cartas> BuscarCartasPorNombre(string nombre)
        {
            var lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT IdPokemon, HP, Rareza, NumeroColeccion, Nombre, DetallesAtaques 
                                 FROM VistaCartasMaestra 
                                 WHERE LOWER(Nombre) LIKE LOWER(@nombre)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cartas(
                                0, // IdCarta (no existe en la vista)
                                Convert.ToInt32(reader["IdPokemon"]),
                                Convert.ToInt32(reader["HP"]),
                                reader["Rareza"].ToString(),
                                Convert.ToInt32(reader["NumeroColeccion"]),
                                reader["Nombre"].ToString(),
                                reader["DetallesAtaques"]?.ToString() ?? "Sin ataques",
                                "default.png"
                            ));
                        }
                    }
                }
            }
            return lista;
        }

        public List<Cartas> AllDatoPokemon()
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT C.IdCarta, C.IdPokemon, C.HP, C.Rareza, C.NumeroColeccion, C.Imagen, P.Nombre, 
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
                            reader["Nombre"].ToString(),
                            reader["DetallesAtaques"]?.ToString() ?? "Sin ataques",
                            reader["Imagen"] != DBNull.Value ? reader["Imagen"].ToString() : "default.png"
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
                                reader["DetallesAtaques"]?.ToString() ?? "Sin ataques"
                            );
                        }
                    }
                }
            }
            return null;
        }
        public bool AgregarCartaColeccion(int idPokemon, int hp, string rareza, int numeroDeColeccion)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon) VALUES (@idUsuario, @idPokemon)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuarioActual);
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }

        }
        public List<Cartas> ObtenerCartasUsuario(int idUsuario)
        {
            List<Cartas> lista = new List<Cartas>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT C.IdCarta, C.IdPokemon, C.HP, C.Rareza, C.NumeroColeccion, P.Nombre, C.Imagen
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
                                "Sin ataques",
                                reader["Imagen"] != DBNull.Value ? reader["Imagen"].ToString() : "default.png"
                            ));
                        }
                    }
                }
            }
            return lista;
        }
        public bool CrearNuevaCarta(int idPokemon, int hp, string rareza, int numeroDeColeccion, string nombre, string tipo1, int pokedex, int idRegion, double altura, double peso, int hpBase)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insertar en Pokemon
                        string queryPokemon = "INSERT INTO Pokemon (IdPokemon, Pokedex, Nombre, Tipo1, IdRegion) VALUES (@id, @dex, @nom, @t1, @region)";
                        using (var cmd = new SQLiteCommand(queryPokemon, conn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@region", idRegion);
                            cmd.Parameters.AddWithValue("@id", idPokemon);
                            cmd.Parameters.AddWithValue("@dex", pokedex);
                            cmd.Parameters.AddWithValue("@nom", nombre);
                            cmd.Parameters.AddWithValue("@t1", tipo1);
                           //cmd.Parameters.AddWithValue("@altura", altura);
                           //cmd.Parameters.AddWithValue("@peso", peso);
                           //cmd.Parameters.AddWithValue("@hpbase", hpBase);
                            cmd.ExecuteNonQuery();
                        }
                        string queryEstadisticas = "INSERT INTO EstadisticasPokemon (IdPokemon, Altura, Peso,HPBase) VALUES (@id, @altura, @peso, @hpbase)";
                        using (var cmd = new SQLiteCommand(queryEstadisticas, conn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idPokemon);
                            cmd.Parameters.AddWithValue("@altura", altura);
                            cmd.Parameters.AddWithValue("@peso", peso);
                            cmd.Parameters.AddWithValue("@hpbase", hpBase);
                            cmd.ExecuteNonQuery();
                        }
                        // 2. Insertar en Cartas
                        string queryCarta = "INSERT INTO Cartas (IdPokemon, HP, Rareza, NumeroColeccion) VALUES (@id, @hp, @rar, @num)";
                        using (var cmd = new SQLiteCommand(queryCarta, conn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idPokemon);
                            cmd.Parameters.AddWithValue("@hp", hp);
                            cmd.Parameters.AddWithValue("@rar", rareza);
                            cmd.Parameters.AddWithValue("@num", numeroDeColeccion);
                            cmd.ExecuteNonQuery();
                        }
                        transaccion.Commit();
                        return true;
                    }
                    catch(Exception ex){ transaccion.Rollback();
                        System.Windows.Forms.MessageBox.Show("Erro SQL : " + ex.Message);
                        return false; }
                }
            }
        }
        public bool EliminarCartaUsuario(int idUsuario, int idPokemon)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "DELETE FROM ColeccionUsuario WHERE IdUsuario = @idUsuario AND IdPokemon = @idPokemon";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", Sesion.IdUsuarioActual);
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool EliminarCarta(int idPokemon)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                // Según tu PDF página 27, el método espera idCarta y idPokemon
                
                using (var cmd = new SQLiteCommand("DELETE FROM ColeccionUsuario WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }

                //string query = "DELETE FROM Cartas WHERE IdPokemon = @idPokemon";
                using (var cmd = new SQLiteCommand("DELETE FROM Cartas WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }
                
                //string query = "DELETE FROM Pokemon WHERE IdPokemon = @idPokemon";
                using (var cmd = new SQLiteCommand("DELETE FROM Pokemon WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    return cmd.ExecuteNonQuery() > 0;
                }

            }
        }

        public List<Ataques> ObtenerAtaquesDePokemon(int idPokemon)
        {
            List<Ataques> lista = new List<Ataques>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"SELECT A.IdAtaque, A.Nombre, A.Tipo, A.Danio, A.IdEfecto
                                 FROM PokemonAtaque PA
                                 JOIN Ataques A ON PA.IdAtaque = A.IdAtaque
                                 
                                 WHERE PA.IdPokemon = @id";
                using (var cmd = new SQLiteCommand(query, conn)) //JOIN Efectos E ON A.IdEfecto = E.IdEfecto
                {
                    cmd.Parameters.AddWithValue("@id", idPokemon);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ataques(
                                Convert.ToInt32(reader["IdAtaque"]),
                                reader["Nombre"].ToString(),
                                reader["Tipo"].ToString(),
                                Convert.ToInt32(reader["Danio"]),
                                //Convert.ToInt32(reader["Precision"]),
                                //reader["Descripcion"].ToString()
                                reader["IdEfecto"] != DBNull.Value ? Convert.ToInt32(reader["IdEfecto"]) : 0
                            ));
                        }
                    }
                }
            }
            return lista;
        }
}
}


