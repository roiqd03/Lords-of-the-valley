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

        public ImageSource SelectedCardImgSource;
        public string SelectedCardDescription;
        public int SelectedCardAttack;
        public int SelectedCardArmor;
        public int SelectedCardMana;
        public int SelectedCardID;

        enum CardPlace { Hand, Table, RivalTable };
        public int selectedIndexHand = -1;
        public int selectedIndexTable = -1;
        public int selectedIndexRivalTable = -1;

        public GamePageLogic()
        {
            int id1 = (int)CardPlace.Hand;
            for (int i = 0; i < numCards; ++i)
            {
                Cards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id1, i));
            }

            ChangeSelectedCard(Cards[0]);

            for (int i = 0; i < numRivalCards; ++i)
            {
                RivalCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, i, i));
            }

            int id2 = (int)CardPlace.Table;
            for (int i = 0; i < 4; ++i)
            {
                TableCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id2, i));
            }
            int id3 = (int)CardPlace.RivalTable;
            for (int i = 0; i < 2; ++i)
            {
                TableRivalCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, id3, i));
            }
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

        void ChangeSelectedCard(CardModel card)
        {
            Set<ImageSource>(ref SelectedCardImgSource, card.imgSource);
            Set<string>(ref SelectedCardDescription, card.description);
            Set<int>(ref SelectedCardAttack, card.attack);
            Set<int>(ref SelectedCardArmor, card.armor);
            Set<int>(ref SelectedCardMana, card.mana);
            Set<int>(ref SelectedCardID, card.id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CardModel card = e.AddedItems[0] as CardModel;
            if (card.place == (int)CardPlace.Hand)
            {
                Set<int>(ref selectedIndexTable, -1);
                Set<int>(ref selectedIndexRivalTable, -1);
                Set<int>(ref selectedIndexHand, card.id);
            }
            else if (card.place == (int)CardPlace.Table)
            {
                Set<int>(ref selectedIndexHand, -1);
                Set<int>(ref selectedIndexRivalTable, -1);
                Set<int>(ref selectedIndexTable, card.id);
            }
            else if (card.place == (int)CardPlace.RivalTable)
            {
                Set<int>(ref selectedIndexTable, -1);
                Set<int>(ref selectedIndexHand, -1);
                Set<int>(ref selectedIndexRivalTable, card.id);
            }

            ChangeSelectedCard(card);
        }
    }
}
