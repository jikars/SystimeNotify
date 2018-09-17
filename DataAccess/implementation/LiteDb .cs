using DataAccess.interfaces;
using LiteDB;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace DataAccess.implementation
{
    public class LiteDb : ILiteDb
    {
        private String _conectionString { get; set; } = DepenFactory.ResolveInstance<String>("conectionString");

        public bool DeleteByEntity<T>(T entityuDelete) where T : ModelBase
        {
            throw new NotImplementedException();
        }
         
        public bool DeleteById<T>(int id) where T:ModelBase
        {
            using (var db = new LiteDatabase(_conectionString))
            {
                var collection = db.GetCollection<T>(typeof(T).Name);
                return collection.Delete(i => i.Id == id) == 1;
            }
        }

        public List<T> GetAll<T>() where T : ModelBase
        {
            using (var db = new LiteDatabase(_conectionString))
            {
                var collection = db.GetCollection<T>(typeof(T).Name);
                return collection.FindAll().ToList();
            }
        }

        public T GetId<T>(int id) where T : ModelBase
        {
            using (var db = new LiteDatabase(_conectionString))
            {
                var collection = db.GetCollection<T>(typeof(T).Name);
                return collection.FindById(id);
            }
        }

        public T Insert<T>(T entity) where T : ModelBase
        {
            using (var db = new LiteDatabase(_conectionString))
            {
                var collection = db.GetCollection<T>(typeof(T).Name);
                if(collection.Insert(entity) > 0)
                {
                    return entity;
                }
                return default(T);
            }
        }

        public T Update<T>(T entityUpdate) where T : ModelBase
        {
            using (var db = new LiteDatabase(_conectionString))
            {
                var collection = db.GetCollection<T>(typeof(T).Name);
                if (collection.Update(entityUpdate))
                {
                    return collection.FindById(entityUpdate.Id);
                }
                return default(T);
            }
        }
    }
}
