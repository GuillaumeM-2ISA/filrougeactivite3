using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Responses
{
    /// <summary>
    /// Classe DTO de réponse de réponse
    /// </summary>
    public class ResponseResponseDTO
    {
        /// <summary>
        /// Contenu du DTO de réponse de réponse
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Titre du sujet du DTO de réponse de réponse
        /// </summary>
        public string TopicTitle { get; set; }

        /// <summary>
        /// Pseudonyme du membre du DTO de réponse de réponse
        /// </summary>
        public int MemberId { get; set; }
    }
}
