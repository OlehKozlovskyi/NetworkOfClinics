// See https://aka.ms/new-console-template for more information

using NetworkOfPrivateClinics.BisinessLogic;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NetworkOfPrivateClinics
{
    public static class Program
    {
        private static readonly Data generatedInformation;
        private static readonly ClinicRepository clinicRepository;

        static Program() 
        {
            generatedInformation = new Data();
            clinicRepository = new ClinicRepository(generatedInformation.Clinics);
        }

        public static void Main()
        {
            string path = """C:\Users\OlehKozlovskyi\Documents\GitHub\NetworkOfClinics\NetworkOfPrivateClinics\source""";
            var paths = new FilePaths(path, new FilePathsValidator(), SupportedFileFormats.json);
            var tem = new CustomJsonWriter(path, "MyFirstJson");
            var t = JsonConvert.SerializeObject(clinicRepository);
            tem.Write(clinicRepository);
            //CreateMenu();
        }

        public static void CreateMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> MENU <<<<<<<<<<<<".PadLeft(30));
            Console.WriteLine("1) Get all hospitals".PadLeft(20));
            Console.WriteLine("2) Get hospital by id".PadLeft(20));
            Console.WriteLine("Select option");
            int optionsNumber = Convert.ToInt32(Console.ReadLine());
            ManageOptions(optionsNumber);
        }

        public static void GetAllHospitalsWithDoctors()
        {
            foreach (Clinic currentClinic in clinicRepository.GetClinics())
            {
                Console.WriteLine($"Name: {currentClinic.Name}");
                Console.WriteLine($"Location: {currentClinic.Location}");
                foreach (Doctor currentDoctor in currentClinic.Doctors)
                    Console.WriteLine($"Doctor: {currentDoctor.Name} {currentDoctor.Surname} - {currentDoctor.Type}");
                Console.WriteLine();
            }
        }

        public static void GetHospitalWithDoctorsById()
        {
            Console.WriteLine("Enter clinics ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Clinic currentClinic = clinicRepository.GetClinicById(id);
            Console.WriteLine($"Name: {currentClinic.Name}");
            Console.WriteLine($"Location: {currentClinic.Location}");
            foreach (Doctor currentDoctor in currentClinic.Doctors)
                Console.WriteLine($"Doctor: {currentDoctor.Name} {currentDoctor.Surname} - {currentDoctor.Type}");
        }

        private static void ManageOptions(int optionsNumber)
        {
            switch (optionsNumber)
            {
                case 1:
                    GetAllHospitalsWithDoctors();
                    break;
                case 2:
                    GetHospitalWithDoctorsById();
                        break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;

            }
        }
    }
}
