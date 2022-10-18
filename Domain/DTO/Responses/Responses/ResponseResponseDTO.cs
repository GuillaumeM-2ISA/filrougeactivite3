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
        /// Id du DTO de réponse de réponse
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contenu du DTO de réponse de réponse
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Id du sujet du DTO de réponse de réponse
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Id du membre du DTO de réponse de réponse
        /// </summary>
        public int MemberId { get; set; }
    }
}
