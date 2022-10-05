using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// Classe Topic représentant un sujet sur le forum
    /// </summary>
    public class Topic : Entity
    {
        /// <summary>
        /// Propriété de date de création du sujet
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Propriété du titre du sujet
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Propriété de la description du sujet
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Propriété de la date de mise à jour du sujet
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Propriété de l'id de la catégorie du sujet
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Propriété de l'id du créateur du sujet
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// Propriété du membre du sujet
        /// </summary>
        public Member Member { get; set; }
    }
}
