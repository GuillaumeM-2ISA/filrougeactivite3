using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Members
{
    /// <summary>
    /// Classe DTO de requête de création de membre
    /// </summary>
    public class CreateMemberRequestDTO
    {
        /// <summary>
        /// Pseudonyme du DTO de requête de création de membre
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Adresse email du DTO de requête de création de membre
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mot de passe du DTO de requête de création de membre
        /// </summary>
        public string Password { get; set; }
    }

    public class CreateMemberRequestDTOValidator : AbstractValidator<CreateMemberRequestDTO>
    {
        public CreateMemberRequestDTOValidator()
        {
            RuleFor(x => x.Nickname).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
