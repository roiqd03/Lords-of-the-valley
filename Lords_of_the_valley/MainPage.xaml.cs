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
        string Money = "1000";
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
            Frame.Navigate(typeof(ChooseDeck), Money);
        }

        private void GamePage_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GamePage), Money);
        }

        private void ShopingMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShopingMenu),Money);
        }

        private void Options_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsMenu), Money);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {                      
            if (Info_Button==sender as Button && Info.Visibility == Visibility.Collapsed) Info.Visibility = Visibility.Visible;
            else Info.Visibility = Visibility.Collapsed;

            if (Social_Button == sender as Button && Social.Visibility == Visibility.Collapsed) Social.Visibility = Visibility.Visible;
            else Social.Visibility = Visibility.Collapsed;

            if (Buzon_Button == sender as Button && Buzón.Visibility == Visibility.Collapsed) Buzón.Visibility = Visibility.Visible;
            else Buzón.Visibility = Visibility.Collapsed;

            if (Misiones_Button == sender as Button && Misiones.Visibility == Visibility.Collapsed) Misiones.Visibility = Visibility.Visible;
            else Misiones.Visibility = Visibility.Collapsed;

            if (Perfíl_Button == sender as Button && Perfil.Visibility == Visibility.Collapsed) Perfil.Visibility = Visibility.Visible;
            else Perfil.Visibility = Visibility.Collapsed; 
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter is string && !string.IsNullOrWhiteSpace((string)e.Parameter))
            {
                Money = $"{e.Parameter.ToString()}";
                MyMoney.Text = Money;
            }
            base.OnNavigatedTo(e);
        }
    }
}
