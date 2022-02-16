using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Results
{
    public class SuccessResult : Result
    {
        // SuccessResult gibi ErrorResult sınıfı tanımlayacağız. Result sınıfımıza bu sınıfları parametre olarak göndereceğiz. 
        // SuccessResult metodu üzerinden base(burada Result temsil ediyor.) sınıfımıza true parametresini gönderme işlemi yapıyoruz. 

        public SuccessResult(string message) : base(true, message)
        {

        }

        // Result sınıfında sadece success sonucunu da göndermek isteğimiz durumlar için yine base sınıf için ikinci constructor tanımlama işlemi yaparız.
        public SuccessResult() : base(true)
        {

        }
    }
}
