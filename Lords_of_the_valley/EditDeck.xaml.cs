using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EditDeck : Page
    {
        private double startWidth = 1920;
        private double startHeight = 1080;
        public List<DeckModel> CardPlace { get; set; } = new List<DeckModel>();
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
    public EditDeck()
        {
            this.InitializeComponent();

            //this.SizeChanged += Window_SizeChanged;

            for (int i = 0; i < 30; ++i)
            {
                CardPlace.Add(new DeckModel("a", "Card Name " + i, i));
            }

            for (int i = 0; i < 30; ++i)
            {
                Cards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, i));
            }
        }

        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    // calculates incorrect when window is maximized
        //    double scale = (this.ActualWidth * this.ActualHeight / startWidth / startHeight);
        //    double w = cardWidth * scale;
        //    double h = cardHeight * scale;

        //    foreach (CardModel c in Cards)
        //    {
        //        c.width = w;
        //        c.height = h;
        //    }
        //}
    }

    public class CardModel
    {
        public ImageSource imgSource;
        public string description;
        public int attack;
        public int armor;
        public int mana;
        public int id;
        public CardModel(string img, string desc, int attack_, int armor_, int mana_, int id_)
        {
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + img;
            this.imgSource = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            this.description = desc;
            this.attack = attack_;
            this.armor = armor_;
            this.mana = mana_;
            this.id = id_;
        }
    }
}
