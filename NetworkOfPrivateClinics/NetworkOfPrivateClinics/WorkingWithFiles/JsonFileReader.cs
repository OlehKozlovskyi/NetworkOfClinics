using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.BisinessLogic;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class JsonFileReader : IFileReader
    {
        public List<Clinic> Read(string path)
        {
            List<Clinic> items = new();
            try
            {
                using StreamReader stream = File.OpenText(path);
                JsonSerializer serializer = new JsonSerializer();
                items = (List<Clinic>)serializer.Deserialize(stream, typeof(List<Clinic>));
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
