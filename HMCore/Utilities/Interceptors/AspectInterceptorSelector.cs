﻿using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMCore.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            // metot ve class'larla ilgili tanımlanmış olan attribute'ları GetCustomAttributes ve GetMethod metotları ile okuyup tanımlanan bu attributeları liste yapıp en son Priority(öncelik sırası) e göre sıralayıp döndürüyüruz.
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>     // Class' lara tanımlamış olduğumuz attributeleri okuyacak metodumuz.
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)                                   // Method' lara tanımlamış olduğumuz attributeleri okuyacak metodumuz.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            

            return classAttributes.OrderBy(x => x.Priority).ToArray();                           // Tanımlanan attribute'ları öncelik değerine göre sıralama işlemi yapıp döndüreceğiz.
        }
    }

    
}
