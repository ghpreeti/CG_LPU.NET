using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDisconArchDemo
{
    public interface IRepo<T>
    {
            List<T> ShowAll();
            T GetById(int id);
            bool AddData(T item);
            bool UpdateData(int id, T obj);
            bool DeleteData(int id);
    }
}
