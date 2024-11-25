using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReader
    {
        public List<Clinic> Read(string path, IFileReader reader) => reader.Read(path);
    }
}
