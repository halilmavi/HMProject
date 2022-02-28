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
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();               // GetExecutingAssembly() metodu ile çalışma anında uygulamanın kodlarına erişiriz.

            /*
             Çalışan uygulamalar içerisinde implemente edilmiş interfaceleri bul onlar için AspectInterceptorSelector sınıfını çağırarak bu sınıf içerisindeki SelectInterceptors
               metodu ile attribute'a sahip sınıf ve metotları burdaki Selector içerisine atama işlemi yaparız.
             Yani burda yapmış olduğu temel işlem tüm sınıfları gezip Aspect attribute'una sahip sınıfı bulup o sınıfın attribute'nu tetikle.
            */
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()               
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }
    }
}
