using String_Calculator_2._1.Interfaces;

namespace String_Calculator_2._1.Services
{
    public class ErrorHandlingService : IErrorHandling
    {
        public string ThrowException(string exception)
        {
            throw new Exception(exception);
        }
    }
}
