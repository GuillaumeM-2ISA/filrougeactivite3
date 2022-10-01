using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Topic : Entity
    {
        public DateTime CreatedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CategoryId { get; set; }

        public int MemberId { get; set; }
    }
}
