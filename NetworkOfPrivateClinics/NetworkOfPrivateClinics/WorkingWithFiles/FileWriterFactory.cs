using NetworkOfPrivateClinics.CustomExceptions;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileWriterFactory
    {
        public BaseWriter GetFileWriter(string path)
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
