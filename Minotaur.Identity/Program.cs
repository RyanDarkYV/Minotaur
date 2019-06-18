﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Minotaur.CommonParts.Logging;

namespace Minotaur.Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseLogging();
    }
}
