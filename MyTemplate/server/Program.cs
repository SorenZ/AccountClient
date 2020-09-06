using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace MyTemplate.server
{
   public class Program
   {
      public static void Main(string[] args)
      {
         BuildWebHost(args).Run();
      }

      public static IWebHost BuildWebHost(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostContext, config) =>
             {
                var env = hostContext.HostingEnvironment;
                var ds = Path.DirectorySeparatorChar;
                config.AddJsonFile(env.ContentRootPath+ds+"appsettings.json",  false, true)
                      .AddJsonFile(env.ContentRootPath+ds+"appsettings.Xero.json", false,  true);
             })

              .UseStartup<Startup>()
              .Build();
   }
}
