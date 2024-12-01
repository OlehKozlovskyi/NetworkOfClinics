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
        private readonly static object _locker = new();

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

        public async Task<bool> TryMakeAppointmentAsync(int dayNumber, string hour, Patient patient)
        {
            bool appointmentBook = false;
            lock (_locker)
            {
                TimeOnly time = hour.ToTimeOnly();
                if (Appointments[dayNumber][time].PatientName == "null")
                {
                    Appointments[dayNumber][time] = patient;
                    Console.WriteLine($"Appointment booked with {patient.PatientName} {patient.PatientSurname} at {time}");
                    appointmentBook = true;
                }
                else
                {
                    Console.WriteLine($"Conflict! Time {hour} is already booked by {Appointments[dayNumber][time].PatientName} {Appointments[dayNumber][time].PatientSurname}");
                    string shiftedTime = time.AddHours(1).ToString();
                    appointmentBook = TryMakeAppointmentAsync(dayNumber, shiftedTime, patient).Result;
                }
            }
            return await Task.FromResult(appointmentBook);
        }

    }
}
