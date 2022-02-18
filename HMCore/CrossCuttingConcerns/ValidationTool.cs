using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.CrossCuttingConcerns
{
    /* 
        Tum katmanlarda kullanabilecegimiz bir dogrulama sistemi tanimladik. Validate metodunu ProductManager icerisinden tanimliyoruz ve parametrelerini gonderiyoruz.
        Validate metoduna parametre olarak gondermis oldugumuz IValidate interface'i AbstractValidator sınıfına kalitim olarak eklendigi icin;
        Business.ValidationRules.FluentValidation icerisinde tanimli olan ProductValidator sinifi
        icerisinde tanimli olan ProductValidator constructori gelen nesnenin referansını IValidate  interface'i de tutmaktadır.
    */
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);

            }
        }

    }
}
