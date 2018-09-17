using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Message
    {
        public String TypeNotification { get; set; }
        public String MessageValue { get; set; }
        public List<Variable> VariablesMessage { get; set; }
    }
}
