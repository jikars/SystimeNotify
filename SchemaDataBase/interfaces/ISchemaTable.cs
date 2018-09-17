using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaDataBase.interfaces
{
    public interface ISchemaTable
    {
        List<String> GetAllTableFromDatabase(String conectionString, String databaseName);
        DataTable ExecuteQuery(String conectionString, String query);
        List<String> GetAllColumFromTable(String conectionString, String databaseName, String tableName);
        List<String> GetColumKeys(String conectionString, String databaseName, String tableName);
    }
}
