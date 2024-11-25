using NetworkOfPrivateClinics.BisinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface IFileReader
    {
        public List<Clinic> Read(string path);
    }
}
