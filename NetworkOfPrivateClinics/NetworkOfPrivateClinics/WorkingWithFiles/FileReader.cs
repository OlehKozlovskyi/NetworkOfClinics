using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReader
    {
        public async Task<List<Clinic>> Read(string path, IFileReader reader) => await reader.Read(path);
    }
}
