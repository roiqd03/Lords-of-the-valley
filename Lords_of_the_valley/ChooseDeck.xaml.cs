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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ChooseDeck : Page
    {
        public int textScale = 70;
        private double startWidth = 1920;
        private double startHeight = 1080;
        private const int maxDecks = 6;
        struct deck
        {
            string imgSource;
            string name;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // calculates incorrect when window is maximized
            
            title_.FontSize = textScale * (this.ActualWidth * this.ActualHeight / startWidth / startHeight);
        }

        public ChooseDeck()
        {
            this.InitializeComponent();
            this.SizeChanged += Window_SizeChanged;
        }
    }
}
