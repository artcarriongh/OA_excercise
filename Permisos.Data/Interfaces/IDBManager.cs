using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permisos.Data.Interfaces
{
    public interface IDBManager
    {
        IDbConnection GetDatabaseConnection();
        void CloseConnection(IDbConnection connection);
        IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection);
        void Delete(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters);
    }
}
