using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NicknameMustBeUniqueException : Exception
    {
        public NicknameMustBeUniqueException() : base("Le pseudonyme doit être unique")
        {

        }
    }
}
