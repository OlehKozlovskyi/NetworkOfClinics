using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Interfaces
{
    public interface ICustomLogger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
