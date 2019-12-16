using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permisos.Data.Interfaces
{
    public interface IDatabaseHandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection connection);
        IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection);
        IDataAdapter CreateAdapter(IDbCommand command);
        IDbDataParameter CreateParamenter(IDbCommand command);
    }
}
