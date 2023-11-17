using System;
using System.Data;
using System.Data.SqlClient;

public class AppDbAdapter
{
    public readonly string _connectionString;

    public AppDbAdapter(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(sql, connection))
        {
            connection.Open();
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            command.ExecuteNonQuery();
        }
    }

    public T ExecuteScalar<T>(string sql, SqlParameter[] parameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(sql, connection))
        {
            connection.Open();
            if (parameters != null)
                command.Parameters.AddRange(parameters);
            return (T)command.ExecuteScalar();
        }
    }

    public SqlDataReader ExecuteReader(string sql, SqlParameter[] parameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(sql, connection))
        {
            connection.Open();
            if (parameters != null)
                command.Parameters.AddRange(parameters);

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }

}
