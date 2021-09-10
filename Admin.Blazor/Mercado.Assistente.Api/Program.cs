using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Sa2s.Dicionario
//using ByteOn.Valor.PortalCliente.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Sa2s.DicionarioDados.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //using (var scope = host.Services.CreateScope())
            //{

            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<>();

            //    //4. Call the DataGenerator to create sample data
            //    DataGenerator.Initialize(services);
            //}

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var host = CreateHostBuilder(args).Build();

            host.Run();

            //CreateWebHostBuilder(args)
            //    //.UseUrls("http://localhost:7910") ///"http://189.1.170.38:5000"
            //    .Build()
            //    .Run();           
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        /// <summary>
        /// servidor API legado
        /// </summary>
        public static string BOSRVCONEXAO = string.Empty;      

    }
}
