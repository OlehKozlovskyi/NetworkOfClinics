using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.BusinessLogic;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileReader : IFileReader
    {
        public async Task<List<Clinic>> Read(string path)
        {
            List<Clinic> items = new();
            try
            {
                using StreamReader stream = new StreamReader(path);
                string jsonData = await stream.ReadToEndAsync();
                items = JsonConvert.DeserializeObject<List<Clinic>>(jsonData);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine("The file does not exist at the specified path.");
                Console.WriteLine(exception.Message);
            }
            return items;
        }
    }
}
