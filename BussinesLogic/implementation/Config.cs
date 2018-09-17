using BussinesLogic.interfaces;
using DataAccess.interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.implementation
{
    public class Config : IConfig
    {
        private ILiteDb _liteDb { get; set; } = DepenFactory.ResolveInstance<ILiteDb>();

        public bool AddConfigTable(TableSupport tableSupport)
        {
            return _liteDb.Insert(tableSupport) != null;     
        }

        public List<TableSupport> GetAllTeableSupport()
        {
            return _liteDb.GetAll<TableSupport>();
        }

        public bool RemoveConfigTableByName(string name)
        {
            return _liteDb.DeleteByEntity(_liteDb.GetAll<TableSupport>().First(t => t.Name == name));
        }
    }
}
