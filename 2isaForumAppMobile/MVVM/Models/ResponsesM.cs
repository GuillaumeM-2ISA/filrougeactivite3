using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    class ResponsesM
    {
        public List<BOResponse> GetResponsesByTopicId(int topicId)
        {
            return new List<BOResponse>
            {
                new BOResponse() { Id = 1, Content = "lorem ipsum", TopicId = 1, MemberName = "author_1" },
                new BOResponse() { Id = 2, Content = "lorem ipsum", TopicId = 1, MemberName = "author_2" },
                new BOResponse() { Id = 3, Content = "lorem ipsum", TopicId = 1, MemberName = "author_3" },
                new BOResponse() { Id = 4, Content = "lorem ipsum", TopicId = 1, MemberName = "author_4" }
            };
        }
    }
}
