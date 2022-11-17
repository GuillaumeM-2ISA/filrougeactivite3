using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace _2isaForumAppMobile
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AddressPage : Page
    {
        //Création du ViewModel
        private CategoryVM vm = new CategoryVM();

        public AddressPage()
        {
            this.InitializeComponent();

            // Liaison entre la View et le ViewModel
            DataContext = vm;
        }

        private void MnuDevelopment_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DevelopmentPage));
        }

        private void MnuQuestions_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuestionsPage));
        }

        private void MnuRelaxZone_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RelaxZonePage));
        }

        private async void MnuRefresh_Click(object sender, RoutedEventArgs e)
        {
            await vm.GetTopicsByCategoryId(2);
        }

        private void lstTopics_ItemClick(object sender, ItemClickEventArgs e)
        {
            var topic = e.ClickedItem as BOTopic;
            TopicPageParameters tpp = new TopicPageParameters { CategoryId = topic.CategoryId, Id = topic.Id };
            Frame.Navigate(typeof(TopicPage), tpp);
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await vm.GetTopicsByCategoryId(2);
        }
    }
}
