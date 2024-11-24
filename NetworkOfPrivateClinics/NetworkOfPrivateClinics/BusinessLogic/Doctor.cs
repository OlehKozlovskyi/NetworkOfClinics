using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

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
        public Doctor(int id, string name, string surname, DoctorType type, decimal costOfPermissiom, Dictionary<int, DailyRoutine> appointment)
        {
            DoctorID = id;
            DoctorsName = name;
            DoctorsSurname = surname;
            Type = type;
            CostOfAdmission = costOfPermissiom;
            Appointments = appointment;
        }

        public int DoctorID { get; private set; }
        public string DoctorsName { get; private set; }
        public string DoctorsSurname { get; private set; }
        public DoctorType Type { get; private set; }
        public decimal CostOfAdmission { get; private set; }
        public Dictionary<int, DailyRoutine> Appointments { get; private set; }

    }
}
