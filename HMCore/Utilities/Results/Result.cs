using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    public class Result : IResult
    {
        /*
         Constructor ile sadece okunabilir (getter'lar readonly'dir.) bir yapida tanimlanan propertyleri yazılabilir bir yapiya cevirme islemi yapabiliriz.(Constructor ile set etme işlemini yapabiliriz.)
         ProductManager icerisinde parametre olarak sadece islemin basarili olup olmamasını yani true degerini gonderme islemi yapmak istersek farkli constructor metot daha tanimlayip ilk constructor
             metodumuzu overload ederek sadece succes degerini gönderme islemi yapariz.
         iki tane parametre gelirse ilk metot tetikle"nir ve :this(success) araciligiyla gelen parametre ikinci constructor içerisinde set etme islemi yapilir.
        */


        public Result(bool success, string message ):this(success)
        {
            Message = message;
              
        }


        // İkinci constructor metodumuzu tanimladik. Overload etme islemi tanimladik.
        public Result(bool success)
        {
           
            Success = success;
        }

        // Ürünlerle ilgili islemleri yaparken bilgi verecek olan propertylerimizi get seklinde tanimladik. sadece okunabilir bir yapıda tanimlama islemi yaptik.
        public bool Success { get;}

        public string Message { get; }
    }
}
