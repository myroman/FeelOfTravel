using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Logic
{
    public class PageException : Exception
    {
        public PageException()
        {
        }

        public PageException(string message) : base(message)
        {
        }

        public PageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}