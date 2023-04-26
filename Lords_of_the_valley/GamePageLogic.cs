using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Input;

namespace Lords_of_the_valley
{
    public class GamePageLogic : ObservableObject
    {
        enum CardPlace { Hand, Table, RivalTable, RivalHand, FinalEnum };
        private GamePage page;

        public List<Border> manaList = new List<Border>();
        public List<Border> rivalManaList = new List<Border>();
        public const int maxPosibleMana = 10;

        enum DarkZones { Left, Top_Center, Right, FinalDarkEnum };
        enum ButtonsEnum { Ready, Power, FinalButtonsEnum };
        public GridView[] gridViews = new GridView[(int)CardPlace.FinalEnum];
        public Button[] buttons = new Button[(int)ButtonsEnum.FinalButtonsEnum];
        public Windows.UI.Xaml.Shapes.Rectangle[] darkZones = new Windows.UI.Xaml.Shapes.Rectangle[(int)DarkZones.FinalDarkEnum];

        private int actualMana = 5;
        private int maxMana = 7;

        public string manaText = "";
        public string rivalManaText = "";

        private int rivalActualMana = 7;
        private int rivalMaxMana = 7;

        public int numCards = 4;
        public int numRivalCards = 3;

        public ObservableCollection<CardModel> Cards { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> RivalCards { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> TableCards { get; set; } = new ObservableCollection<CardModel>();
        public ObservableCollection<CardModel> TableRivalCards { get; set; } = new ObservableCollection<CardModel>();


        public GamePageLogic()
        {
            int id1 = (int)CardPlace.Hand;
            int id2 = (int)CardPlace.Table;
            int id3 = (int)CardPlace.RivalTable;

            for (int i = 0; i < numCards; ++i)
            {
                Cards.Add(new CardModel("NAME " + i + " " + id1, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id1));
            }

            for (int i = 0; i < numRivalCards; ++i)
            {
                RivalCards.Add(new CardModel("NAME " + i, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, -1));
            }

            for (int i = 0; i < 4; ++i)
            {
                TableCards.Add(new CardModel("NAME " + i + " " + id2, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id2));
            }

            for (int i = 0; i < 2; ++i)
            {
                TableRivalCards.Add(new CardModel("NAME " + i + " " + id3, "Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id3));
            }
        }

        public void setGridViews(GridView hand, GridView table, GridView rivalTable, GridView rivalHand)
        {
            gridViews[(int)CardPlace.Hand] = hand;
            gridViews[(int)CardPlace.Table] = table;
            gridViews[(int)CardPlace.RivalTable] = rivalTable;
            gridViews[(int)CardPlace.RivalHand] = rivalHand;
        }

        public void setDarkZones(Windows.UI.Xaml.Shapes.Rectangle left, Windows.UI.Xaml.Shapes.Rectangle center, Windows.UI.Xaml.Shapes.Rectangle right)
        {
            darkZones[(int)DarkZones.Left] = left;
            darkZones[(int)DarkZones.Top_Center] = center;
            darkZones[(int)DarkZones.Right] = right;
        }

        public void setButtons(Button power, Button ready)
        {
            buttons[(int)ButtonsEnum.Ready] = ready;
            buttons[(int)ButtonsEnum.Power] = power;
        }

        public void Options_OnClick(object sender, RoutedEventArgs e)
        {
            page.Frame.Navigate(typeof(OptionsMenu));
        }


        public void myHand_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            CardModel card = (CardModel)e.Items[0];
            e.Data.SetText("0-" + card.name);
            e.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }


        public async void AllyTable_DragOver(object sender, DragEventArgs e)
        {
            var items = await e.DataView.GetTextAsync();
            if (items.ToString()[0] == '0')
            {
                e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
            }
            else e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.None;
        }

        public async void AllyTable_Drop(object sender, DragEventArgs e)
        {
            var items = await e.DataView.GetTextAsync();
            string[] info = items.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (info[0] == "0")
            {
                int i = 0;
                while (i < Cards.Count() && Cards[i].name != info[1]) ++i;
                if (i >= Cards.Count()) return;
                CardModel c = Cards[i];
                if (actualMana >= c.mana)
                {
                    Cards.RemoveAt(i);
                    TableCards.Add(c);
                    ObservableCollection<CardModel> handCollection = (ObservableCollection<CardModel>)gridViews[(int)CardPlace.Hand].ItemsSource;
                    RaisePropertyChanged(nameof(handCollection));
                    ObservableCollection<CardModel> tableCollection = (ObservableCollection<CardModel>)gridViews[(int)CardPlace.Table].ItemsSource;
                    RaisePropertyChanged(nameof(tableCollection));
                    actualMana -= c.mana;
                    UpdateManaUI();
                }
            }
        }

        public void setPage(GamePage pg)
        {
            page = pg;
        }

        public void UpdateManaUI()
        {
            int i = 0;
            foreach (Border mana in manaList)
            {
                if (i < actualMana)
                {
                    mana.Visibility = Visibility.Visible;
                    mana.Background = new SolidColorBrush(Colors.Blue);
                }
                else if (i < maxMana)
                {
                    mana.Visibility = Visibility.Visible;
                    mana.Background = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    mana.Visibility = Visibility.Collapsed;
                }
                ++i;
            }


            i = 0;
            foreach (Border mana in rivalManaList)
            {
                if (i < rivalActualMana)
                {
                    mana.Visibility = Visibility.Visible;
                    mana.Background = new SolidColorBrush(Colors.Blue);
                }
                else if (i < rivalMaxMana)
                {
                    mana.Visibility = Visibility.Visible;
                    mana.Background = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    mana.Visibility = Visibility.Collapsed;
                }
                ++i;
            }



            manaText = actualMana.ToString() + "/" + maxMana.ToString();
            rivalManaText = rivalActualMana.ToString() + "/" + rivalMaxMana.ToString();

            RaisePropertyChanged(nameof(manaText));
            RaisePropertyChanged(nameof(rivalManaText));
        }

        public void GridView_ItemClick (object sender, ItemClickEventArgs e)
        {
            CardModel card = e.ClickedItem as CardModel;
            page.ChangeSelectedCard(card);
            if (sender == gridViews[(int)CardPlace.Hand])
            {
                darkZonesActive(true);
            }
        }

        public void AllyTable_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Space || e.OriginalKey == Windows.System.VirtualKey.GamepadA)
            {
                CardModel c = gridViews[(int)CardPlace.Hand].SelectedItem as CardModel;
                if (actualMana >= c.mana)
                {
                    Cards.Remove(c);
                    TableCards.Add(c);
                    ObservableCollection<CardModel> handCollection = (ObservableCollection<CardModel>)gridViews[(int)CardPlace.Hand].ItemsSource;
                    RaisePropertyChanged(nameof(handCollection));
                    ObservableCollection<CardModel> tableCollection = (ObservableCollection<CardModel>)gridViews[(int)CardPlace.Table].ItemsSource;
                    RaisePropertyChanged(nameof(tableCollection));
                    actualMana -= c.mana;
                    UpdateManaUI();
                }
            }
            else if(e.Key == Windows.System.VirtualKey.Escape || e.OriginalKey == Windows.System.VirtualKey.GamepadB)
            {
                darkZonesActive(false);
                GridViewItem g = gridViews[(int)CardPlace.Hand].ContainerFromIndex(gridViews[(int)CardPlace.Hand].SelectedIndex) as GridViewItem;
                g.Focus(FocusState.Keyboard);
            }

        }

        private void darkZonesActive(bool active)
        {
            Visibility v;
            if(active) v = Visibility.Visible;
            else v = Visibility.Collapsed;  

            foreach (Windows.UI.Xaml.Shapes.Rectangle r in darkZones)
            {
                r.Visibility = v;
            }
            for (int i = (int)CardPlace.Table; i < (int)CardPlace.FinalEnum; ++i)
            {
                for (int j = 0; j < Cards.Count; ++j)
                {
                    var gridViewItem = gridViews[i].ContainerFromIndex(j);
                    if (gridViewItem != null)
                    {
                        GridViewItem g = gridViewItem as GridViewItem;
                        g.IsTabStop = !active;
                    }
                }
            }
            foreach (Button b in buttons)
            {
                b.IsTabStop = !active;
                b.IsEnabled = !active;
            }
            ContentControl cont = gridViews[(int)CardPlace.Table].Parent as ContentControl;
            cont.IsTabStop = active;
        }


        public void myHand_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            ContentControl cont = gridViews[(int)CardPlace.Table].Parent as ContentControl;
            if ((e.Key == Windows.System.VirtualKey.Escape || e.OriginalKey == Windows.System.VirtualKey.GamepadB) && cont.IsTabStop)
            {
                darkZonesActive(false);
            }
        }
    }
}
