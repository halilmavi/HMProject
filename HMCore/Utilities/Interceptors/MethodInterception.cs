using Castle.DynamicProxy;
using System;

namespace HMCore.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        // invocation nesnesi business da çalıştırmak istediğimiz metodumuzu temsil etmektedir.
        // virtual olarak tanımladığımız metotları başka yerde override ederek farklı işlemlerimizi tanımlarız.
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }


        public override void Intercept(IInvocation invocation)  
        {
            var isSuccess = true;
            OnBefore(invocation);                                // Attribute'ların  metotlarımızdan önce çalışması için OnBefore olarak tanımlıyoruz.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)                                 
            {
                isSuccess = false;
                OnException(invocation, e);                      // Hata aldığında çalışmasını istersek catch icerisine tanımlarız.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);                       // Tüm işlemlerin ardından başarılı olursa bu metodumuz çalışsın.
                }
            }
            OnAfter(invocation);                                 // Metottan sonra çalışsın istersek bu şekilde tanımlamamız gerekir.
        }
    }

    
}
