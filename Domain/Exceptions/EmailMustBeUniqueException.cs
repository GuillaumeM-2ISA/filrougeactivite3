using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class EmailMustBeUniqueException : Exception
    {
        public EmailMustBeUniqueException() : base("L'adresse email doit être unique")
        {

        }
    }
}
