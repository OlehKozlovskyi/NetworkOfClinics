using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public record ExpandedClinic
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public string ClinicLocation { get; set; }
        public int DoctorID { get; set; }
        public string DoctorsName { get; set; }
        public string DoctorsSurname { get; set; }
        public string DoctorsType { get; set; }
        public decimal DoctorsCostOfAdmission { get; set; }
        public int AppointmentsDay { get; set; }
        public TimeOnly AppointmentsTime { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientEmail { get; set; }
        public string PatientContactNumber { get; set; }
    }
}
