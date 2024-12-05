// See https://aka.ms/new-console-template for more information
using CsvHelper;
using Microsoft.Extensions.Logging;
using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.BusinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.Services;
using NetworkOfPrivateClinics.Simulation;
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
        private static string _fileSourceName = "clinics_source.json";
        private static string _pathToSource = Path.GetFullPath(_fileSourceName);

        public static async Task Main(string[] args)
        {
            var program = new Program();
            await program.CreateDataReadingMenu();
            await program.CreateMainMenu();
        }

        public async Task CreateDataReadingMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> DATA READING MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Read data from default source file");
            Console.WriteLine("2) Read data from user`s source file");
            int optionNumber = Convert.ToInt32(Console.ReadLine());
            await DataReadingMenuManageOptions(optionNumber);
            Console.Clear();
        }

        public async Task CreateMainMenu()
        {
            Console.WriteLine(">>>>>>>>>>>> Main MENU <<<<<<<<<<<<");
            Console.WriteLine("1) Get all hospitals");
            Console.WriteLine("2) Get hospital by id");
            Console.WriteLine("3) Write data to file");
            Console.WriteLine("4) Run concurrent access simulation");
            Console.WriteLine("Select option");
            int optionsNumber = Convert.ToInt32(Console.ReadLine());
            await MainMenuManageOptions(optionsNumber);
        }

        public async Task WriteDataToFile(IFileWriter fileWriter)
        {
            try
            {
                await fileWriter.Write(_clinics);
                Console.WriteLine("Data was successfully written to the file");
            }
            catch
            {
                Console.WriteLine("File was not created, unknown error");
            }  
        }

        private async Task DataReadingMenuManageOptions(int dataReadingOptionsNumber)
        {
            var fileReader = new FileReaderRepository(_pathToSource);
            switch(dataReadingOptionsNumber)
            {
                case 1:
                    _clinics = await fileReader.ReadFromSourceFile();
                    break;
                case 2:
                    fileReader.ChangeSourcePath(GetFullPathFromUser());
                    _clinics = await fileReader.ReadFromSourceFile();
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

        private async Task MainMenuManageOptions(int optionsNumber)
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
                        await WriteDataToFile(fileWriter);
                    }
                    break;
                case 4:
                    await RunSimulation();
                    break;
                default:
                    Console.WriteLine("Can`t find option with such number");
                    break;
            }
        }

        private async Task RunSimulation()
        {
            ProjectLogger<Program> logger = new();
            DoctorService doctorService = new(new DoctorRepository(logger));
            ConcarentAccessSimulation simulation = new(doctorService);
            List<Task> tasks = new();
            (Doctor, Patient) data = await GetIncomingDataForSimulation();
            await doctorService.RegisterDoctorAsync(data.Item1);
            tasks.Add(Task.Run(() => simulation.Run(6, "10:00", 1234, data.Item2)));
            tasks.Add(Task.Run(() => simulation.Run(6, "10:00", 1234, data.Item2)));
            tasks.Add(Task.Run(() => simulation.Run(6, "10:00", 1234, data.Item2)));
            tasks.Add(Task.Run(() => simulation.Run(6, "10:00", 1234, data.Item2)));
            tasks.Add(Task.Run(() => simulation.Run(6, "10:00", 1234, data.Item2)));
            await Task.WhenAll(tasks);
        }

        private async Task<(Doctor, Patient)> GetIncomingDataForSimulation()
        {
            Doctor doctor = new DoctorsFactory(1234, "Alice", "Johnson", DoctorType.Neurologist, 100m,
                        new AppointmentsFactory("8:00", "17:00")).GetDoctor();
            Patient patient = new(100, "Oleh", "Kozlovjiy", "Oleg@ukr.net", "+380 68 857 7128");
            return await Task.FromResult((doctor, patient));
        }
    }
}
