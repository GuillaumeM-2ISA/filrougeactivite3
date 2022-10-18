using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Topics
{
    /// <summary>
    /// Classe DTO de réponse de sujet
    /// </summary>
    public class TopicResponseDTO
    {
        /// <summary>
        /// Id du DTO de réponse du sujet
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre du DTO de réponse de sujet
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description du DTO de réponse de sujet
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id de la catégorie du DTO de réponse de sujet
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Id du membre du DTO de réponse de sujet
        /// </summary>
        public int MemberId { get; set; }
    }
}
