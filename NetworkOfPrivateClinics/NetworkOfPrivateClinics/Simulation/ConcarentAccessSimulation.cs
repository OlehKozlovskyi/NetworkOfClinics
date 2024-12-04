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
        private readonly ICustomLogger _logger;

        public ConcarentAccessSimulation(DoctorService doctorService, ICustomLogger logger) 
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        public async Task Run(int day, string hour, int doctor, Patient patient)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(5);
            await semaphore.WaitAsync();
            try
            {
                await _doctorService.MakeAppointment(day, hour, doctor, patient);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
