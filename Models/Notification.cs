using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Notification : ModelBase
    {
        public String ConectionStringDatabaseNotify { get; set; }
        public String Name { get; set; }
        public String TableName { get; set; }
        public List<String>  EventSupoort { get; set; }
        public String QueryCondition { get; set; }
        public List<DinamycValueQuery> DinamycValuesQueryFromEvent { get; set; }
        public List<Destination> Destination { get; set; }
    }
}
