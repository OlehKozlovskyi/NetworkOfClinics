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
        private List<Clinic> _clinics = new();
        private string _pathToSource = @"C:\Users\OlehKozlovskyi\Documents\GitHub\NetworkOfClinics\NetworkOfPrivateClinics\source\clinics_source.json";

        public static void Main()
        {
            var program = new Program();
            program.CreateDataReadingMenu();
            program.CreateMainMenu();
        }

        public void CreateDataReadingMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> DATA READING MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Read data from default source file");
            Console.WriteLine("2) Read data from user`s source file");
            int optionNumber = Convert.ToInt32(Console.ReadLine());
            DataReadingMenuManageOptions(optionNumber);
            Console.Clear();
        }

        public void CreateMainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> Main MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Get all hospitals");
            Console.WriteLine("2) Get hospital by id");
            Console.WriteLine("3) Write data to file");
            Console.WriteLine("Select option");
            int optionsNumber = Convert.ToInt32(Console.ReadLine());
            MainMenuManageOptions(optionsNumber);
        }

        public void WriteDataToFile(IFileWriter fileWriter)
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

        private void DataReadingMenuManageOptions(int dataReadingOptionsNumber)
        {
            switch(dataReadingOptionsNumber)
            {
                case 1:
                    _clinics = new FileReaderRepository(_pathToSource).ReadFromSourceFile();
                    break;
                case 2:
                    _pathToSource = GetFullPathFromUser();
                    _clinics = new FileReaderRepository(_pathToSource).ReadFromSourceFile();
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;
            }
        }

        private string GetFullPathFromUser()
        {
            Console.Clear();
            Console.WriteLine("Enter full path to json source file: ");
            string path = Console.ReadLine();
            return path;
        }

        private void MainMenuManageOptions(int optionsNumber)
        {
            DataProvider dataProvider = new(_clinics);
            switch (optionsNumber)
            {
                case 1:
                    dataProvider.GetAllHospitalsWithDoctors();
                    break;
                case 2:
                    dataProvider.GetHospitalWithDoctorsById();
                    break;
                case 3:
                    {
                        Console.WriteLine("Enter the full path to the file for saving data:");
                        string path = Console.ReadLine();
                        var fileWriter = new FileWriterFactory().GetFileWriter(path);
                        WriteDataToFile(fileWriter);
                    }
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;

            }
        }
    }
}
