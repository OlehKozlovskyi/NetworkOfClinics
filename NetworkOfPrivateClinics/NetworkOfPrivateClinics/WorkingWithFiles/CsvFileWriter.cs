using NetworkOfPrivateClinics.BisinessLogic;
using CsvHelper;
using System.Globalization;
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
            using var sw = new StreamWriter(FullPath);
            using var writer = new CsvWriter(sw, CultureInfo.InvariantCulture);
            writer.WriteHeader<ExpandedClinic>();
            writer.NextRecord();
            foreach(var clinic in ClinicsConverter(clinicsList))
            {
                writer.WriteRecord(clinic);
                writer.NextRecord();
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
                                PatientID = appointmentDetail.Value?.PatientID ?? 0,
                                PatientName = appointmentDetail.Value?.PatientName ?? "null",
                                PatientSurname = appointmentDetail.Value?.PatientSurname ?? "null",
                                PatientEmail = appointmentDetail.Value?.Email ?? "null",
                                PatientContactNumber = appointmentDetail.Value?.Email ?? "null"
                            }))));
        }
    }
}
