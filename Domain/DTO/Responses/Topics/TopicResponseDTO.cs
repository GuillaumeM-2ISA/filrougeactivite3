using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Responses.Topics
{
    public class TopicResponseDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string MemberNickname { get; set; }
    }
}
