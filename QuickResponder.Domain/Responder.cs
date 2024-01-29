using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Responder : User
    {
        public Guid ResponderID { get; set; }
        public List<Incident> PatientHistory { get; set; } = new List<Incident>();
    }
}
