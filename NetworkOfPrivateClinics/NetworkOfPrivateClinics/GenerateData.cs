using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public static class GenerateData
    {
        public static List<Clinic> Clinics { get; set; }
        public static List<List<Doctor>> Doctors { get; set; }
        public static List<Patient> Patients { get; set; }

        static GenerateData()
        {
            InitDoctorsList();
            InitClinicsList();
            InitPatientList();
        }

        private static void InitClinicsList()
        {
            Clinics = new List<Clinic>() 
            {
                new Clinic(
                    name:"Central Family Clinic",
                    location:"123 Main Street, Anytown, CA 12345",
                    Doctors[0]),
                new Clinic(
                    name: "Oak Ridge Medical Center",
                    location:"456 Oak Ridge Avenue, Oak Ridge, TN 67890",
                    Doctors[1]),
                new Clinic(
                    name: "Pine Valley Wellness Center",
                    location: "789 Pine Valley Road, Pine Valley, AZ 54321",
                    Doctors[2]),
            };
        }

        private static void InitDoctorsList() 
        {
            Doctors.Add(new List<Doctor>()
            {
                new Doctor(
                    name: "Alice",
                    surname: "Johnson",
                    type: DoctorType.Neurologist,
                    costOfPermissiom: 100),
                new Doctor(
                    name: "Bob",
                    surname: "Smith",
                    type:DoctorType.Gastroenterologist,
                    costOfPermissiom: 150),
                new Doctor(
                    name: "Charlie",
                    surname: "Brown",
                    type:DoctorType.Cardiology,
                    costOfPermissiom: 120),
                new Doctor(
                    name: "David",
                    surname: "Lee",
                    type:DoctorType.Anasthesiologist,
                    costOfPermissiom: 180)

            });

            Doctors.Add(new List<Doctor>()
            {
                new Doctor(
                    name: "Emily",
                    surname: "Davis",
                    type:DoctorType.Neurologist,
                    costOfPermissiom: 90),
                new Doctor(
                    name: "Frank",
                    surname: "Miller",
                    type:DoctorType.Anasthesiologist,
                    costOfPermissiom: 110),
                new Doctor(
                    name: "Grace",
                    surname: "Wilson",
                    type:DoctorType.Dermatologist,
                    costOfPermissiom: 160),
                new Doctor(
                    name: "Henry",
                    surname: "Moore",
                    type:DoctorType.Gastroenterologist,
                    costOfPermissiom: 130)
            });

            Doctors.Add(new List<Doctor>()
            {
                new Doctor(
                    name: "Isabella",
                    surname: "Taylor",
                    type:DoctorType.Cardiology,
                    costOfPermissiom: 140),
                new Doctor(
                    name: "Jack",
                    surname: "Anderson",
                    type:DoctorType.Oncologist,
                    costOfPermissiom: 170),
                new Doctor(
                    name: "Kate",
                    surname: "Thomas",
                    type:DoctorType.Anasthesiologist,
                    costOfPermissiom: 105),
                new Doctor(
                    name: "Mia",
                    surname: "Martin",
                    type:DoctorType.Dermatologist,
                    costOfPermissiom: 150)
            });
        }

        private static void InitPatientList()
        {
            Patients = new List<Patient>() 
            {
                new Patient(
                    name: "Ivan",
                    surname:"Petrov",
                    email:"petrov@gmail.com",
                    phoneNumber:"+380 99 123 4567"),
                new Patient(
                    name: "Olena",
                    surname:"Kovalenko",
                    email:"kovalenko@gmail.com",
                    phoneNumber:"+380 67 543 2109"),
                new Patient(
                    name: "Mykola",
                    surname:"Shevchenko",
                    email:"shevchenko@gmail.com",
                    phoneNumber:"+380 95 876 5432"),
                new Patient(
                    name: "Oksana",
                    surname:"Marchenko",
                    email:"oksana@gmail.com",
                    phoneNumber:"+380 63 123 4567"),
                new Patient(
                    name: "Andriy",
                    surname:"Melnyk",
                    email:"melnyk@gmail.com",
                    phoneNumber:"+380 97 543 2109"),
                new Patient(
                    name: "Natali",
                    surname:"Timoshenko",
                    email:"nata@gmail.com",
                    phoneNumber:"+380 99 876 5432"),
                new Patient(
                    name: "Dmytro",
                    surname:"Kondratyuk",
                    email:"kondratyuk@gmail.com",
                    phoneNumber:"+380 67 123 4567"),
                new Patient(
                    name: "Iryna",
                    surname:"Kravchenko",
                    email:"iryna654@gmail.com",
                    phoneNumber:"+380 95 543 2109"),
                new Patient(
                    name: "Viktor",
                    surname:"Yakovenko",
                    email:"yakovenko@gmail.com",
                    phoneNumber:"+380 99 876 5432"),
            };
        }

        /// Implement it
        //private static void InitListOfAppointmentsDifferentDoctors()
        //{
        //    foreach(var patient in Patients.Where())
        //    {

        //    }
        //}
    }
}
