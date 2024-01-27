using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Prescription
    {
        public Guid ID { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Medication Medication { get; set; }
        public Guid MedicationId { get; set; }

        /* IMPORTANT NOTE:
         * Dosages are measured in milligrams.
         * Drugs in liquid form are measured in milligrams per milliliter.
         */
        public int Dosage { get; set; }
        public TimeSpan TimeBetweenDosages { get; set; }
    }
}
