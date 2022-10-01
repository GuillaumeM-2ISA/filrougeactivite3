using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Response : Entity
    {
        public DateTime SentOn { get; set; }

        public string Content { get; set; }

        public int TopicId { get; set; }

        public int MemberId { get; set; }
    }
}
