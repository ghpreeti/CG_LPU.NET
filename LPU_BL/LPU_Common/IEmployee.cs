using System;
using System.Collections.Generic;
using System.Text;

namespace LPU_Common
{
    interface IEmployee<T>:IRepo<T>
    {
        List<T> ShowAllFemaleEmployee();
        List<T> ShowAllMaleEmployee();
        List<T> ShowAllEmployeeWithAgeAbove40();
    }
}
