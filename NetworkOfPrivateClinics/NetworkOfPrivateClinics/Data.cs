using Microsoft.Extensions.Logging;
using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.Services;
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
        private DoctorService[] _doctorServices;

        public Data()
        {
            _doctorServices = new DoctorService[3];
            clinicServices = new ClinicService[3];
        }

        public ClinicService[] clinicServices { get; set; }

        public void Initializate()
        {
            InitDoctorServices();
            InitClinicServices();
        }


        #region Hardcoding data for lists
        private void InitClinicServices()
        {
            for (int i = 0; i < 3; i++)
                clinicServices[i] = new ClinicService(new ClinicRepository());
            clinicServices[0].AddClinic(
                new Clinic(
                    id: 14311554,
                    name: "Central Family Clinic",
                    location: "123 Main Street, Anytown, CA 12345",
                    doctors: _doctorServices[0].GetAllDoctors()));
            clinicServices[0].AddClinic(
                new Clinic(
                    id: 23312554,
                    name: "Oak Ridge Medical Center",
                    location: "456 Oak Ridge Avenue, Oak Ridge, TN 67890",
                    doctors: _doctorServices[1].GetAllDoctors()));
            clinicServices[0].AddClinic(
                new Clinic(
                    id: 11234567,
                    name: "Pine Valley Wellness Center",
                    location: "789 Pine Valley Road, Pine Valley, AZ 54321",
                    doctors: _doctorServices[2].GetAllDoctors()));
        }

        private void InitDoctorServices() 
        {
            ProjectLogger<Doctor> logger = new();
            for(int i = 0; i < 3; i++)
                _doctorServices[i] = new DoctorService(new DoctorRepository(logger));

            _doctorServices[0].RegisterDoctor(
                new DoctorsFactory(1234, "Alice", "Johnson", DoctorType.Neurologist, 100m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor());
            _doctorServices[0].RegisterDoctor(
                new DoctorsFactory(1345, "Bob", "Smith", DoctorType.Gastroenterologist, 150m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor());
            _doctorServices[0].RegisterDoctor(
                new DoctorsFactory(1245, "Charlie", "Brown", DoctorType.Cardiology, 120m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor());
            _doctorServices[0].RegisterDoctor(
                new DoctorsFactory(1235, "David", "Lee", DoctorType.Anasthesiologist, 180m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor());

            _doctorServices[1].RegisterDoctor(
                new DoctorsFactory(2134, "Emily", "Davis", DoctorType.Neurologist, 90m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor());
            _doctorServices[1].RegisterDoctor(
                new DoctorsFactory(2234, "Frank", "Miller", DoctorType.Anasthesiologist, 110m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor());
            _doctorServices[1].RegisterDoctor(
                new DoctorsFactory(2334, "Grace", "Wilson", DoctorType.Dermatologist, 160m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor());
            _doctorServices[1].RegisterDoctor(
                new DoctorsFactory(2445, "Henry", "Moore", DoctorType.Gastroenterologist, 130m,
                        new AppointmentsFactory("9:00", "18:00")).GetDoctor());

            _doctorServices[2].RegisterDoctor(
                new DoctorsFactory(3123, "Isabella", "Taylor", DoctorType.Cardiology, 140m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor());
            _doctorServices[2].RegisterDoctor(
                new DoctorsFactory(3223, "Jack", "Anderson", DoctorType.Oncologist, 170m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor());
            _doctorServices[2].RegisterDoctor(
                new DoctorsFactory(3344, "Kate", "Thomas", DoctorType.Anasthesiologist, 105m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor());
            _doctorServices[2].RegisterDoctor(
                new DoctorsFactory(3356, "Mia", "Martin", DoctorType.Dermatologist, 150m,
                        new AppointmentsFactory("12:00", "20:00")).GetDoctor());
        }
        #endregion

    }
}
