using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int titleScale = 90;
        public int textScale = 60;
        public double buttonMargin = 40;
        public double imgMargin = 20;
        private double startWidth = 1920;
        private double startHeight = 1080;
        public const int maxDecks = 6;

        public ObservableCollection<DeckModel> Decks { get; } = new ObservableCollection<DeckModel>();

        public List<Button> Buttons { get; } = new List<Button>();
        public List<TextBlock> Texts { get; } = new List<TextBlock>();
        public List<Image> Images { get; } = new List<Image>();

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // calculates incorrect when window is maximized
            double scale = (this.ActualWidth * this.ActualHeight / startWidth / startHeight);

            title_.FontSize = titleScale * scale;
            double margin = buttonMargin * scale;
            double imgMargin_ = imgMargin * scale;
            foreach (Button b in Buttons)
            {
                b.Margin = new Thickness(margin);
            }

            foreach (Image i in Images)
            {
                i.Margin = new Thickness(imgMargin_);
            }

            foreach (TextBlock t in Texts)
            {
                t.FontSize = textScale * scale;
            }
        }

        public ChooseDeck()
        {
            this.InitializeComponent();
            this.SizeChanged += Window_SizeChanged;

            Buttons.Add(Deck1);
            Buttons.Add(Deck2);
            Buttons.Add(Deck3);
            Buttons.Add(Deck4);
            Buttons.Add(Deck5);
            Buttons.Add(Deck6);

            Texts.Add(text1);
            Texts.Add(text2);
            Texts.Add(text3);
            Texts.Add(text4);
            Texts.Add(text5);
            Texts.Add(text6);

            Images.Add(image1);
            Images.Add(image2);
            Images.Add(image3);
            Images.Add(image4);
            Images.Add(image5);
            Images.Add(image6);

            //TEMPORAL
            DeckModel deck1 = new DeckModel("Assets\\DecksImg\\deck1.jpg", "Deck 1", 1);
            Decks.Add(deck1);
            //TEMPORAL
            DeckModel deck2 = new DeckModel("Assets\\DecksImg\\deck2.jpg", "Deck 2", 2);
            Decks.Add(deck2);
            //TEMPORAL
            DeckModel deck3 = new DeckModel("Assets\\DecksImg\\plus.png", "No Deck", 3);
            Decks.Add(deck3);
            //TEMPORAL
            DeckModel deck4 = new DeckModel("Assets\\DecksImg\\plus.png", "No Deck", 4);
            Decks.Add(deck4);
            //TEMPORAL
            DeckModel deck5 = new DeckModel("Assets\\DecksImg\\plus.png", "No Deck", 5);
            Decks.Add(deck5);
            //TEMPORAL
            DeckModel deck6 = new DeckModel("Assets\\DecksImg\\plus.png", "No Deck", 6);
            Decks.Add(deck6);

            int i = 0;
            foreach(DeckModel d in Decks)
            {
                TextBlock t = Texts.ElementAt<TextBlock>(i);
                Image img = Images.ElementAt<Image>(i);

                t.Text = d.name;
                if(d.imgSource == "Assets\\DecksImg\\plus.png")
                {
                    img.Stretch = Stretch.Uniform;
                }
                else
                {
                    img.Stretch = Stretch.Fill;
                }
                string s = System.IO.Directory.GetCurrentDirectory() + "\\" + d.imgSource;
                img.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
                ++i;
            }
        }
    }

    public class DeckModel
    {
        public string imgSource;
        public string name;
        public int id;
        public DeckModel(string img, string n, int id_)
        {
            imgSource = img;
            name= n;
            id= id_;    
        }
    }

   
}


