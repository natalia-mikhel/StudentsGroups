using System;

namespace Domain.UseCases.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message)
        {
            
        }
    }
}