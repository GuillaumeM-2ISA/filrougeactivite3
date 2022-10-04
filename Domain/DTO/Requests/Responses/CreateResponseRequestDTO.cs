using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Responses
{
    public class CreateResponseRequestDTO
    {
        public string Content { get; set; }

        public int TopicId { get; set; }

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
