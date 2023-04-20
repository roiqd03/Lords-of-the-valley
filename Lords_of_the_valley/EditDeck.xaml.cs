using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
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
                CardPlace.Add(new DeckModel("a", "Card Place " + i, i));
            }

            for (int i = 0; i < 30; ++i)
            {
                Cards.Add(new CardModel("NAME " + i, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, 0, i));
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            StackPanel s = b.Parent as StackPanel;
            foreach(Button button in s.Children)
            {
                button.IsTabStop = false;
            }

            for(int i = 0; i < Cards.Count; ++i)
            {
                var gridViewItem = CardCollection.ContainerFromIndex(i);
                if(gridViewItem != null)
                {
                    GridViewItem g = gridViewItem as GridViewItem;
                    g.IsTabStop = true;
                }
            }
            GridViewItem it = CardCollection.ContainerFromIndex(0) as GridViewItem;
            it.Focus(FocusState.Keyboard);
            CardCollection.IsItemClickEnabled = true;
        }

        private void CardCollection_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < Cards.Count; ++i)
            {
                var gridViewItem = CardCollection.ContainerFromIndex(i);
                if (gridViewItem != null)
                {
                    GridViewItem g = gridViewItem as GridViewItem;
                    g.IsTabStop = false;
                }
            }

            for (int i = 0; i < CardPlace.Count; ++i)
            {
                var listViewItem = CardPlaceList.ContainerFromIndex(i);
                if (listViewItem != null)
                {
                    ListViewItem l = listViewItem as ListViewItem;
                    l.IsTabStop = true;
                }
            }

            ListViewItem it = CardPlaceList.ContainerFromIndex(0) as ListViewItem;
            it.Focus(FocusState.Keyboard);
            CardCollection.IsItemClickEnabled = false;
            CardPlaceList.IsItemClickEnabled = true;
        }

        private void CardPlaceList_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < CardPlace.Count; ++i)
            {
                var listViewItem = CardPlaceList.ContainerFromIndex(i);
                if (listViewItem != null)
                {
                    ListViewItem l = listViewItem as ListViewItem;
                    l.IsTabStop = false;
                }
            }

            for (int i = 0; i < Cards.Count; ++i)
            {
                var gridViewItem = CardCollection.ContainerFromIndex(i);
                if (gridViewItem != null)
                {
                    GridViewItem g = gridViewItem as GridViewItem;
                    g.IsTabStop = true;
                }
            }

            GridViewItem it = CardCollection.ContainerFromIndex(0) as GridViewItem;
            it.Focus(FocusState.Keyboard);
            CardCollection.IsItemClickEnabled = true;
            CardPlaceList.IsItemClickEnabled = false;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ChooseDeck));
        }

        private void ESC_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Escape)
            {
                GridViewItem gridElem = FocusManager.GetFocusedElement() as GridViewItem;
                ListViewItem listElem = FocusManager.GetFocusedElement() as ListViewItem;
                if (gridElem != null)
                {
                    foreach (Button button in ChooseType.Children)
                    {
                        button.IsTabStop = true;
                    }
                    Button b = ChooseType.Children[0] as Button;
                    b.Focus(FocusState.Keyboard);

                    for (int i = 0; i < Cards.Count; ++i)
                    {
                        var gridViewItem = CardCollection.ContainerFromIndex(i);
                        if (gridViewItem != null)
                        {
                            GridViewItem g = gridViewItem as GridViewItem;
                            g.IsTabStop = false;
                        }
                    }
                    CardCollection.IsItemClickEnabled = false;
                }
                else if(listElem != null)
                {
                    for (int i = 0; i < CardPlace.Count; ++i)
                    {
                        var listViewItem = CardPlaceList.ContainerFromIndex(i);
                        if (listViewItem != null)
                        {
                            ListViewItem l = listViewItem as ListViewItem;
                            l.IsTabStop = false;
                        }
                    }

                    for (int i = 0; i < Cards.Count; ++i)
                    {
                        var gridViewItem = CardCollection.ContainerFromIndex(i);
                        if (gridViewItem != null)
                        {
                            GridViewItem g = gridViewItem as GridViewItem;
                            g.IsTabStop = true;
                        }
                    }

                    GridViewItem it = CardCollection.ContainerFromIndex(0) as GridViewItem;
                    it.Focus(FocusState.Keyboard);
                    CardCollection.IsItemClickEnabled = true;
                    CardPlaceList.IsItemClickEnabled = false;
                }
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
        public int place;
        public int id;
        public string name;
        public CardModel(string name_, string img, string desc, int attack_, int armor_, int mana_, int place_, int id_)
        {
            string s = System.IO.Directory.GetCurrentDirectory() + "\\" + img;
            this.imgSource = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(s));
            this.description = desc;
            this.attack = attack_;
            this.armor = armor_;
            this.mana = mana_;
            this.place = place_;
            this.id = id_;
            this.name = name_;
        }
    }
}
