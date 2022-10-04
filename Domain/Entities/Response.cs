using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe Response représentant une réponse sur le forum
    /// </summary>
    public class Response : Entity
    {
        /// <summary>
        /// Propriété de date d'envoi de la réponse
        /// </summary>
        public DateTime SentOn { get; set; }

        /// <summary>
        /// Propriété du contenu de la réponse
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Propriété de l'id du sujet de la réponse
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Propriété de l'id de l'auteur de la réponse
        /// </summary>
        public int MemberId { get; set; }
    }
}
