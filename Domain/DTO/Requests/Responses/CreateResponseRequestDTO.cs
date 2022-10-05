using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Responses
{
    /// <summary>
    /// Classe DTO de requête de création de réponse
    /// </summary>
    public class CreateResponseRequestDTO
    {
        /// <summary>
        /// Contenu du DTO de requête de création de réponse
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Identifiant du sujet du DTO de requête de création de réponse
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Identifiant du membre du DTO de requête de création de réponse
        /// </summary>
        public int MemberId { get; set; }
    }

    public class CreateResponseRequestDTOValidator : AbstractValidator<CreateResponseRequestDTO>
    {
        public CreateResponseRequestDTOValidator()
        {
            RuleFor(x => x.Content).NotNull().NotEmpty();
            RuleFor(x => x.TopicId).NotNull().NotEmpty();
            RuleFor(x => x.MemberId).NotNull().NotEmpty();
        }
    }
}
