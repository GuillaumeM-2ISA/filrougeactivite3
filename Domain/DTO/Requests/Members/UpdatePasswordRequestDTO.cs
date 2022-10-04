using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests.Members
{
    public class UpdatePasswordRequestDTO
    {
        public int Id { get; set; }

        public string Password { get; set; }
    }

    public class UpdatePasswordRequestDTOValidator : AbstractValidator<UpdatePasswordRequestDTO>
    {
        public UpdatePasswordRequestDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }
    }
}
