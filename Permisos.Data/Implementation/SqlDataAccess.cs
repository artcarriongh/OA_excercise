using Permisos.Data.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Permisos.Data.Implementation
{
    public class SqlDataAccess : IDatabaseHandler
    {
        private string ConnectionString;
        public SqlDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public void CloseConnection(IDbConnection connection)
        {
            var sqlConnection = (SqlConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new SqlCommand
            {
                CommandText = commandText,
                CommandType = commandType,
                Connection = (SqlConnection)connection
            };
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);    
        }

        public IDbDataParameter CreateParamenter(IDbCommand command)
        {
            SqlCommand SQLcommand = (SqlCommand)command;
            return SQLcommand.CreateParameter();
        }
    }
}
