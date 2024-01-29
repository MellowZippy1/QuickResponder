using QuickResponder.Domain;
using QuickResponder.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace QuickResponder.Console
{
    public class Program
    {
        public static void Main()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseSqlite("Data Source=F:\\TestDbs\\QuickResponder.db")
               .Options;
            var context = new ApplicationDbContext(contextOptions);

            var devices = GetObjects<MedicalDevice>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Devices.json");
            var conditions = GetObjects<MedicalCondition>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Conditions.json");
            var allergies = GetObjects<Allergy>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Allergies.json");
            var vaccines = GetObjects<Vaccine>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Vaccines.json");
            var names = GetObjects<string>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Names.json");
            var birthDates = GetObjects<DateOnly>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Dates.json");
            var religions = GetObjects<string>("C:\\Users\\Basic\\source\\repos\\QuickResponder\\QuickResponder.Console\\Source\\Religions.json");

            List<Patient> patients = new List<Patient>();
            List<Responder> responders = new List<Responder>();

            for (int i = 0; i < 10; i++)
            {
                patients.Add(new Patient()
                {
                    FullName = names[i],
                    Password = names[i] + i.ToString(),
                    Email = names[i] + "@gmail.com",
                    Phone = i.ToString(),
                    Gender = (Genders)(i % 3),
                    DateOfBirth = birthDates[i],
                    PostalCode = names[i].Substring(0, 4).ToString() + (i * 10).ToString(),
                    Prescriptions = new List<Prescription>(),
                    MedicalEquipment = new List<MedicalDevice>() { devices[i] },
                    MedicalConditions = new List<MedicalCondition>() { conditions[i] },
                    Allergies = new List<Allergy>() { allergies[i] },
                    BloodType = (BloodType)(i % 7),
                    Religion = religions[i % 5],
                    VaccineHistory = new List<Vaccine>() { vaccines[i] },
                    Incidents = new List<Incident>()
                });
            }

            Random random = new Random(0);

            for (int i = 10; i < 15; i++)
            {
                // Create responder
                var responder = new Responder() {
                    FullName = names[i],
                    Password = names[i] + i.ToString(),
                    Email = names[i] + "@gmail.com",
                    Phone = i.ToString(),
                    PatientHistory = new List<Incident>()
                };

                // Create incident
                var incident = new Incident()
                {
                    Responder = responder,
                    ResponderID = responder.ID
                };

                // Pick patient
                int idx = random.Next(0, patients.Count);
                var patient = patients[idx];

                // Update incident
                incident.Patient = patient;
                incident.PatientID = patient.ID;

                // Update responder and patient
                responder.PatientHistory.Add(incident);
                patient.Incidents.Add(incident);
            }

            // Add dummy data
            foreach (var patient in patients)
            {
                context.Patients.Add(patient);
                context.SaveChanges();
            }

            foreach (var responder in responders)
            {
                context.Responders.Add(responder);
                context.SaveChanges();
            }

            // Try to retrieve patients

            // Try to retrieve responders

            // Try to retrieve allergies of a patient

            // Get accident history of a patient

        }

        private static List<T> GetObjects<T>(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<T> listOfObj = JsonConvert.DeserializeObject<List<T>>(json);
                return listOfObj;
            }
        }
    }
}