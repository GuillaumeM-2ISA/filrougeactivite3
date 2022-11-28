using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Topic
{
    /// <summary>
    /// Classe DTO de requête de mise à jour du sujet
    /// </summary>
    public class UpdateTopicRequestDTO
    {
        /// <summary>
        /// Identifiant du DTO de requête de mise à jour du sujet
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre du DTO de requête de mise à jour du sujet
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description du DTO de requête de mise à jour du sujet
        /// </summary>
        public string Description { get; set; }
    }

    public class UpdateTopicRequestDTOValidator : AbstractValidator<UpdateTopicRequestDTO>
    {
        public UpdateTopicRequestDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(250);
        }
    }
}
