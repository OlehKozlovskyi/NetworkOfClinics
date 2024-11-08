// See https://aka.ms/new-console-template for more information

using NetworkOfPrivateClinics;

var appointment = new AppointmentFactory("8:00", "17:00");
Console.WriteLine();
//WriteLineAvailableClinics();
//WriteLineClinicsSpecizalizations();
//WriteLineAllDoctorsOfEachClinic();
//WritLineSortedListOfDoctorByCostOfAdmission();


//void WriteLineAllDoctorsOfEachClinic()
//{
//    foreach (var clinic in GenerateData.Clinics)
//    {
//        Console.WriteLine($"******** Doctors in {clinic.Name} ********");
//        foreach (var doctor in clinic.Doctors)
//            Console.WriteLine($"{doctor.Name} {doctor.Surname} - {doctor.Type}");
//        Console.WriteLine();
//    }
        
//}

//void WriteLineAvailableClinics()
//{
//    Console.WriteLine("+++++ Available clinics +++++");
//    foreach (var item in GenerateData.Clinics.Select(x=>x.Name))
//        Console.WriteLine(item);
//    Console.WriteLine();
//}

//void WriteLineClinicsSpecizalizations()
//{
//    Console.WriteLine("+++++ Clinics Specializations +++++");
//    foreach (var tempClinic in GenerateData.Clinics)
//    {
//        Console.WriteLine($"+++++ {tempClinic.Name} +++++");
//        foreach (var specialization in tempClinic.Doctors.Select(x=>x.Type))
//            Console.WriteLine(specialization.ToString());
//    }
//    Console.WriteLine();
//}

//void WritLineSortedListOfDoctorByCostOfAdmission()
//{
//    Console.WriteLine("+++++ Sorted list of doctors +++++");
//    var sortedList = GenerateData.Clinics
//        .SelectMany(x => x.Doctors)
//        .OrderBy(x=>x.CostOfAdmission)
//        .Select(x => (x.Name, x.Surname, x.Type, x.CostOfAdmission))
//        .ToList();
//    foreach (var item in sortedList) 
//        Console.WriteLine($"{item.Name} {item.Surname} ({item.Type}) - {item.CostOfAdmission} $");
//}

