using CsvHelper;
using NetworkOfPrivateClinics.CustomExceptions;
using NetworkOfPrivateClinics.Interfaces;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileWriterFactory
    {
        public IFileWriter GetFileWriter(string path)
        {
            var fileExtension = Path.GetExtension(path);
            switch (fileExtension)
            {
                case ".csv":
                    return new CsvFileWriter(path);
                case ".json":
                    return new JsonFileWriter(path);
                default:
                    throw new InvalidFileExtension(Path.GetFileName(path));
            }
        }
    }
}
