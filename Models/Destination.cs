using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Destination
    {
        public String Name { get; set; }
        public String Table { get; set; }
        public String Query { get; set; }
        public List<DinamycValueQuery> DinamycValuesQueryFromEvent { get; set; }
        public Message Message { get; set; }
    }
}
