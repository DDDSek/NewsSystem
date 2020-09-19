using System;
using System.Collections.Generic;
using System.Text;

namespace NewsSystem.Domain.Exceptions
{
    public class InvalidCategoryException : BaseDomainException
    {
        public InvalidCategoryException()
        {
        }

        public InvalidCategoryException(string error) => this.Error = error;
    }
}
