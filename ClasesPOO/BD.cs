using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ClasesPOO
{
    public static class DB
    {
        // String conexión a la base de datos Garbarino
        private const string CONNECTION_STRING =
            "Server=localhost;Database=Garbarino;Uid=root;Pwd=;";

        // Insertar un electrodoméstico
        public static bool GuardarElectrodomestico(Electrodomestico electrodomestico)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query;

                    if (electrodomestico is Lavadora lavadora)
                    {
                        query = "INSERT INTO Electrodomesticos (Tipo, Marca, Modelo, ConsumoBaseWatts, CapacidadKilos, TipoLavadora) " +
                                "VALUES ('Lavadora', @Marca, @Modelo, @Consumo, @Capacidad, @TipoLavadora)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Marca", lavadora.marca);
                            command.Parameters.AddWithValue("@Modelo", lavadora.modelo);
                            command.Parameters.AddWithValue("@Consumo", lavadora.consumoBaseWatts);
                            command.Parameters.AddWithValue("@Capacidad", lavadora.CapacidadKilos);
                            command.Parameters.AddWithValue("@TipoLavadora", lavadora.Tipo.ToString());

                            command.ExecuteNonQuery();
                        }
                    }
                    else if (electrodomestico is Televisor televisor)
                    {
                        query = "INSERT INTO Electrodomesticos (Tipo, Marca, Modelo, ConsumoBaseWatts, Pulgadas, Resolucion) " +
                                "VALUES ('Televisor', @Marca, @Modelo, @Consumo, @Pulgadas, @Resolucion)";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Marca", televisor.marca);
                            command.Parameters.AddWithValue("@Modelo", televisor.modelo);
                            command.Parameters.AddWithValue("@Consumo", televisor.consumoBaseWatts);
                            command.Parameters.AddWithValue("@Pulgadas", televisor.Pulgadas);
                            command.Parameters.AddWithValue("@Resolucion", televisor.Resolucion.ToString());

                            command.ExecuteNonQuery();
                        }
                    }

                    Console.WriteLine($"Electrodoméstico guardado en la base de datos: {electrodomestico.marca} {electrodomestico.modelo}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar: {ex.Message}");
                return false;
            }
        }

        //CONTAR electrodomésticos
        public static int ContarElectrodomesticos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Electrodomesticos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        int cantidad = Convert.ToInt32(command.ExecuteScalar());
                        Console.WriteLine($"Total de electrodomésticos en BD: {cantidad}");
                        return cantidad;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al contar: {ex.Message}");
                return 0;
            }
        }

        // contar lavadoras
        public static int ContarLavadoras()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Electrodomesticos WHERE Tipo = 'Lavadora'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al contar lavadoras: {ex.Message}");
                return 0;
            }
        }

        // contar televisores 
        public static int ContarTelevisores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Electrodomesticos WHERE Tipo = 'Televisor'";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al contar televisores: {ex.Message}");
                return 0;
            }
        }

        // ELIMINAR un electrodoméstico por ID
        public static bool EliminarElectrodomestico(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "DELETE FROM Electrodomesticos WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int filasEliminadas = command.ExecuteNonQuery();

                        if (filasEliminadas > 0)
                        {
                            Console.WriteLine($"Electrodoméstico ID {id} eliminado correctamente.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró electrodoméstico con ID {id}.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error al eliminar: {ex.Message}");
                return false;
            }
        }

        // ELIMINAR TODOS los electrodomésticos 
        public static bool EliminarTodosElectrodomesticos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "DELETE FROM Electrodomesticos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        int filasEliminadas = command.ExecuteNonQuery();
                        Console.WriteLine($"Se eliminaron {filasEliminadas} electrodomésticos.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar todos: {ex.Message}");
                return false;
            }
        }


        // obtener el consumo total de todos los electrodomésticos
        public static decimal ObtenerConsumoTotal()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "SELECT SUM(ConsumoBaseWatts) FROM Electrodomesticos";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object resultado = command.ExecuteScalar();

                        if (resultado != DBNull.Value && resultado != null)
                        {
                            decimal consumoTotal = Convert.ToDecimal(resultado);
                            Console.WriteLine($"Consumo total de todos los electrodomésticos: {consumoTotal} watts");
                            return consumoTotal;
                        }

                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener consumo total: {ex.Message}");
                return 0;
            }
        }

        // ver si existe un electrodoméstico por ID
        public static bool ExisteElectrodomestico(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Electrodomesticos WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int cantidad = Convert.ToInt32(command.ExecuteScalar());
                        return cantidad > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar existencia: {ex.Message}");
                return false;
            }
        }

        
        }
    }