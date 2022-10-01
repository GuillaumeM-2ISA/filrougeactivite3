using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Members
{
    public class CreateMemberRequestDTO
    {
        public string Nickname { get; set; }

        public string Email { get; set; }

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
