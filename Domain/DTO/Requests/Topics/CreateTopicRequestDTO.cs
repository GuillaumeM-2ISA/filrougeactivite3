using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Topic
{
    public class CreateTopicRequestDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int MemberId { get; set; }
    }

    public class CreateTopicRequestDTOValidator : AbstractValidator<CreateTopicRequestDTO>
    {
        public CreateTopicRequestDTOValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
            RuleFor(x => x.MemberId).NotNull().NotEmpty();
        }
    }
}
