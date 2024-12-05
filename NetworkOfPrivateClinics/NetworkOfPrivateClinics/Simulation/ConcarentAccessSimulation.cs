using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Simulation
{
    public class ConcarentAccessSimulation
    {
        private readonly DoctorService _doctorService;

        public ConcarentAccessSimulation(DoctorService doctorService) 
        {
            _doctorService = doctorService;
        }

        public async Task Run(int day, string hour, int doctor, Patient patient)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(1,5);
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
    }
}
