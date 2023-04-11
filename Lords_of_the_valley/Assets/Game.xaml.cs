﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using System.ComponentModel;
using System.Runtime.CompilerServices;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley.Assets
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        public const int maxPosibleMana = 10;

        private int actualMana = 5;
        private int maxMana = 7;

        public string manaText = "";
        public string rivalManaText = "";

        private int rivalActualMana = 7;
        private int rivalMaxMana = 7;

        public int numCards = 2;
        public int numRivalCards = 3;

        private List<Border> manaList = new List<Border>();
        private List<Border> rivalManaList = new List<Border>();
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
        public List<CardModel> RivalCards { get; set; } = new List<CardModel>();
       
    public Game()
        {
            this.InitializeComponent();

            manaList.Add(mana1);
            manaList.Add(mana2);
            manaList.Add(mana3);
            manaList.Add(mana4);
            manaList.Add(mana5);
            manaList.Add(mana6);
            manaList.Add(mana7);
            manaList.Add(mana8);
            manaList.Add(mana9);
            manaList.Add(mana10);

            rivalManaList.Add(rivalMana1);
            rivalManaList.Add(rivalMana2);
            rivalManaList.Add(rivalMana3);
            rivalManaList.Add(rivalMana4);
            rivalManaList.Add(rivalMana5);
            rivalManaList.Add(rivalMana6);
            rivalManaList.Add(rivalMana7);
            rivalManaList.Add(rivalMana8);
            rivalManaList.Add(rivalMana9);
            rivalManaList.Add(rivalMana10);

            UpdateManaUI();

            for (int i = 0; i < numCards; ++i)
            {
                Cards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, i));
            }

            for (int i = 0; i < numRivalCards; ++i)
            {
                RivalCards.Add(new CardModel("Assets\\DecksImg\\deck1.jpg", "Card Description " + i, 3, 1, 2, i));
            }
        }

        void UpdateManaUI()
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


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(manaText));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(rivalManaText));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }

}