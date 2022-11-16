using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    class TopicsM
    {
        public List<BOTopic> GetTopicsByCategoryId(int categoryId)
        {
            return new List<BOTopic>
            {
                new BOTopic() { Id = 1, Title = "title_1", Description = "description_1", CategoryId = 1, MemberId = 1 },
                new BOTopic() { Id = 2, Title = "title_2", Description = "description_2", CategoryId = 1, MemberId = 1 },
                new BOTopic() { Id = 3, Title = "title_3", Description = "description_3", CategoryId = 1, MemberId = 1 },
                new BOTopic() { Id = 4, Title = "title_4", Description = "description_4", CategoryId = 1, MemberId = 1 }
            };
        }
    }
}
