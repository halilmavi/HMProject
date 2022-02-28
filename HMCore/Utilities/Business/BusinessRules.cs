using HMCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Business
{
    public class BusinessRules
    {
        // params keywordu ile IResult tipindeki Run metoduna istediğimiz kadar IResult'i parametre olarak gönderme işlemi yapabiliriz.
        // Run metoduna parametre olarak gelen degerleri IResult dizisi tipinde olan logics'e atama islemi yapariz.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                // Run metoduna params uzerinden gelen IResult döndüren değerleri sırasıyla başarılı olup olmaması durumuna göre kurala uymayani return etme islemi yaptik.
                if (!logic.Success)
                {
                    return logic;           // Başarılı olmayan iş sınıfmızdaki metodu geri döndürüyoruz.
                }
               
            }
            return null;
        }
    }
}
