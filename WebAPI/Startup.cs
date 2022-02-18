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
                 IoC gibi altyap� sunan farkli yapilar soz konusudur Bunlar; Autofac, Ninject, CastleWindsor,StructMap gibi teknolojilerdir. Bunlar icerisinde en s�k kullanilani AUTOFAC'tir.
                 IoC yerine Autofac vs. lerin kullanilmasinin sebebi AOP(cephe yonelimli programlama) ye izin vermeleridir.
                 IoC 'dan daha perfomansli calistigi icin projemize AUTOFAC'i enject'e edecegiz.
                 AOP'yi uygulama icerisinde tanimlamis oldugumuz metotlarin calisip calismamas�n� hata kontrellerini vs LOG'lama  islemlerini AOP ile yapiyoruz.

                 AddSingleton : Projemiz ilk �al��t�rd���m�z s�rada, servisin tek bir instance��n� olu�turularak memoryde bu bilgiyi tutar ve gelen requestlerde �retilen ayn� intances� kullan�r.
                 Redis, Elastic gibi yap�lar� burada tutabiliriz.
                 Uygulama i�erisinde ba��ml�l�k olu�turdu�umuz ve kulland���m�z nesnenin tek bir sefer olu�turulmas�n� ve ayn� nesnenin uygulama i�inde kullan�lmas�n� sa�lar.           
                 Singleton'� icerisinde data tutmadigimiz zamanlarda kullaniriz.
                 AddSingleton<IProductService,ProductManager>(); uygulama da IProductService bagimliligi istenirse ona karsilik olarak arka planda ProductManager'� new'leyip referans veriyoruz.
                 ProductManager'i new'leme i�lemi yaparken o s�n�f�nda ba��ml� oldu�u IProductDal interface'i var. O interface'inde somut s�n�f� olan  EfProductDal s�n�f�na ba��ml�l��� var o y�zden ikisini beraber tan�mlar�z.
                 T�m uygulamada sadece bir tane ProductManager referans� olu�turuluyor. T�m kullan�c�lara bu referans adresi �zerinden i�lem yapt�r�yoruz.
                 Ozetle uygulama icerisinde constructor icerisinde IProductService istenirse ona arka planda ProductManager'in referans�n� verecegiz.
                
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
