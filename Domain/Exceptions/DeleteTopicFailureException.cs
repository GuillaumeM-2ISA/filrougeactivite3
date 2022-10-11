using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeleteTopicFailureException : Exception
    {
        public DeleteTopicFailureException() : base("Une erreur est survenue lors de la suppression du sujet et de ses réponses")
        {

        }
    }
}
