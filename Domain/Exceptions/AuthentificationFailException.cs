using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AuthentificationFailException : Exception
    {
        public AuthentificationFailException() : base("L'authentification a échoué")
        {

        }
    }
}
