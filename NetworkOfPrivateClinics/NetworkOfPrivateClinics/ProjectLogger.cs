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
        private static ILogger<T> _logger;

        public ProjectLogger()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Information);
            });
            _logger = loggerFactory.CreateLogger<T>();
        }

        public async Task LogInformation(string message)
        {
            await Task.Run(()=>_logger.LogInformation(message));
        }

        public async Task LogWarning(string message)
        {
            await Task.Run(() => _logger.LogWarning(message));
        }

        public async Task LogError(string message)
        {
            await Task.Run(() => _logger.LogError(message));
        }
    }
}
