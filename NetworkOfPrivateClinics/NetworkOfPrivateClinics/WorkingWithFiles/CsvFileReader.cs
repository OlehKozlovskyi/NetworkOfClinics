using CsvHelper;
using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class CsvFileReader : IFileReader
    {
        //Can`t implement because object Clinic contain nested collections 
        public List<Clinic> Read(string path)
        {
            List<Clinic> items = new();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                throw new NotImplementedException();
            }
        }
    }
}
