using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Universidade.Data;

namespace Universidade
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* CreateHostBuilder(args).Build().Run();
             * Esta instru��o acima � inicialmente feita na cria��o do projeto .NET 5.
             * Por�m, vamos usar de outra maneira para iniciar nossa aplica��o e popular
             * nosso banco de dados.*/
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    IESContext context = services.GetRequiredService<IESContext>();
                    IESDbInitializer.Initialize(context);
                }
                catch (Exception e)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "Um erro ocorreu ao popular a base de dados.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
