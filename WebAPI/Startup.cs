using HMBusiness.Abstract;
using HMBusiness.Concrete;
using HMDataAccess.Abstract;
using HMDataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*
                 COK ONEMLI BILGILER !!!!!!!!!
                 IoC gibi altyapý sunan farkli yapilar soz konusudur Bunlar; Autofac, Ninject, CastleWindsor,StructMap gibi teknolojilerdir. Bunlar icerisinde en sýk kullanilani AUTOFAC'tir.
                 IoC yerine Autofac vs. lerin kullanilmasinin sebebi AOP(cephe yonelimli programlama) ye izin vermeleridir.
                 IoC 'dan daha perfomansli calistigi icin projemize AUTOFAC'i enject'e edecegiz.
                 AOP'yi uygulama icerisinde tanimlamis oldugumuz metotlarin calisip calismamasýný hata kontrellerini vs LOG'lama  islemlerini AOP ile yapiyoruz.

                 AddSingleton : Projemiz ilk çalýþtýrdýðýmýz sýrada, servisin tek bir instance’ýný oluþturularak memoryde bu bilgiyi tutar ve gelen requestlerde üretilen ayný intancesý kullanýr.
                 Redis, Elastic gibi yapýlarý burada tutabiliriz.
                 Uygulama içerisinde baðýmlýlýk oluþturduðumuz ve kullandýðýmýz nesnenin tek bir sefer oluþturulmasýný ve ayný nesnenin uygulama içinde kullanýlmasýný saðlar.           
                 Singleton'ý icerisinde data tutmadigimiz zamanlarda kullaniriz.
                 AddSingleton<IProductService,ProductManager>(); uygulama da IProductService bagimliligi istenirse ona karsilik olarak arka planda ProductManager'ý new'leyip referans veriyoruz.
                 ProductManager'i new'leme iþlemi yaparken o sýnýfýnda baðýmlý olduðu IProductDal interface'i var. O interface'inde somut sýnýfý olan  EfProductDal sýnýfýna baðýmlýlýðý var o yüzden ikisini beraber tanýmlarýz.
                 Tüm uygulamada sadece bir tane ProductManager referansý oluþturuluyor. Tüm kullanýcýlara bu referans adresi üzerinden iþlem yaptýrýyoruz.
                 Ozetle uygulama icerisinde constructor icerisinde IProductService istenirse ona arka planda ProductManager'in referansýný verecegiz.
                
             */


            //services.AddSingleton<IProductService, ProductManager>();
            //services.AddSingleton<IProductDal, EfProductDal>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
