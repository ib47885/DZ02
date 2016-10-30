using System;
using System.Runtime.Serialization;

namespace Repositories
{
    [Serializable]
    public class DuplicateTodoItemException : Exception
    {
        private object p;

        public DuplicateTodoItemException()
        {
            Console.WriteLine(" duplicate id!");
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public DuplicateTodoItemException(object p)
        {
            this.p = p;
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}