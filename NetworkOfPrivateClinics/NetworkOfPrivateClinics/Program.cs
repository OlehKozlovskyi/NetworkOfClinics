// See https://aka.ms/new-console-template for more information

using CsvHelper;
using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.WorkingWithFiles;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
            CreateMenu();
        }

        public static void CreateStartupMenu()
        {
            Console.WriteLine("<<<<<<<<<<<<<<<<< STARTUP MENU >>>>>>>>>>>>>>>");
            Console.WriteLine("2) Enter directory to source file: ");
        }

        public static void CreateMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Get all hospitals");
            Console.WriteLine("2) Get hospital by id");
            Console.WriteLine("3) Write data to file");
            Console.WriteLine("Select option");
            int optionsNumber = Convert.ToInt32(Console.ReadLine());
            ManageOptions(optionsNumber);
        }

        public static IFileWriter GetInformationFromUser()
        {
            Console.Clear();
            Console.WriteLine("Set directory for saving file: ");
            string path = Console.ReadLine();
            Console.WriteLine("Set file name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Choose one of the available formats: ");
            Console.WriteLine("1) CSV ");
            Console.WriteLine("2) JSON");
            int choice = int.Parse(Console.ReadLine());
            return TransformUserData(path, name, choice);
        }

        public static void WriteDataToFile(IFileWriter fileWriter)
        {
            DataWriter writer = new();
            try
            {
                writer.Write(clinicRepository, fileWriter);
                Console.WriteLine("Data was success written in file");
            }
            catch(Exception ex)
            {
                Console.WriteLine("File didn`t be created, uknown error");
            }
            
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
                case 3:
                    {
                        var usersValues = GetInformationFromUser();
                        WriteDataToFile(usersValues);
                    }
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;

            }
        }

        private static IFileWriter TransformUserData(string path, string name, int choice)
        {
            IExtension extension = choice == 1 ? new CsvFormat() : new JsonFormat();
            var PathCreator = new FullPathCreator(path, name, extension);
            IFileWriter writer = choice == 1 ? new CsvFileWriter(PathCreator) : new JsonFileWriter(PathCreator);
            return writer;
        }
    }
}
