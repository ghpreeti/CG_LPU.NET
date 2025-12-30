using System;
using System.Collections.Generic;
using System.Text;

namespace LPU_Common
{
    /// <summary>
    /// Custom generic class created for demo with custom generic method
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericClass<T>
    {
        public void SwapMe(ref T obj1,ref T obj2) { 
            T temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
    }
}
