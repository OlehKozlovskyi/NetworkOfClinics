using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Simulation
{
    public class ConcurrentAccessSimulation
    {
        private readonly DoctorService _doctorService;

        public ConcurrentAccessSimulation(DoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        public async Task RunMockConcurrentMakeAppointment()
        {
            List<Task> tasks = new();
            int nextDayDate = DateTime.Now.AddDays(1).Day;
            var (incomingDoctor, incomingPatient) = GetIncomingData();
            _doctorService.RegisterDoctor(incomingDoctor);
            tasks.Add(Task.Run(() => HandleCocurrentAppointmentBooking(nextDayDate, "10:00", 1234, incomingPatient)));
            tasks.Add(Task.Run(() => HandleCocurrentAppointmentBooking(nextDayDate, "10:00", 1234, incomingPatient)));
            tasks.Add(Task.Run(() => HandleCocurrentAppointmentBooking(nextDayDate, "10:00", 1234, incomingPatient)));
            tasks.Add(Task.Run(() => HandleCocurrentAppointmentBooking(nextDayDate, "10:00", 1234, incomingPatient)));
            tasks.Add(Task.Run(() => HandleCocurrentAppointmentBooking(nextDayDate, "10:00", 1234, incomingPatient)));
            await Task.WhenAll(tasks);
        }

        private async Task HandleCocurrentAppointmentBooking(int day, string hour, int doctor, Patient patient)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(1, 5);
            await semaphore.WaitAsync();
            try
            {
                await _doctorService.MakeAppointmentAsync(day, hour, doctor, patient);
            }
            finally
            {
                semaphore.Release();
            }
        }

        private (Doctor doctor, Patient patient) GetIncomingData()
        {
            Doctor doctor = new DoctorsFactory(1234, "Alice", "Johnson", DoctorType.Neurologist, 100m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor();
            Patient patient = new(100, "Oleh", "Kozlovjiy", "Oleg@ukr.net", "+380 68 857 7128");
            return (doctor, patient);
        }
    }
}
