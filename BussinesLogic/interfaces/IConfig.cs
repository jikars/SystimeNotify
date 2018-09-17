using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.interfaces
{
    public interface IConfig
    {
        Boolean AddConfigTable(TableSupport tableSupport);
        Boolean RemoveConfigTableByName(String name);
        List<TableSupport> GetAllTeableSupport();
    }
}
