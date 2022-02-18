using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using HMBusiness.Abstract;
using HMBusiness.Concrete;
using HMCore.Utilities.Interceptors;
using HMDataAccess.Abstract;
using HMDataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMBusiness.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    { 
        // Uygulamamız çalışmaya başladığında yani canlıya alındığında burası çalışacak.
        protected override void Load(ContainerBuilder builder)
        {
            // Uygulamamizda bizden IProductService interface'i istenildigi zaman RegisterType bize ProductManagerdan nesne türetip bu nesnenin referansını verme islemi yapiyor.
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
