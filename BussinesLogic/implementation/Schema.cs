using BussinesLogic.interfaces;
using DataAccess.interfaces;
using Models;
using SchemaDataBase.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.implementation
{
    public class Schema : ISchema
    {
        private ISchemaTable _schemaDb { get; set; } = DepenFactory.ResolveInstance<ISchemaTable>();
        private ILiteDb _liteDb { get; set; } = DepenFactory.ResolveInstance<ILiteDb>();
        private String _conectionString { get; set; } = DepenFactory.ResolveInstance<String>("conectionString");
        private String _dataBase { get; set; } = DepenFactory.ResolveInstance<String>("dataBase");


        public List<Colum> GetAllColumDataBase(string tableName)
        {
            if(_liteDb.GetAll<TableSupport>().First(t => t.Name == tableName) != null)
            {
                List<String> columKeys = _schemaDb.GetColumKeys(_conectionString, _dataBase, tableName);
                return (from colum in _schemaDb.GetAllColumFromTable(_conectionString, _dataBase, tableName)
                        select new Colum() { TableName = tableName,ColumName = colum, IsKey = columKeys.Contains(colum) }).ToList();
            }
            return new List<Colum>();      
        }

        public List<Colum> GetAllColumKey(string tableName)
        {
            if (_liteDb.GetAll<TableSupport>().First(t => t.Name == tableName) != null)
            {
                 return (from colum in _schemaDb.GetColumKeys(_conectionString, _dataBase, tableName)
                        select new Colum() { TableName = tableName, ColumName = colum, IsKey = true  }).ToList();
            }
            return new List<Colum>();
        }

        public List<Table> GetAllTablesDataBase()
        {
            return (from table in _schemaDb.GetAllTableFromDatabase(_conectionString, _dataBase)
                    where _liteDb.GetAll<TableSupport>().First(t => t.Name == table) != null
                    select new Table() { Name = table }).ToList();
        }
    }
}

