using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                // we only need to pass a .pfx or certificate when we want to use kestrel but in our case we don't need it so we comment 
                // this for now
                /*webBuilder.UseKestrel(opts =>
                {
                    opts.ListenLocalhost(5001, listenOptions =>
                    {
                        listenOptions.UseHttps("wildcard.pfx", "pass123");
                    });
                });*/
            });
    }
}
