using System;
using System.Collections.Generic;
using System.Text;

namespace LPU_Exceptions
{
    public class BookException : ApplicationException
    {
        public BookException() : base()
        { }
        public BookException(string message) : base(message)
        {
        }
    }
}