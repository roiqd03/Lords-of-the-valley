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

        private ImageSource _SelectedCardImgSource;
        private string _SelectedCardDescription;
        private int _SelectedCardAttack;
        private int _SelectedCardArmor;
        private int _SelectedCardMana;




        public ImageSource SelectedCardImgSource
        {
            get { return _SelectedCardImgSource; }
            set { Set(ref _SelectedCardImgSource, value, nameof(_SelectedCardImgSource)); }
        }
        public string SelectedCardDescription
        {
            get { return _SelectedCardDescription; }
            set { Set(ref _SelectedCardDescription, value, nameof(_SelectedCardDescription)); }
        }
        public int SelectedCardAttack
        {
            get { return _SelectedCardAttack; }
            set { Set(ref _SelectedCardAttack, value, nameof(_SelectedCardAttack)); }
        }
        public int SelectedCardArmor
        {
            get { return _SelectedCardArmor; }
            set { Set(ref _SelectedCardArmor, value, nameof(_SelectedCardArmor)); }
        }
        public int SelectedCardMana
        {
            get { return _SelectedCardMana; }
            set { Set(ref _SelectedCardMana, value, nameof(_SelectedCardMana)); }
        }

        enum CardPlace { Hand, Table, RivalTable };
        private int _selectedIndexHand;
        private int _selectedIndexTable;
        private int _selectedIndexRivalTable;
        public int selectedIndexHand
        {
            get { return _selectedIndexHand; }
            set { Set(ref _selectedIndexHand, value, nameof(_selectedIndexHand)); }
        }
        public int selectedIndexTable
        {
            get { return _selectedIndexTable; }
            set { Set(ref _selectedIndexTable, value, nameof(_selectedIndexTable)); }
        }
        public int selectedIndexRivalTable
        {
            get { return _selectedIndexRivalTable; }
            set { Set(ref _selectedIndexRivalTable, value, nameof(_selectedIndexRivalTable)); }
        }

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
            SelectedCardImgSource = card.imgSource;
            SelectedCardDescription = card.description;
            SelectedCardAttack = card.attack;
            SelectedCardArmor = card.armor;
            SelectedCardMana = card.mana;
        }


        public void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CardModel card = e.AddedItems[0] as CardModel;
            if (card.place == (int)CardPlace.Hand)
            {
                selectedIndexTable = -1;
                selectedIndexRivalTable = -1;
                selectedIndexHand = card.id;
            }
            else if (card.place == (int)CardPlace.Table)
            {
                selectedIndexHand = -1;
                selectedIndexRivalTable = -1;
                selectedIndexTable = card.id;
            }
            else if (card.place == (int)CardPlace.RivalTable)
            {
                selectedIndexTable = -1;
                selectedIndexHand = -1;
                selectedIndexRivalTable = card.id;
            }

            ChangeSelectedCard(card);
        }
    }
}
