using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Members
{
    /// <summary>
    /// Classe DTO de requête de mise à jour du mot de passe
    /// </summary>
    public class UpdatePasswordRequestDTO
    {
        /// <summary>
        /// Identifiant du DTO de requête de mise à jour du mot de passe
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mot de passe du DTO de requête de mise à jour du mot de passe
        /// </summary>
        public string Password { get; set; }
    }

    public class UpdatePasswordRequestDTOValidator : AbstractValidator<UpdatePasswordRequestDTO>
    {
        public UpdatePasswordRequestDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
