
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.BusinessLogic
{
    public class Clinic
    {
        [JsonConstructor]
        public Clinic(int id, string name, string location, List<Doctor> doctors)
        {
            ClinicID = id;
            ClinicsName = name;
            Location = location;
            Doctors = doctors;
        }

        public int ClinicID { get; set; }
        public string ClinicsName { get; set; }
        public string Location { get; set; }
        public IReadOnlyList<Doctor> Doctors { get; set; }
    }
}
