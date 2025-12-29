namespace LPU_Exceptions
{
    /// <summary>
    /// Custom Exception class created by 29/12/25 at 11:34 AM
    /// </summary>
    public class LPUException : Exception
    {
        public LPUException():base()
        {
            
        }

        public LPUException(string errorMsg) : base(errorMsg) { }
        
    }
}
