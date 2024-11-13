using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void InitDoctorsList(List<AppointmentsFactory> appointments) 
        {
            var validator = new AppointmentsValidator("8:00")
            Doctors =
            [
                new List<Doctor>()
                {
                    new Doctor(
                        id: 1234,
                        name: "Alice",
                        surname: "Johnson",
                        type: DoctorType.Neurologist,
                        costOfPermissiom: 100m,
                        appointment: new AppointmentsFactory("8:00", "17:00")),
                    new Doctor(
                        id: 1345,
                        name: "Bob",
                        surname: "Smith",
                        type:DoctorType.Gastroenterologist,
                        costOfPermissiom: 150m,
                        appointment: appointments[1]),
                    new Doctor(
                        id: 1245,
                        name: "Charlie",
                        surname: "Brown",
                        type:DoctorType.Cardiology,
                        costOfPermissiom: 120m,
                        appointment: appointments[2]),
                    new Doctor(
                        id: 1235,
                        name: "David",
                        surname: "Lee",
                        type:DoctorType.Anasthesiologist,
                        costOfPermissiom: 180m,
                        appointment: appointments[3])

                },
                new List<Doctor>()
                {
                    new Doctor(
                        id: 2134,
                        name: "Emily",
                        surname: "Davis",
                        type:DoctorType.Neurologist,
                        costOfPermissiom: 90m,
                        appointment: appointments[4]),
                    new Doctor(
                        id: 2234,
                        name: "Frank",
                        surname: "Miller",
                        type:DoctorType.Anasthesiologist,
                        costOfPermissiom: 110m,
                        appointment: appointments[5]),
                    new Doctor(
                        id: 2334,
                        name: "Grace",
                        surname: "Wilson",
                        type:DoctorType.Dermatologist,
                        costOfPermissiom: 160m,
                        appointment: appointments[6]),
                    new Doctor(
                        id: 2445,
                        name: "Henry",
                        surname: "Moore",
                        type:DoctorType.Gastroenterologist,
                        costOfPermissiom: 130m,
                        appointment: appointments[7])
                },
                new List<Doctor>()
                {
                    new Doctor(
                        id:3123,
                        name: "Isabella",
                        surname: "Taylor",
                        type:DoctorType.Cardiology,
                        costOfPermissiom: 140m,
                        appointment: appointments[8]),
                    new Doctor(
                        id: 3223,
                        name: "Jack",
                        surname: "Anderson",
                        type:DoctorType.Oncologist,
                        costOfPermissiom: 170m,
                        appointment: appointments[9]),
                    new Doctor(
                        id: 3344,
                        name: "Kate",
                        surname: "Thomas",
                        type:DoctorType.Anasthesiologist,
                        costOfPermissiom: 105m,
                        appointment: appointments[10]),
                    new Doctor(
                        id: 3356,
                        name: "Mia",
                        surname: "Martin",
                        type:DoctorType.Dermatologist,
                        costOfPermissiom: 150m,
                        appointment: appointments[11])
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
