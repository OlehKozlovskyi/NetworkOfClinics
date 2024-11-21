using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NetworkOfPrivateClinics.CustomExceptions;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class CsvFileWriter : BaseWriter
    {
        private string _path;

        public CsvFileWriter(string path)
        {
            FullPath = path;
        }

        public string FullPath
        {
            get => _path;
            private set
            {
                if (!Path.HasExtension(value))
                    throw new InvalidDirectoryException(value);
                _path = value;
            }
        }

        public override async void Write(List<Clinic> clinicsList)
        {
            using (var sw = new StreamWriter(FullPath))
            {
                using (var writer = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    writer.WriteRecords(clinicsList);
                }
            }
        }
    }
}
