using Permisos.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permisos.Data.Implementation
{
    public class DBManager : IDBManager
    {
        private DatabaseHandlerFactory dbFactory;
        private IDatabaseHandler database;
        //private string providerName;

        public DBManager(string connectionString)
        {
            dbFactory = new DatabaseHandlerFactory(connectionString);
            database = dbFactory.CreateDababase();
            //providerName = dbFactory.GetProviderName();
        }

        public IDbConnection GetDatabaseConnection()
        {
            return database.CreateConnection();
        }
        public void CloseConnection(IDbConnection connection)
        {
            database.CloseConnection(connection);
        }
        public IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection)
        {
            connection = database.CreateConnection();
            connection.Open();
            var command = database.CreateCommand(commandText, commandType, connection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            IDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void Delete(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    command.ExecuteNonQuery();

                }
            }
        }
        public int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            var lastId = 0;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    object newId = command.ExecuteScalar();
                    lastId = Convert.ToInt32(newId);
                }
            }

            return lastId;
        }
    }
}
