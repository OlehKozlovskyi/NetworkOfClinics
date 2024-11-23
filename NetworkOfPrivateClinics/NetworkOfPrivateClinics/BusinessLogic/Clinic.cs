
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.BisinessLogic
{
    public class Clinic
    {
        [JsonConstructor]
        public Clinic(int id, string name, string location, List<Doctor> doctors)
        {
            ClinicID = id;
            Name = name;
            Location = location;
            Doctors = doctors;
        }

        public int ClinicID { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public IReadOnlyList<Doctor> Doctors { get; private set; }
    }
}
