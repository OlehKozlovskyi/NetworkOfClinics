﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkOfPrivateClinics.BisinessLogic;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> GetClinicsAsync();
        Task<Clinic> GetClinicByIdAsync(int id);
        Task AddClinicAsync(Clinic clinic);
        Task DeleteClinicAsync(int id);
    }
}
