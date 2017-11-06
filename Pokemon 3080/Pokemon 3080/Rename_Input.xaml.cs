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
    /// Interaction logic for Rename_Input.xaml
    /// </summary>
    public partial class Rename_Input : Window
    {
        private string newName;

        public String Name { get { return newName; } }

        public Rename_Input(string OriginalName) // A single WPF window for input, when we rename a pokemon
        {
            InitializeComponent();
            TextBox.Text = OriginalName;
            newName = OriginalName;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            newName = TextBox.Text;
            this.Close();
        }
    }
}
