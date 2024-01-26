using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Patient : User
    {
        public Guid ID { get; set; } 
    }
}
