using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.interfaces
{
    public interface ISchema
    {
        List<Table> GetAllTablesDataBase();
        List<Colum> GetAllColumDataBase(string tableName);
        List<Colum> GetAllColumKey(string tableName);
    }
}
