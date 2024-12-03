using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using NetworkOfPrivateClinics.CustomExceptions;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;

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

        public DailyRoutine this[int numberOfDay]
        {
            get
            {
                if(!Appointments.ContainsKey(numberOfDay))
                    throw new InvalidDaysNumberToMakeAppointmentException(numberOfDay.ToString());
                return Appointments[numberOfDay];
            }
        }

        public async Task<bool> TryMakeAppointmentAsync(int dayNumber, TimeOnly hour, Patient patient)
        {
            var appointmentBook = false;
            if (Appointments[dayNumber][hour].PatientName == "null")
            {
                Appointments[dayNumber][hour] = patient;
                appointmentBook = true;
            }
            return await Task.FromResult(appointmentBook);
        }

    }
}
