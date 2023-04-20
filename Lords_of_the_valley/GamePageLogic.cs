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

namespace Lords_of_the_valley
{
    public class GamePageLogic : ObservableObject
    {
        enum CardPlace { Hand, Table, RivalTable };
        private GamePage page;

        public List<Border> manaList = new List<Border>();
        public List<Border> rivalManaList = new List<Border>();
        public const int maxPosibleMana = 10;

        private int actualMana = 5;
        private int maxMana = 7;

        public string manaText = "";
        public string rivalManaText = "";

        private int rivalActualMana = 7;
        private int rivalMaxMana = 7;

        public int numCards = 2;
        public int numRivalCards = 3;

        public List<CardModel> Cards { get; set; } = new List<CardModel>();
        public List<CardModel> RivalCards { get; set; } = new List<CardModel>();
        public List<CardModel> TableCards { get; set; } = new List<CardModel>();
        public List<CardModel> TableRivalCards { get; set; } = new List<CardModel>();


        public GamePageLogic()
        {
            int id1 = (int)CardPlace.Hand;
            int id2 = (int)CardPlace.Table;
            int id3 = (int)CardPlace.RivalTable;

            for (int i = 0; i < numCards; ++i)
            {
                Cards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id1, i));
            }

            for (int i = 0; i < numRivalCards; ++i)
            {
                RivalCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, i, i));
            }

            for (int i = 0; i < 4; ++i)
            {
                TableCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id2, i));
            }

            for (int i = 0; i < 2; ++i)
            {
                TableRivalCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id3, i));
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

            RaisePropertyChanged(manaText);
            RaisePropertyChanged(rivalManaText);
        }

        public void GridView_ItemClick (object sender, ItemClickEventArgs e)
        {
            CardModel card = e.ClickedItem as CardModel;
            page.ChangeSelectedCard(card);
        }
    }
}
