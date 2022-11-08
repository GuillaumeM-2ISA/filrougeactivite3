using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2isaForumAppMobile
{
    class CategoryVM : ViewModelBase
    {
        private string _titre = "Mon titre";
        public string Titre
        {
            get
            {
                return _titre;
            }

            set
            {
                _titre = value;
                RaisePropertyChanged(); // Permet de notifier la View d'une modification
            }
        }
    }
}
