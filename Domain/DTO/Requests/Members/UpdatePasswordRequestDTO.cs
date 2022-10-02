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
}
