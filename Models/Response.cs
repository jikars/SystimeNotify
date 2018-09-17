using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Response
    {
        public int CodHttp { get; set; }
        public String MessageUser { get; set; }
        public String MessageDev { get; set; }
        public Object ObjectResponse { get; set; }
    }
}
