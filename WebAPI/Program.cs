using Autofac;
using Autofac.Extensions.DependencyInjection;
using HMBusiness.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // IHostBuilder bizim server ile konfig�rasyonun oldu�u yerdir.
        // .NetCore da varsay�lan IoC  kullanmak yerine farkl� bir IoC container'i (autofac) kullanmak istedi�imizi Program s�n�f� i�erisinde tan�ml�yoruz.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  // .NET Core' un varsay�lan yap�s�n� kullanmak yerine kendi IOC'imizi yani Autofac yap�s�n� kullanaca��m�z� tan�ml�yoruz.
                .ConfigureContainer<ContainerBuilder>(builder =>                 // Burdada HMBusiness.DependencyResolvers.Autofac klas�r�nde tan�mlam�� oldu�umuz AutofacBusinessModule s�n�f� bildiriyoruz.
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
