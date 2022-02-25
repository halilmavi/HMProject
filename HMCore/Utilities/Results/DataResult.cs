using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    // Result sınıfı içerisinde tanımlamış olduğumuz kodlar burası içinde geçerli o yüzden direkt Result sınıfını kalıtım olarak ekliyoruz. 
    // Result sınıfından farkı bu sınıfımız data da içeriyor olmasıdır. O yüzden IDataResult interface'ni de kalıtım olarak ekliyoruz.
    // Sınıfı ve interface kalıtım olarak eklediğimiz için implemente etmemiz gerekiyor.
    public class DataResult<T> : Result, IDataResult<T>
    {
        // DataResult sınıfı kalıtım olarak almış olduğu Result sınıfının içerisinde ki success ve message ye parametre göndermek icin DataResult constructorımıza parametre gönderme işlemi yapıyoruz.
        // Result içerisinde kodları yazdığımız için tekrar yazmamak için base ile parametreleri geçirdik. 
        public DataResult(T data,bool success, string message):base(success,message)
        {
            Data = data; 
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
