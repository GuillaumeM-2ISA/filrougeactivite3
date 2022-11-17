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
        private bool _isFind = false;
        public Boolean IsFind 
        {
            get
            {
                return _isFind;
            }

            set
            {
                _isFind = value;
                RaisePropertyChanged();
            }
        }

        private readonly ObservableCollection<BOTopic> _topics = new ObservableCollection<BOTopic>();
        public ObservableCollection<BOTopic> Topics
        {
            get { return _topics; }
        }

        public async Task<bool> GetTopicsByCategoryId(int categoryId)
        {
            IsFind = true;
            await Task.Delay(1500);
            var topics = await DAL.Instance.GetTopicsByCategoryId(categoryId);
            IsFind = false;

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
