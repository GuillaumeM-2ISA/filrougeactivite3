using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Members
{
    /// <summary>
    /// Classe DTO de réponse de membre
    /// </summary>
    public class MemberResponseDTO
    {
        /// <summary>
        /// Pseudonyme du DTO de réponse de membre
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Adresse email du DTO de réponse de membre
        /// </summary>
        public string Email { get; set; }

        public override bool Equals(object obj)
        {
            return obj is MemberResponseDTO dTO &&
                   Nickname == dTO.Nickname &&
                   Email == dTO.Email;
        }
    }
}
