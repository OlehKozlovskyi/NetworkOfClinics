// See https://aka.ms/new-console-template for more information

using NetworkOfPrivateClinics;

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