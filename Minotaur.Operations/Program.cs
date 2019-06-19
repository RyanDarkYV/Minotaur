using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Minotaur.CommonParts.Logging;
using Minotaur.CommonParts.Metrics;
using Minotaur.CommonParts.Mvc;
using Minotaur.CommonParts.Vault;

namespace Minotaur.Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLogging()
                .UseLockbox()
                .UseVault()
                .UseAppMetrics();
    }
}
