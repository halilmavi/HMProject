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

        // IHostBuilder bizim server ile konfigürasyonun olduðu yerdir.
        // .NetCore da varsayýlan IoC  kullanmak yerine farklý bir IoC container'i (autofac) kullanmak istediðimizi Program sýnýfý içerisinde tanýmlýyoruz.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  // .NET Core' un varsayýlan yapýsýný kullanmak yerine kendi IOC'imizi yani Autofac yapýsýný kullanacaðýmýzý tanýmlýyoruz.
                .ConfigureContainer<ContainerBuilder>(builder =>                 // Burdada HMBusiness.DependencyResolvers.Autofac klasöründe tanýmlamýþ olduðumuz AutofacBusinessModule sýnýfý bildiriyoruz.
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
