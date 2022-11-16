using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    class TopicVM : ViewModelBase
    {
        private readonly ObservableCollection<BOResponse> _responses = new ObservableCollection<BOResponse>();
        public ObservableCollection<BOResponse> Responses
        {
            get { return _responses; }
        }

        public async Task<bool> GetResponsesByTopicId(int categoryId, int topicId)
        {
            var responses = await DAL.Instance.GetResponsesByTopicId(categoryId, topicId);

            if (responses != null)
            {
                Responses.Clear();
                responses.ForEach(x => Responses.Add(x));
                return true;
            }

            return false;
        }
    }
}
