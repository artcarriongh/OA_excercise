using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Permisos.Data.Interfaces;
using Permisos.Data.Implementation;

namespace Permisos.Data
{
    public class DatabaseHandlerFactory
    {
        private string connectionStringSettings;
        public DatabaseHandlerFactory(string connectionString)
        {
            connectionStringSettings = connectionString;
        }

        public IDatabaseHandler CreateDababase()
        {
            IDatabaseHandler database = new SqlDataAccess(connectionStringSettings);
            return database;
        }

        //public string GetProviderName()
        //{
        //    return connectionStringSettings.ProviderName;
        //}
    }
}
