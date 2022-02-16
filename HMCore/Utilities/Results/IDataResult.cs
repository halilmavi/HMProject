using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    // IProductService icerisinde IResult interface icerisinde bulunan ürün durum bilgisi ve mesaj bilgisini IDataResult icerisinde de kullanacagimiz icin kalitim olarak ekleme islemi yaptik.
    // Generic <T> olarak tanımlamamızın sebebi de farklı metotlarda kullandığımız için hangi tipte çalışacağımızı dinamik olarak karar vermemiz gerekiyor. Yani tek bir ürün için olabilir,
    // tüm ürünleri döndürmek için olabilir, kategorisine göre ürün döndürmek için olabilir.
    // T türünde gelen parametreye kısıtlama koymuyoruz çünkü her sey olabilir. 
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
