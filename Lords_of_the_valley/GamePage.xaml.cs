using System;
using System.Collections.Generic;
using System.ComponentModel;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Lords_of_the_valley
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        
        public GamePage()
        {
            this.InitializeComponent();

            Logic.manaList.Add(mana1);
            Logic.manaList.Add(mana2);
            Logic.manaList.Add(mana3);
            Logic.manaList.Add(mana4);
            Logic.manaList.Add(mana5);
            Logic.manaList.Add(mana6);
            Logic.manaList.Add(mana7);
            Logic.manaList.Add(mana8);
            Logic.manaList.Add(mana9);
            Logic.manaList.Add(mana10);

            Logic.rivalManaList.Add(rivalMana1);
            Logic.rivalManaList.Add(rivalMana2);
            Logic.rivalManaList.Add(rivalMana3);
            Logic.rivalManaList.Add(rivalMana4);
            Logic.rivalManaList.Add(rivalMana5);
            Logic.rivalManaList.Add(rivalMana6);
            Logic.rivalManaList.Add(rivalMana7);
            Logic.rivalManaList.Add(rivalMana8);
            Logic.rivalManaList.Add(rivalMana9);
            Logic.rivalManaList.Add(rivalMana10);

            Logic.UpdateManaUI();

            Logic.setPage(this);
            Logic.setGridViews(myHand, AllyTable, EnemyTable, rivalHand);
            Logic.setDarkZones(DarkLeft, DarkCenter, DarkRight);
            Logic.setButtons(Power, Ready);
        }

        public void ChangeSelectedCard(CardModel card)
        {
            SelectedImage.Source = card.imgSource;
            SelectedDesc.Text = card.description;
            SelectedAttack.Text = card.attack.ToString();
            SelectedArmor.Text = card.armor.ToString();
            SelectedMana.Text = card.mana.ToString();
            SelectedName.Text = card.name;
        }

        public GamePageLogic Logic { get; } = new GamePageLogic();

        private void Options_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsMenu));
        }
      
    }

}
