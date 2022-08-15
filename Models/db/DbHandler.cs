using System.Data;
using System.Data.SqlClient;

namespace DesafioC13.Models.db
{
    abstract public class DbHandler
    {

        readonly private string ConnectionString = "Server=localhost; Database=SistemaGestion; Trusted_Connection=True";
        readonly public string Table;

        public DbHandler(string TableName)
        {
            Table = TableName;
        }

        public DataSet GetAll()
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM " + Table;

            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    connection.Open();
                    adapter.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + Table + ":");
                Console.WriteLine(e);
            }

            return ds;
        }

        public virtual DataSet GetByField(string field, string value)
        {
            DataSet ds = new DataSet();
            string query = "SELECT * FROM " + Table + " WHERE " + field + " = '" + value + "'";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    connection.Open();
                    adapter.Fill(ds);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + Table + ":");
                Console.WriteLine(e);
            }
            return ds;
        }

        public virtual DataSet GetById(int id)
        {
            return GetByField("Id", id.ToString());
        }

        public virtual void editById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void deleteById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM " + Table + " WHERE Id=@Id";

                    SqlParameter sqlParameter = new SqlParameter("Id", SqlDbType.BigInt);
                    sqlParameter.Value = id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteScalar();
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en consulta a Tabla " + Table + ":");
                Console.WriteLine(e);
            }
        }
    }
}
