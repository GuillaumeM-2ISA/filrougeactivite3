using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Topic
{
    public class UpdateTopicRequestDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }

    public class UpdateTopicRequestDTOValidator : AbstractValidator<UpdateTopicRequestDTO>
    {
        public UpdateTopicRequestDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Title).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.CategoryId).NotNull().NotEmpty();
        }
    }
}
