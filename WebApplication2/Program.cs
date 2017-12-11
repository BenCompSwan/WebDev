using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using WebApplication2.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    var uM = services.GetRequiredService <UserManager<ApplicationUser>>();
                    //var rM = services.GetRequiredService<RoleManager<IdentityRole>>();

                   // var dbInitLogger = services.GetRequiredService <ILogger<DbInitializer>>();
                    DbInitializer.Initialize(dbContext, uM/*, rM, dbInitLogger*/).Wait();
                }
                catch(Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "There was an error while seeding the database");
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
