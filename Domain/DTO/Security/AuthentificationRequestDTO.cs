using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Security
{
    /// <summary>
    /// Classe DTO de requête d'authentification
    /// </summary>
    public class AuthentificationRequestDTO
    {
        /// <summary>
        /// Pseudonyme du DTO de requête d'authentification
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Mot de passe du DTO de requête d'authentification
        /// </summary>
        public string Password { get; set; }
    }

    public class AuthentificationRequestDTOValidator : AbstractValidator<AuthentificationRequestDTO>
    {
        public AuthentificationRequestDTOValidator()
        {
            RuleFor(x => x.Nickname).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
