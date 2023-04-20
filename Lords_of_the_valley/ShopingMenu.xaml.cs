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
using System.Collections.ObjectModel;
using Windows.UI;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class ShopingMenu : Page
    {
        public string currentMoney = "1000";
        public ObservableCollection<ShopCardModel> Cards { get; set; } = new ObservableCollection<ShopCardModel>();
        public ShopingMenu()
        {
            this.InitializeComponent();

            for (int i = 0; i < 30; ++i)
            {
                SolidColorBrush color = new SolidColorBrush(Color.FromArgb(10,10,10,10));


                int price=300;
                if (i%5==0)
                {
                    price = 550;
                }
                Cards.Add(new ShopCardModel("NAME " + i, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, 0, i,price,color));
            }
        }

        private void MainMenu_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            StackPanel s = b.Parent as StackPanel;
            for (int i=0; i<3;i++)
            {
                Button button = s.Children[i] as Button;
                button.IsTabStop = false;
            }
            ComboBox box = s.Children[3] as ComboBox;
            box.IsTabStop = false;

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
            DarkShop.Visibility = Visibility.Collapsed;
            BuyButton.IsTabStop = false;
            DarKCard.Visibility = Visibility.Visible;
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

            BuyButton.IsTabStop = true;            
            BuyButton.Focus(FocusState.Keyboard);
            CardCollection.IsItemClickEnabled = false;
            DarkShop.Visibility = Visibility.Visible;
            DarKCard.Visibility = Visibility.Collapsed;


            ChangeSelectedCard(e.ClickedItem as ShopCardModel);

        }

        private void ChangeSelectedCard(ShopCardModel card)
        {
            CardName.Text = card.name;
            CardPrice.Text = card.price.ToString();
            CardImage.Source = card.imgSource;
        }
        private void ESC_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                GridViewItem gridElem = FocusManager.GetFocusedElement() as GridViewItem;
                ListViewItem listElem = FocusManager.GetFocusedElement() as ListViewItem;
                if (gridElem != null)
                {
                    for(int i=0;i<3;i++)
                    {
                        Button button = ChooseType.Children[i] as Button;
                        button.IsTabStop = true;
                    }
                    ComboBox box = ChooseType.Children[3] as ComboBox;
                    box.IsTabStop = false;

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
                    DarkShop.Visibility = Visibility.Visible;
                }
                else if ( FocusManager.GetFocusedElement()==BuyButton)
                {

                    GetFocusShopList();
                   
                }
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            int cardPrice = int.Parse(CardPrice.Text);
            int myMoney = int.Parse(currentMoney);

            if ( cardPrice <= myMoney)
            {
                currentMoney = (myMoney - cardPrice).ToString();
                Money.Text = currentMoney;
            }
             GetFocusShopList();

            
        }

        private void GetFocusShopList()
        {
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
            DarkShop.Visibility = Visibility.Collapsed;
            BuyButton.IsTabStop = false;
            DarKCard.Visibility = Visibility.Visible;
        }
    }
}
