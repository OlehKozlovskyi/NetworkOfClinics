using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.BisinessLogic
{
    public enum DoctorType
    {
        Neurologist,
        Gastroenterologist,
        Cardiology,
        Oncologist,
        Psychiatrist,
        Dermatologist,
        Anasthesiologist
    }

    public class Doctor
    {

        [JsonConstructor]
        public Doctor(int id, string name, string surname, DoctorType type, decimal costOfPermissiom, Dictionary<int, DailyRoutine> appointment)
        {
            DoctorID = id;
            DoctorsName = name;
            DoctorsSurname = surname;
            Type = type;
            CostOfAdmission = costOfPermissiom;
            Appointments = appointment;
        }

        public int DoctorID { get; set; }
        public string DoctorsName { get; set; }
        public string DoctorsSurname { get; set; }
        public DoctorType Type { get; set; }
        public decimal CostOfAdmission { get; set; }
        public Dictionary<int, DailyRoutine> Appointments { get; set; }

    }
}
