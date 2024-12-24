using Microsoft.Extensions.Logging;

namespace TestClassConsole
{
    internal class MyService
    {
        private readonly ILogger<MyService> _logger;

        public MyService(ILogger<MyService> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("MyService is running.");

            // Perform your service logic here
            _logger.LogDebug("Debug message.");
            _logger.LogInformation("Information message.");
            _logger.LogWarning("Warning message.");
            _logger.LogError("Error message.");
        }
    }
}
