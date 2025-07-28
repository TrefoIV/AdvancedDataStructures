using System;

namespace AdvancedDataStructures.ConcatenatedList
{
    public class ListEmptyException : Exception
    {
        public ListEmptyException() : base()
        { }

        public ListEmptyException(string message) : base(message)
        {
        }

        public ListEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}