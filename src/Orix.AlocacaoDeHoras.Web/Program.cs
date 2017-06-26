using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Orix.AlocacaoDeHoras.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao Sistema de Alocacao");

            var host = new WebHostBuilder()
                .UseUrls("https://*:5005")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
