using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class DataWriter
    {
        private IWriter _writer;
        private FilePath _filePath;
        private string _fileName;

        public DataWriter(IWriter writer, FilePath path, string fileName)//ADD format 
        {
            _writer = writer;
            _filePath = path;
            _fileName = fileName;
        }

        public void Write(ClinicRepository clinicRepository)
        {

        }
    }
}
