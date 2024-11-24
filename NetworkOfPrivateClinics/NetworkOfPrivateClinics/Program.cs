// See https://aka.ms/new-console-template for more information

using CsvHelper;
using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.WorkingWithFiles;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace NetworkOfPrivateClinics
{
    public class Program
    {
        private static Data _generatedInformation = new Data();
        private static List<Clinic> _clinics = new();
        private static string _pathToSource = @"C:\Users\OlehKozlovskyi\Documents\GitHub\NetworkOfClinics\NetworkOfPrivateClinics\source\clinics_source.json";
        private static string _pathToWrite = @"C:\Users\OlehKozlovskyi\Documents\GitHub\NetworkOfClinics\NetworkOfPrivateClinics\source\clinicsDataInCSV.csv";//Path.GetFullPath("clinics_source.json");

        public static void Main()
        {
            //CreateDataReadingMenu();
            CsvFileWriter writer = new CsvFileWriter(_pathToWrite);
            writer.Write(_generatedInformation.Clinics);
            //CreateMainMenu();
        }

        public static void CreateDataReadingMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> DATA READING MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Read data from default source file");
            Console.WriteLine("2) Read data from user`s source file");
            int optionNumber = Convert.ToInt32(Console.ReadLine());
            DataReadingMenuManageOptions(optionNumber);
            Console.Clear();
        }

        public static void CreateMainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> Main MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Get all hospitals");
            Console.WriteLine("2) Get hospital by id");
            Console.WriteLine("3) Write data to file");
            Console.WriteLine("Select option");
            int optionsNumber = Convert.ToInt32(Console.ReadLine());
            MainMenuManageOptions(optionsNumber);
        }

        private static void GetInformationFromUser()
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
        }

        public static void WriteDataToFile(IFileWriter fileWriter)
        {
            try
            {
                fileWriter.Write(_clinics);
                Console.WriteLine("Data was successfully written to the file");
            }
            catch
            {
                Console.WriteLine("File was not created, unknown error");
            }
            
        }

        public static void GetAllHospitalsWithDoctors()
        {
            foreach (Clinic currentClinic in _clinics)
            {
                Console.WriteLine($"Name: {currentClinic.ClinicsName}");
                Console.WriteLine($"Location: {currentClinic.Location}");
                foreach (Doctor currentDoctor in currentClinic.Doctors)
                    Console.WriteLine($"Doctor: {currentDoctor.DoctorsName} {currentDoctor.DoctorsSurname} - {currentDoctor.Type}");
                Console.WriteLine();
            }
        }

        public static void GetHospitalWithDoctorsById()
        {
            Console.WriteLine("Enter clinics ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Clinic currentClinic = _clinics.Where(x => x.ClinicID == id).Single();
            Console.WriteLine($"Name: {currentClinic.ClinicsName}");
            Console.WriteLine($"Location: {currentClinic.Location}");
            foreach (Doctor currentDoctor in currentClinic.Doctors)
                Console.WriteLine($"Doctor: {currentDoctor.DoctorsName} {currentDoctor.DoctorsSurname} - {currentDoctor.Type}");
        }

        private static void DataReadingMenuManageOptions(int dataReadingOptionsNumber)
        {
            switch(dataReadingOptionsNumber)
            {
                case 1:
                    InitDataContext(new FileReaderRepository(_pathToSource));
                    break;
                case 2:
                    _pathToSource = GetFullPathFromUser();
                    InitDataContext(new FileReaderRepository(_pathToSource));
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;
            }
        }

        private static string GetFullPathFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter full path to json source file: ");
            string path = Console.ReadLine();
            return path;
        }

        private static void InitDataContext(FileReaderRepository fileReader) => _clinics = fileReader.ReadFromSourceFile();

        private static void MainMenuManageOptions(int optionsNumber)
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
                        //var usersValues = GetInformationFromUser();
                        //WriteDataToFile(usersValues);
                    }
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;

            }
        }
    }
}
