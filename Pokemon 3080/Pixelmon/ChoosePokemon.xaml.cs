using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pokemon_3080
{
    /// <summary>
    /// Interaction logic for ChoosePokemon.xaml
    /// </summary>
    public partial class ChoosePokemon : Window
    {
        private string PokemonName;
        private string PlayerName;

        public ChoosePokemon(string PlayerName)
        {
            this.PlayerName = PlayerName;
            InitializeComponent();
            LoadPokemon();
        }

        public void LoadPokemon() // In total there are three choices of pokemon
        {
            ListBox.Items.Add("Bulbasaur");
            ListBox.Items.Add("Charmander");
            ListBox.Items.Add("Squirtle");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                switch (ListBox.SelectedIndex)
                {
                    case 0:
                        PokemonName = "Bulbasaur";
                        break;
                    case 1:
                        PokemonName = "Charmander";
                        break;
                    case 2:
                        PokemonName = "Squirtle";
                        break;
                }
                Navigation newWindow = new Pokemon_3080.Navigation(PlayerName, PokemonName); // After choosing the first Pokemon, the selected PokemonName will be passed as parameter of the constructor 
                newWindow.Show();
                this.Close();
                Dialogue newDialogue = new Dialogue(0);
                newDialogue.Show();
            }
            else
            {
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        public string GetPokemonName()
        {
            return PokemonName;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }
    }
}
