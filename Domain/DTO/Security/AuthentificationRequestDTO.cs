using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Security
{
    public class AuthentificationRequestDTO
    {
        public string Nickname { get; set; }

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
