using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class Data
    {
        public Data()
        {
            InitDoctorsList();
            InitClinicsList();
            InitPatientList();
        }

        public List<Clinic> Clinics { get; set; }
        private List<List<Doctor>> Doctors { get; set; }
        private List<Patient> Patients { get; set; }

        #region Hardcoding data for lists
        private void InitClinicsList()
        {
            Clinics = new List<Clinic>() 
            {
                new Clinic(
                    id: 14311554,
                    name:"Central Family Clinic",
                    location:"123 Main Street, Anytown, CA 12345",
                    doctors:Doctors[0]),
                new Clinic(
                    id: 23312554,
                    name: "Oak Ridge Medical Center",
                    location:"456 Oak Ridge Avenue, Oak Ridge, TN 67890",
                    doctors:Doctors[1]),
                new Clinic(
                    id: 11234567,
                    name: "Pine Valley Wellness Center",
                    location: "789 Pine Valley Road, Pine Valley, AZ 54321",
                    doctors:Doctors[2]),
            };
        }

        private void InitDoctorsList() 
        {
            var validator = new AppointmentsValidator("8:00", "17:00");
            Doctors =
            [
                new List<Doctor>()
                {
                    new DoctorsFactory(1234, "Alice", "Johnson", DoctorType.Neurologist, 100m, 
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor(),
                    new DoctorsFactory(1345, "Bob", "Smith", DoctorType.Gastroenterologist, 150m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor(),
                    new DoctorsFactory(1245, "Charlie", "Brown", DoctorType.Cardiology, 120m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor(),
                    new DoctorsFactory(1235, "David", "Lee", DoctorType.Anasthesiologist, 180m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor()
                },
                new List<Doctor>()
                {
                    new DoctorsFactory(2134, "Emily", "Davis", DoctorType.Neurologist, 90m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor(),
                    new DoctorsFactory(2234, "Frank", "Miller", DoctorType.Anasthesiologist, 110m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor(),
                    new DoctorsFactory(2334, "Grace", "Wilson", DoctorType.Dermatologist, 160m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor(),
                    new DoctorsFactory(2445, "Henry", "Moore", DoctorType.Gastroenterologist, 130m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor(),
                },
                new List<Doctor>()
                {
                    new DoctorsFactory(3123, "Isabella", "Taylor", DoctorType.Cardiology, 140m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor(),
                    new DoctorsFactory(3223, "Jack", "Anderson", DoctorType.Oncologist, 170m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor(),
                    new DoctorsFactory(3344, "Kate", "Thomas", DoctorType.Anasthesiologist, 105m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor(),
                    new DoctorsFactory(3356, "Mia", "Martin", DoctorType.Dermatologist, 150m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor(),
                },
            ];
        }

        private void InitPatientList()
        {
            Patients = new List<Patient>() 
            {
                new Patient(
                    id: 1,
                    name: "Ivan",
                    surname: "Petrov",
                    email: "petrov@gmail.com",
                    phoneNumber: "+380 99 123 4567"),
                new Patient(
                    id: 2,
                    name: "Olena",
                    surname:"Kovalenko",
                    email:"kovalenko@gmail.com",
                    phoneNumber:"+380 67 543 2109"),
                new Patient(
                    id: 3,
                    name: "Mykola",
                    surname:"Shevchenko",
                    email:"shevchenko@gmail.com",
                    phoneNumber:"+380 95 876 5432"),
                new Patient(
                    id: 4,
                    name: "Oksana",
                    surname:"Marchenko",
                    email:"oksana@gmail.com",
                    phoneNumber:"+380 63 123 4567"),
                new Patient(
                    id: 5,
                    name: "Andriy",
                    surname:"Melnyk",
                    email:"melnyk@gmail.com",
                    phoneNumber:"+380 97 543 2109"),
                new Patient(
                    id: 6,
                    name: "Natali",
                    surname:"Timoshenko",
                    email:"nata@gmail.com",
                    phoneNumber:"+380 99 876 5432"),
                new Patient(
                    id: 7,
                    name: "Dmytro",
                    surname:"Kondratyuk",
                    email:"kondratyuk@gmail.com",
                    phoneNumber:"+380 67 123 4567"),
                new Patient(
                    id: 8,
                    name: "Iryna",
                    surname:"Kravchenko",
                    email:"iryna654@gmail.com",
                    phoneNumber:"+380 95 543 2109"),
                new Patient(
                    id: 9,
                    name: "Viktor",
                    surname:"Yakovenko",
                    email:"yakovenko@gmail.com",
                    phoneNumber:"+380 99 876 5432"),
            };
        }
        #endregion

    }
}
