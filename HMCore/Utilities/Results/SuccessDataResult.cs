using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message ):base(data,true,message)
        {

        }

        public SuccessDataResult(T data):base(data,true)
        {

        }

        // Bir şey döndürmek istemediğimiz durumlarda default kullanırız. Default dataya karşılık geliyor.
        public SuccessDataResult(string message):base(default,true,message)
        {
                
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
