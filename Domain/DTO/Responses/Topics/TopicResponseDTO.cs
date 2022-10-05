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
        /// Titre du DTO de réponse de sujet
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description du DTO de réponse de sujet
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Nom de la catégorie du DTO de réponse de sujet
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Pseudonyme du membre du DTO de réponse de sujet
        /// </summary>
        public string MemberNickname { get; set; }
    }
}
