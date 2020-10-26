using System;

namespace Domain.UseCases.Exceptions
{
    public class IncorrectPaginationValuesException : Exception
    {
        public IncorrectPaginationValuesException(string message) : base(message)
        {
            
        }
    }
}