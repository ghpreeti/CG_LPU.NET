using System;
using System.Collections.Generic;
using System.Text;

namespace Day5DemoException
{
    public class BalanceUnderFlowException : Exception
    {
        public BalanceUnderFlowException() : base()
        {

        }

        public BalanceUnderFlowException(string errorMsg) : base(errorMsg)
        {

        }

    }
}
