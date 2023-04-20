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
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class OptionsMenu : Page
    {
        public int music;
        public int sound;
        public OptionsMenu()
        {
            this.InitializeComponent();
            music = 100;
            sound = 100;
        }

        private void MainMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Application application = Lords_of_the_valley.App.Current;
            application.Exit();
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            Slider s = b.Content as Slider;
            s.IsTabStop = true;
            s.Focus(FocusState.Keyboard);
        }

        private void Slider_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                Slider s = sender as Slider;
                Button b = s.Parent as Button;
                s.IsTabStop = false;
                b.Focus(FocusState.Keyboard);
            }


        }
    }
}
