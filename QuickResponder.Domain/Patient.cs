using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickResponder.Domain
{
    public class Patient : User
    {
        /*
         * Important patient information based on article from Mayo Clinic.
         * https://www.mayoclinic.org/first-aid/emergency-health-information/basics/art-20134333
         */
        public Guid ID { get; set; }
        
        /*
         * Patient name can be found in parent class.
         */

        public Genders Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PostalCode { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public List<MedicalDevice> MedicalEquipment { get; set; } = new List<MedicalDevice>();
        public List<MedicalCondition> MedicalConditions { get; set; } = new List<MedicalCondition>();
        public List<Allergy> Allergies { get; set; } = new List<Allergy>();
        
        /*
         * Additional information
         */ 
         
        public BloodType BloodType { get; set; }
        public string Religion { get; set; }
        public List<Vaccine> VaccineHistory { get; set; } = new List<Vaccine>();

        //                 Name | Phone number
        public Dictionary<string, string> EmergencyContacts = new Dictionary<string, string>();
    }
}
