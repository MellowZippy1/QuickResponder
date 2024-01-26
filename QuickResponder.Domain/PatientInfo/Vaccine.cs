using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Vaccine
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateOnly VaccineTakenAt { get; set; }
    }
}
