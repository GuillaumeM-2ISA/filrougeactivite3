using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Topic
{
    /// <summary>
    /// Classe DTO de requête de création du sujet
    /// </summary>
    public class CreateTopicRequestDTO
    {
        /// <summary>
        /// Titre du DTO de requête de création du sujet
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description du DTO de requête de création du sujet
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identifiant de la catégorie du DTO de requête de création du sujet
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Identifiant du membre du DTO de requête de création du sujet
        /// </summary>
        public int MemberId { get; set; }
    }

    public class CreateTopicRequestDTOValidator : AbstractValidator<CreateTopicRequestDTO>
    {
        public CreateTopicRequestDTOValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(250);
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.MemberId).NotNull().NotEmpty();
        }
    }
}
