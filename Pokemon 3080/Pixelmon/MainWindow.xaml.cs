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
using System.Windows.Shapes;

namespace Pokemon_3080
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>

    public partial class Start : Window
    {
        private string PlayerName;

        public Start()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
            {
                PlayerName = textBox.Text;
                Story newWindow = new Pokemon_3080.Story(PlayerName); //After input player's name, the name will be passed as parameters of the custom constructor
                newWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ops. Please enter your name first.");
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
