using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Timers;
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
    /// Interaction logic for Story.xaml
    /// </summary

    public partial class Story : Window
    {
        private List<BitmapImage> ImageList0;
        private List<BitmapImage> ImageList1;
        private List<BitmapImage> ImageList2;

        private int Count;
        private int Current;
        private string PlayerName;

        public Story(string PlayerName) // The story window is used as introduction of the background knowledge
        {
            InitializeComponent();
            this.PlayerName = PlayerName;
            LoadImage();
            Current = 0;
            Count = 0;
        }

        public void LoadImage()
        {
            ImageList0 = new List<BitmapImage>();
            ImageList1 = new List<BitmapImage>();
            ImageList2 = new List<BitmapImage>();

            for (int i = 0; i <= 16; i++) // Quickly play images, to simulate some animation
            {
                string filename = "/Frame0/" + i.ToString() + ".bmp";
                BitmapImage bmImg = new BitmapImage(new Uri(filename, UriKind.Relative));
                ImageList0.Add(bmImg);
            }

            for(int i = 0; i <= 14; i++) // Quickly play images, to simulate some animation
            {
                string filename = "/Frame1/" + i.ToString() + ".bmp";
                BitmapImage bmImg = new BitmapImage(new Uri(filename, UriKind.Relative));
                ImageList1.Add(bmImg);
            }

            for (int i = 0; i <= 62; i++) // Quickly play images, to simulate some animation
            {
                string filename = "/Frame2/" + i.ToString() + ".bmp";
                BitmapImage bmImg = new BitmapImage(new Uri(filename, UriKind.Relative));
                ImageList2.Add(bmImg);
            }
        }

        public void ViewGif() // View different animation in different status
        {
           switch(Current)
            {
                case 0:
                    if (Count == 17)
                        Count = 0;
                    flagImage.Source = ImageList0[Count];
                    Count++;
                    break;
                case 1:
                    if (Count == 14)
                        Count = 0;
                    flagImage.Source = ImageList1[Count];
                    Count++;
                    break;
                case 2:
                    if (Count == 62)
                        Count = 0;
                    flagImage.Source = ImageList2[Count];
                    Count++;
                    break;
                case 3:                    
                    BitmapImage bmImg = new BitmapImage(new Uri("/Image/Map_Prision.png", UriKind.Relative));
                    flagImage.Source = bmImg;
                    break;
            }
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e) // Use storyboard to continuously play the animation
        {
            ViewGif();
            da.BeginAnimation(Image.WidthProperty, da);
        }

        private void button_Click(object sender, RoutedEventArgs e) // Click, show next page of the story, each page contains sentences and animation
        {
            if (Current == 0)
            {
                da.SpeedRatio = 8;
                Current++;
                Count = 0;
                DoubleAnimation_Completed(sender, e);
                textBlock.Text = "Till one day, without omen, evilness came to this world.\n\nThe devil destroyed the land where Alice and Piexelmons used to live in.\n\nThen he sent hunters to trace down all the living Pixelmons.";
            }
            else if (Current == 1)
            {
                da.SpeedRatio = 16;
                Current++;
                Count = 0;
                DoubleAnimation_Completed(sender, e);
                textBlock.Text = "Alice and the other Pixelmons were murdered, but Pikachu escaped.\n\nRan as fast as he could, he left his world.\n\nSadly, in an island on Earth, he was discovered by the tracer.";
            }
            else if( Current == 2)
            {
                Current++;
                Count = 0;
                flagImage.Width = 180;
                flagImage.Height = 180;
                DoubleAnimation_Completed(sender, e);
                textBlock.Margin = new Thickness(34,239,0,-50);
                textBlock.Text = "Pikachu was trapped in an island by the tracer.\n\nNow it is your time to save him!";
            }
            else
            {
                ChoosePokemon newWindow = new ChoosePokemon(PlayerName);
                newWindow.Show();
                this.Close();
            }
        }
    }
}
