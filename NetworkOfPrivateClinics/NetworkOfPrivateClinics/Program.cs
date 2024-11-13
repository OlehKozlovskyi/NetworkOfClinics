// See https://aka.ms/new-console-template for more information

using NetworkOfPrivateClinics;

var appointment = new AppointmentFactory("8:00", "17:00");
var appointments = new List<AppointmentsFactory>()
{
    new AppointmentFactory("8:00", "10:00"),
    new AppointmentFactory("9:00", "18:00"),
    new AppointmentFactory("9:00", "19:00"),
    new AppointmentFactory("7:00", "12:00"),
    new AppointmentFactory("12:00", "18:00"),
    new AppointmentFactory("13:00", "18:00"),
    new AppointmentFactory("9:00", "20:00"),
    new AppointmentFactory("18:00", "23:00"),
    new AppointmentFactory("19:00", "23:00"),
    new AppointmentFactory("17:00", "22:00"),
    new AppointmentFactory("20:00", "22:00"),
    new AppointmentFactory("7:00", "12:00"),
};


Data generatedData = new Data();
ClinicRepository repository = new ClinicRepository(generatedData.Clinics);
GetAllHospitalsWithDoctors();
GetHospitalWithDoctorsById(14311554);

void GetAllHospitalsWithDoctors()
{
    foreach (Clinic currentClinic in repository.GetClinics())
    {
        Console.WriteLine($"Name: {currentClinic.Name}");
        Console.WriteLine($"Location: {currentClinic.Location}");
        foreach (Doctor currentDoctor in currentClinic.Doctors)
            Console.WriteLine($"Doctor: {currentDoctor.Name} {currentDoctor.Surname} - {currentDoctor.Type}");
        Console.WriteLine();
    }
}

void GetHospitalWithDoctorsById(int id)
{
    Clinic currentClinic = repository.GetClinicById(id);
    Console.WriteLine($"Name: {currentClinic.Name}");
    Console.WriteLine($"Location: {currentClinic.Location}");
    foreach(Doctor currentDoctor in currentClinic.Doctors)
        Console.WriteLine($"Doctor: {currentDoctor.Name} {currentDoctor.Surname} - {currentDoctor.Type}");
}