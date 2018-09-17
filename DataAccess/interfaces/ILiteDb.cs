using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.interfaces
{
    public interface ILiteDb 
    {
        List<T> GetAll<T>() where T : ModelBase;
        T GetId<T>(int id) where T: ModelBase;
        T Insert<T>(T entity) where T: ModelBase;
        T Update<T>(T entityUpdate) where T: ModelBase;
        Boolean DeleteByEntity<T>(T entityuDelete) where T : ModelBase;
        Boolean DeleteById<T>(int id) where T : ModelBase;
    }
}
