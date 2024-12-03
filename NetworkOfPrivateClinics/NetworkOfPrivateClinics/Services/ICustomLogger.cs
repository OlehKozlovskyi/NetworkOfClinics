using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics.Services
{
    public interface ICustomLogger
    {
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message);
    }
}
