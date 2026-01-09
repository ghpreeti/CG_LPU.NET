using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Event
{
    public interface IRepo<T>
    {
        public bool Add(Product obj);
        public Product SearchByID(int id);
    }
}
