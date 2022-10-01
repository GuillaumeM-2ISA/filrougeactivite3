using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Members
{
    public class CreateMemberResponseDTO
    {
        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
