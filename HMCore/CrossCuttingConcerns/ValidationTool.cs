using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.CrossCuttingConcerns
{
    /* 
        Tüm katmanlarda kullanabileceğimiz bir doğrulama sistemi tanimladik. Validate metodunu ProductManager icerisinden tanımlıyoruz ve parametrelerini gönderiyoruz.
        Validate metoduna gelen IValidator interface parametresi ile ProductValidator sınıfımızın referans adresine erişim sağlayarak kurallar sınıfımıza erişim sağlıyoruz. 
        
    */
    public static class ValidationTool
    {
        
        public static void Validate(IValidator validator, object entity)    // IValidator kural sınıfımız, entity de doğrulanacak class'ımız.
        {
            var context = new ValidationContext<object>(entity);            // Kullanıcıdan gelen datayı ValidationContext sınıfı türünde yeni bir nesne örneğine dönüştürür.
            var result = validator.Validate(context);                       // Validate metoduna parametre olarakta datamızı  gönderme işlemi yapıyoruz.
            
            if (!result.IsValid)                                            // IsValid: Validasyon işleminin başarılı olup olmadığına dair boolean değer döndürür.
            {
                throw new ValidationException(result.Errors);

            }
        }

    }
}
