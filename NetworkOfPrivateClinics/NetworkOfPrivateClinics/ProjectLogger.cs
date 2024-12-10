using Microsoft.Extensions.Logging;
using NetworkOfPrivateClinics.Interfaces;
using NetworkOfPrivateClinics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class ProjectLogger<T> : ICustomLogger
    {
        private readonly ILogger<T> _logger;

        public ProjectLogger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message) => _logger.LogInformation(message);

        public void LogWarning(string message) => _logger.LogWarning(message);

        public void LogError(string message) => _logger.LogError(message); 
    }
}
