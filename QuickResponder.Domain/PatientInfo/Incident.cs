using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Incident
    {
        public Guid ID { get; set; }
        public Patient Patient { get; set; }
        public Guid PatientID { get; set; }
        public Responder Responder { get; set; }
        public Guid ResponderID { get; set; }
    }
}
