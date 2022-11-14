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
    public sealed partial class QuestionsPage : Page
    {
        //Création du ViewModel
        private CategoryVM vm = new CategoryVM();

        public QuestionsPage()
        {
            this.InitializeComponent();

            // Liaison entre la View et le ViewModel
            DataContext = vm;
        }

        private void MnuRelaxZone_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RelaxZonePage));
        }

        private void MnuAddress_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddressPage));
        }

        private void MnuDevelopment_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(DevelopmentPage));
        }
    }
}
