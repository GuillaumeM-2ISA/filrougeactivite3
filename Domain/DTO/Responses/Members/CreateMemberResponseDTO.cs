using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Members
{
    /// <summary>
    /// Classe DTO de réponse de la création de membre
    /// </summary>
    public class CreateMemberResponseDTO
    {
        /// <summary>
        /// Pseudonyme du DTO de réponse de la création de membre
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Email du DTO de réponse de la création de membre
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Token du DTO de réponse de la création de membre
        /// </summary>
        public string Token { get; set; }
    }
}
