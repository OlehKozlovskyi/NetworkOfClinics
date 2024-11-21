using NetworkOfPrivateClinics.BisinessLogic;
using NetworkOfPrivateClinics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.WorkingWithFiles
{
    public class FileReader
    {
        public async Task<List<Clinic>> Read(string path, IFileReader reader) => await reader.Read(path);
    }
}
