using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    //Yapmış olduğumuz işlemlerin başarılı olup olmama durumlarını kontrol edeceğimiz interfacemiz.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
