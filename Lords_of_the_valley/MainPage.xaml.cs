using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Lords_of_the_valley
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected void OnPageLoad(object sender, RoutedEventArgs e)
        {
            StartButton.Focus(FocusState.Keyboard);
        } 

        private void ChooseDeck_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChooseDeck));
        }

        private void GamePage_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage));
        }

        private void ShopingMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShopingMenu));
        }

        private void Options_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsMenu));
        }
    }
}
