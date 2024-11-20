// See https://aka.ms/new-console-template for more information

using CsvHelper;
using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.WorkingWithFiles;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace NetworkOfPrivateClinics
{
    public class Program
    {
        private static Data _generatedInformation;
        private static ClinicRepository _clinicRepository;
        private static List<Clinic> _clinics;
        private readonly string _pathToDataSourceFile;
        private readonly string _nameOfDataSourceFile = "clinics_source.json";

        public Program() 
        {
            _generatedInformation = new Data();
            _clinicRepository = new ClinicRepository(_generatedInformation.Clinics);
            _clinics = new();
            _pathToDataSourceFile = Path.GetFullPath(_nameOfDataSourceFile);
        }

        public static void Main()
        {
            CreateStartupMenu();
            Console.Clear();
            CreateMenu();
        }

        public static void CreateStartupMenu()
        {
            Console.WriteLine("<<<<<<<<<<<<<<<<< STARTUP MENU >>>>>>>>>>>>>>>");
            Console.WriteLine("2) Enter directory to source file: ");
            string path = Console.ReadLine();
            _clinics = new FileReader().Read(path);
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
                writer.Write(_clinics, fileWriter);
                Console.WriteLine("Data was successfully written to the file");
            }
            catch(Exception ex)
            {
                Console.WriteLine("File was not created, unknown error");
            }
            
        }

        public static void GetAllHospitalsWithDoctors()
        {
            foreach (Clinic currentClinic in _clinics)
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
            Clinic currentClinic = _clinics.Where(x=>x.ClinicID==id).Single();
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
