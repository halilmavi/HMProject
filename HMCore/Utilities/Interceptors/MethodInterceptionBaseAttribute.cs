using Castle.DynamicProxy;
using System;

namespace HMCore.Utilities.Interceptors
{
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] // Class'lara ve method'lara ekleyebileceğimizi tanımladık.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {

        public int Priority { get; set; }           // Attribute'ların çalışma sırasını tanımladığımız propertymiz.(Örneğin validation loglamadan önce çalışsın veya cachelemeden önce çalışsın gibi.)

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

    
}
