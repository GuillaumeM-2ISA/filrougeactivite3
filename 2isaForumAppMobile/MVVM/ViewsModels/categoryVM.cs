using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    class CategoryVM : ViewModelBase
    {
        private readonly ObservableCollection<BOTopic> _topics = new ObservableCollection<BOTopic>();
        public ObservableCollection<BOTopic> Topics
        {
            get { return _topics; }
        }

        public async Task<bool> GetTopicsByCategoryId(int categoryId)
        {
            var topics = await DAL.Instance.GetTopicsByCategoryId(categoryId);

            if (topics != null)
            {
                Topics.Clear();
                topics.ForEach(x => Topics.Add(x));
                return true;
            }

            return false;
        }
    }
}
