using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                    throw new UnsupportedFileException(Path.GetFileName(path));
            }
        }
    }
}
