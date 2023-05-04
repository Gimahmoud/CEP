using Npgsql;
namespace CEP.Utils
{

    public class ConexaoBanco
    {

        public static NpgsqlConnection ConectaBanco()
        {
            var connStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5432,
                Username = "postgres",
                Password = "123456",
                Database = "postgres"

            };

            NpgsqlConnection connection = new NpgsqlConnection(connStringBuilder.ConnectionString);
            connection.Open();
            return connection;

        }


    }
}
