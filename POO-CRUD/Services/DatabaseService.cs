using System;
using System.Data.SqlClient;

namespace POO_CRUD.Services
{
    public class DatabaseService
    {
        private readonly string connectionString =
            "Server=LUCAS-NOTE\\SQLEXPRESS;" +
            "Database=POO_CRUD;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;"; // Opcional p/ SSL Local

        public SqlConnection GetConnection()
        {
            try
            {
                var conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                // Log ou feedback adequado
                throw new Exception("Erro ao conectar no banco de dados.", ex);
            }
        }
    }
}
