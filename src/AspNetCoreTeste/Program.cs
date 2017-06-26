using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

namespace AspNetCoreTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            Console.WriteLine("Bem vindo ao Sistema de Alocacao");
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var host = new WebHostBuilder()
                .UseUrls("https://*:5001")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
