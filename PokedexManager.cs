using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PokedexApp
{
    public class PokedexManager
    {
        private List<Pokemon> pokemones;
        private Database db = new Database();

        private List<Cartas> cartasObtenidas = new List<Cartas>();


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

        public InfoUsuario ObtenerInfoUsuario(int idUsuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT Nivel, PartidasGanadas, PartidasPerdidas FROM Usuarios WHERE IdUsuario = @id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InfoUsuario(
                                0,
                                idUsuario,
                                Convert.ToInt32(reader["Nivel"]),
                                Convert.ToInt32(reader["PartidasGanadas"]),
                                Convert.ToInt32(reader["PartidasPerdidas"]),
                                0
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

        public bool RegistrarUsuario(string usuario, string contraseña, string confirmar, bool esPublico = true)
        {
            if (contraseña != confirmar) return false;

            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = @"INSERT INTO Usuarios 
                        (NombreUsuario, Contrasena, EsPublico, Nivel, Experiencia, PartidasGanadas, PartidasPerdidas) 
                        VALUES (@usuario, @contrasena, @esPublico, 1, 0, 0, 0)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);
                    cmd.Parameters.AddWithValue("@esPublico", esPublico ? 1 : 0);

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
                 WHERE TRIM(LOWER(Nombre)) LIKE LOWER(@nombre)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    string filtro = "%" + nombre.Trim() + "%";
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Cartas(
                                0,
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


                string query = @"SELECT C.IdCarta, C.IdPokemon, C.HP, C.Rareza, C.NumeroColeccion, C.Imagen, P.Nombre, 
                                GROUP_CONCAT(A.Nombre ||': '||E.Descripcion, '|') AS DetallesAtaques 
                        FROM ColeccionUsuario CU 
                        JOIN Cartas C ON CU.IdPokemon = C.IdPokemon 
                        LEFT JOIN Pokemon P ON C.IdPokemon = P.IdPokemon 
                        LEFT JOIN PokemonAtaque PA ON P.IdPokemon = PA.IdPokemon 
                        LEFT JOIN Ataques A ON PA.IdAtaque = A.IdAtaque 
                        LEFT JOIN Efectos E ON A.IdEfecto = E.IdEfecto 
                        WHERE CU.IdUsuario = @idUsuario 
                        GROUP BY C.IdCarta
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

                                reader["DetallesAtaques"]?.ToString() ?? "Sin ataques",
                                // 8. imagen
                                reader["Imagen"] != DBNull.Value ? reader["Imagen"].ToString() : "default.png"
                            ));
                        }
                    }
                }
            }
            return lista;
        }

        public bool CrearNuevaCarta(int idPokemon, int hp, string rareza, int numeroDeColeccion, string nombre, string tipo1, int pokedex, int idRegion, double altura, double peso, int hpBase, List<int> idsAtaques)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                using (var transaccion = conn.BeginTransaction())
                {
                    try
                    {
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

                        string queryCarta = "INSERT INTO Cartas (IdPokemon, HP, Rareza, NumeroColeccion) VALUES (@id, @hp, @rar, @num)";
                        using (var cmd = new SQLiteCommand(queryCarta, conn, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id", idPokemon);
                            cmd.Parameters.AddWithValue("@hp", hp);
                            cmd.Parameters.AddWithValue("@rar", rareza);
                            cmd.Parameters.AddWithValue("@num", numeroDeColeccion);
                            cmd.ExecuteNonQuery();
                        }

                        if (idsAtaques != null && idsAtaques.Count > 0)
                        {
                            string queryAtaques = "INSERT INTO PokemonAtaque (IdPokemon, IdAtaque) VALUES (@id, @idAtaque)";
                            using (var cmd = new SQLiteCommand(queryAtaques, conn, transaccion))
                            {
                                foreach (var idAtaque in idsAtaques)
                                {
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.AddWithValue("@id", idPokemon);
                                    cmd.Parameters.AddWithValue("@idAtaque", idAtaque);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }




                        transaccion.Commit();
                        return true;
                    }
                    catch (Exception ex) { transaccion.Rollback();
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
                using (var cmd = new SQLiteCommand("DELETE FROM ColeccionUsuario WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand ("DELETE FROM PokemonAtaque WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new SQLiteCommand("DELETE FROM EstadisticasPokemon WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }




                using (var cmd = new SQLiteCommand("DELETE FROM Cartas WHERE IdPokemon = @idPokemon", conn))
                {
                    cmd.Parameters.AddWithValue("@idPokemon", idPokemon);
                    cmd.ExecuteNonQuery();
                }


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



        public void RegistrarResultadoBatalla(int idUsuario, bool gano)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                ActualizarProgresoUsuario(conn, idUsuario, gano);
            }
        }
        /*private void ActualizarProgresoUsuario(SQLiteConnection conn, int idUsuario, bool fueVictoria)
        {
            int nivelActual = 1;
            int expActual = 0;
            int ganadas = 0;
            int perdidas = 0;

            // Consultar estado actual
            string querySelect = "SELECT Nivel, Experiencia, PartidasGanadas, PartidasPerdidas FROM Usuarios WHERE IdUsuario = @id";
            using (var cmdSelect = new SQLiteCommand(querySelect, conn))
            {
                cmdSelect.Parameters.AddWithValue("@id", idUsuario);
                using (var reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nivelActual = Convert.ToInt32(reader["Nivel"]);
                        expActual = Convert.ToInt32(reader["Experiencia"]);
                        ganadas = Convert.ToInt32(reader["PartidasGanadas"]);
                        perdidas = Convert.ToInt32(reader["PartidasPerdidas"]);
                    }
                }
            }

            // Calcular recompensas
            if (fueVictoria)
            {
                ganadas++;
                expActual += 50; // +50 XP por ganar
            }
            else
            {
                perdidas++;
                expActual += 15; // +15 XP de consolación por perder
            }

            // Lógica de subida de nivel (XP necesaria = Nivel * 100)
            int expNecesaria = nivelActual * 100;
            bool subioDeNivel = false;

            while (expActual >= expNecesaria)
            {
                expActual -= expNecesaria;
                nivelActual++;
                expNecesaria = nivelActual * 100;
                subioDeNivel = true;
            }

            // Guardar en la Base de Datos
            string queryUpdate = @"UPDATE Usuarios 
                           SET Nivel = @nivel, Experiencia = @experiencia, 
                               PartidasGanadas = @ganadas, PartidasPerdidas = @perdidas 
                           WHERE IdUsuario = @id";

            using (var cmdUpdate = new SQLiteCommand(queryUpdate, conn))
            {
                cmdUpdate.Parameters.AddWithValue("@nivel", nivelActual);
                cmdUpdate.Parameters.AddWithValue("@experiencia", expActual);
                cmdUpdate.Parameters.AddWithValue("@ganadas", ganadas);
                cmdUpdate.Parameters.AddWithValue("@perdidas", perdidas);
                cmdUpdate.Parameters.AddWithValue("@id", idUsuario);
                cmdUpdate.ExecuteNonQuery();
            }

            // Avisar si subió de nivel
            if (subioDeNivel)
            {
                MessageBox.Show($"¡El usuario con ID {idUsuario} ha subido al Nivel {nivelActual}! 🎉", "¡Subida de Nivel!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        */

        private void ActualizarProgresoUsuario(System.Data.SQLite.SQLiteConnection conn, int idUsuario, bool fueVictoria)
        {
            int nivelActual = 1;
            int expActual = 0;
            int ganadas = 0;
            int perdidas = 0;

            string querySelect = "SELECT Nivel, Experiencia, PartidasGanadas, PartidasPerdidas FROM Usuarios WHERE IdUsuario = @id";
            using (var cmdSelect = new System.Data.SQLite.SQLiteCommand(querySelect, conn))
            {
                cmdSelect.Parameters.AddWithValue("@id", idUsuario);
                using (var reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nivelActual = reader["Nivel"] != DBNull.Value ? Convert.ToInt32(reader["Nivel"]) : 1;
                        expActual = reader["Experiencia"] != DBNull.Value ? Convert.ToInt32(reader["Experiencia"]) : 0;
                        ganadas = reader["PartidasGanadas"] != DBNull.Value ? Convert.ToInt32(reader["PartidasGanadas"]) : 0;
                        perdidas = reader["PartidasPerdidas"] != DBNull.Value ? Convert.ToInt32(reader["PartidasPerdidas"]) : 0;
                    }
                }
            }

            int nuevaExp = expActual;

            if (fueVictoria)
            {
                ganadas++;
                nuevaExp += 5; 
            }
            else
            {
                perdidas++;
            }

            int nuevoNivelCalculado = (nuevaExp / 20) + 1;
            if (nuevoNivelCalculado > 3) nuevoNivelCalculado = 3;

            bool subioDeNivel = false;
            if (nuevoNivelCalculado > nivelActual)
            {
                nivelActual = nuevoNivelCalculado;
                subioDeNivel = true;
            }

            Console.WriteLine($"=== BD DEBUG: User {idUsuario} | Exp Antigua: {expActual} | Exp Nueva: {nuevaExp} | Ganadas: {ganadas} | Perdidas: {perdidas} ===");

            string queryUpdate = @"UPDATE Usuarios 
                           SET Nivel = @nivel, Experiencia = @experiencia, 
                               PartidasGanadas = @ganadas, PartidasPerdidas = @perdidas 
                           WHERE IdUsuario = @id";

            using (var cmdUpdate = new System.Data.SQLite.SQLiteCommand(queryUpdate, conn))
            {
                cmdUpdate.Parameters.AddWithValue("@nivel", nivelActual);
                cmdUpdate.Parameters.AddWithValue("@experiencia", nuevaExp);
                cmdUpdate.Parameters.AddWithValue("@ganadas", ganadas);
                cmdUpdate.Parameters.AddWithValue("@perdidas", perdidas);
                cmdUpdate.Parameters.AddWithValue("@id", idUsuario);

                int filasAfectadas = cmdUpdate.ExecuteNonQuery();
                Console.WriteLine($"=== BD UPDATE: Filas afectadas: {filasAfectadas} ===");
            }

            if (subioDeNivel)
            {
                string beneficios = "";
                if (nivelActual == 2) beneficios = "¡Ahora puedes usar cartas Comunes y Raras en batalla! ⚔️";
                if (nivelActual == 3) beneficios = "¡Has alcanzado el rango máximo! Ya puedes usar cartas Comunes, Raras y Legendarias. 🔥";

                MessageBox.Show($"¡Felicidades! Has subido al Nivel {nivelActual} 🎉\n\n{beneficios}",
                                "¡Subida de Nivel!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public List<Cartas> AbrirSobreDiario(int idUsuario)
        {
            List<Cartas> sobre = new List<Cartas>();
            Random rnd = new Random();
            var todas = AllDatoPokemon();

            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();

                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int prob = rnd.Next(1, 101);
                            string rareza = (prob <= 70) ? "Comun" : (prob <= 95) ? "Rara" : "Legendaria";
                            var filtradas = todas.FindAll(c => c.Rareza == rareza);

                            if (filtradas.Count > 0)
                            {
                                Cartas c = filtradas[rnd.Next(filtradas.Count)];
                                sobre.Add(c);


                                string queryInsert = "INSERT INTO ColeccionUsuario (IdUsuario, IdPokemon, Cantidad) VALUES (@idU, @idP, 1)";
                                using (var cmdInsert = new SQLiteCommand(queryInsert, conn, trans))
                                {
                                    cmdInsert.Parameters.AddWithValue("@idU", idUsuario);
                                    cmdInsert.Parameters.AddWithValue("@idP", c.IdPokemon);
                                    cmdInsert.ExecuteNonQuery();
                                }
                            }
                        }

                        string queryUpdate = "UPDATE Usuarios SET FechaUltimoSobre = @fecha WHERE IdUsuario = @idU";
                        using (var cmdUpdate = new SQLiteCommand(queryUpdate, conn, trans))
                        {
                            cmdUpdate.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmdUpdate.Parameters.AddWithValue("@idU", idUsuario);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        System.Windows.Forms.MessageBox.Show("Error al guardar cartas: " + ex.Message);
                    }
                }
            }
            return sobre;
        }
        public DateTime ObtenerFechaUltimoSobre(int idUsuario)
        {
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT FechaUltimoSobre FROM Usuarios WHERE IdUsuario = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    object result = cmd.ExecuteScalar();
                    if (result != null && DateTime.TryParse(result.ToString(), out DateTime fecha))
                        return fecha;
                }
            }
            return DateTime.MinValue;
        }

        public List<Ataques> ObtenerTodosLosAtaques()
        {


            List<Ataques> lista = new List<Ataques>();
            using (var conn = new SQLiteConnection(db.cadenaConexion))
            {
                conn.Open();
                string query = "SELECT IdAtaque, Nombre, Tipo, Danio, IdEfecto FROM Ataques";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Ataques(
                          Convert.ToInt32(reader["IdAtaque"]),
                          reader["Nombre"].ToString(),
                          reader["Tipo"].ToString(),
                          Convert.ToInt32(reader["Danio"]),
                          reader["IdEfecto"] != DBNull.Value ? Convert.ToInt32(reader["IdEfecto"]) : 0
                        ));
                    }
                }
            }
            return lista;
        }
    }
}

