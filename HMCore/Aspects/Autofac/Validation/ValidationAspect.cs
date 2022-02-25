using Castle.DynamicProxy;
using FluentValidation;
using HMCore.CrossCuttingConcerns;
using HMCore.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Aspects.Autofac.Validation
{
    // ValidationAspect sınıfımızı şuan bir attribute gibi tanımladık, metotlar ve classlara bu attribute tanımlayacağız.
    // Bu attribute'u metotların calışmasının öncesinde veya  sonrasında tanımlarız. Validation(doğrulama işlemi başta yapıldığı için OnBefore metodunu tetikleriz.)
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        //ProductManager'da attribute olarak tanimlamis oldugumuz ValidationAspect'e Type ile parametre gonderme islemi yaparız.
        public ValidationAspect(Type validatorType)
        {
            // defensive coding(savunma odaklı kod);
            //  attribute'lar typeof ile calistigi icin ProductManager icerisinden ValidationAspect parametre olarak gonderilen  ProductValidator tipi yerine yanlis bir sey yazilsa(ornegin Product gibi)
            //   hata almayız calisma aninda bu hatayi aliriz. O yuzden gelen tip bilgisini(ProductValidator)  kontrol ettikten sonra işlem yaparız.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil !");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // Activator.CreateInstance ile reflection işlemi tanımlamış oluyoruz. Yani programın çalışma anında ProductManager içerisinden gelen ProductValidator'un intance'nı üretme işlemi yapmasını saglıyor.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // _validatorType icerisine atmış oldugumuz ProductValidator 'in BaseType'ni bul, BaseType'i ProductValidator dosyasındaki AbstractValidator<> sınıfının generic argümanının ilkini bul.(Yani Product )
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // ValidationAspect attribute'nun tanımlandığı ilgili metodun parametrelerini gezip bir üst satırda yakalanan generic parametreyi yani entityType'i ilgili metodun parametresine esit olanı bulup entities icerisine ata. 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  

            // Bulmus oldugumuz entities icerisindeki nesneyi static olarak olusturmus oldugumuz ValidationTool sinifinin Validate metoduna parametre olarak gonderme islemi yapiyoruz.
            foreach (var entity in entities)
            {
                // Validate metoduna parametre olarak gonderdigimiz validator icerisine ProductValidator'den gelen nesnenin instance'ni atadik. 
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
