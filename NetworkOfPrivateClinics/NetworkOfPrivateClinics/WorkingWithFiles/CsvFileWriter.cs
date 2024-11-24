using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NetworkOfPrivateClinics.CustomExceptions;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class CsvFileWriter : BaseWriter
    {
        private string _path;

        public CsvFileWriter(string path)
        {
            FullPath = path;
        }

        public string FullPath
        {
            get => _path;
            private set
            {
                if (!Path.HasExtension(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        }

        public override void Write(List<Clinic> clinicsList)
        {
            using (var sw = new StreamWriter(FullPath))
            {
                using (var writer = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    writer.WriteHeader<ExpandedClinic>();
                    writer.NextRecord();
                    foreach(var clinic in ClinicsConverter(clinicsList))
                    {
                        writer.WriteRecord(clinic);
                        writer.NextRecord();
                    }
                }
            }
        }
        
        private IEnumerable<ExpandedClinic> ClinicsConverter(List<Clinic> clinicsList)
        {
            return clinicsList.SelectMany(clinic =>
                clinic.Doctors.SelectMany(doctor =>
                    doctor.Appointments.SelectMany(monthAppointment =>
                        monthAppointment.Value.ListOfDailyAppointments.Select(appointmentDetail =>
                            new ExpandedClinic()
                            {
                                ClinicID = clinic.ClinicID,
                                ClinicName = clinic.ClinicsName,
                                ClinicLocation = clinic.Location,
                                DoctorID = doctor.DoctorID,
                                DoctorsName = doctor.DoctorsName,
                                DoctorsSurname = doctor.DoctorsSurname,
                                DoctorsType = doctor.Type.ToString(),
                                DoctorsCostOfAdmission = doctor.CostOfAdmission,
                                AppointmentsDay = monthAppointment.Key,
                                AppointmentsTime = appointmentDetail.Key,
                                PatientID = 0,
                                PatientName = "null",
                                PatientSurname = "null",
                                PatientEmail = "null",
                                PatientContactNumber = "null"
                            }))));
        }
    }
}
