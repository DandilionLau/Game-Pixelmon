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
    /// Interaction logic for Dialogue.xaml
    /// </summary>
    public partial class Dialogue : Window
    {
        private int index;
        private int count;

        private List<string> Conversation0; // Use List<string> to store the conversation in different dialogue
        private List<string> Conversation1;
        private List<string> Conversation2;
        private List<string> Conversation3;
        private List<string> Conversation4;
        private List<string> Conversation5;

        private BitmapImage Bob = new BitmapImage(new Uri("/Image/1.jpg", UriKind.Relative)); // Bitmap of NPC
        private BitmapImage Nick = new BitmapImage(new Uri("/Image/Nick.bmp", UriKind.Relative));
        private BitmapImage Clementine = new BitmapImage(new Uri("/Image/Clementine.bmp", UriKind.Relative));
        private BitmapImage Bernard = new BitmapImage(new Uri("/Image/Bernard.bmp", UriKind.Relative));
        private BitmapImage Pikachu = new BitmapImage(new Uri("/Image/Pikachu_Figure.bmp", UriKind.Relative));
        private BitmapImage Tracer = new BitmapImage(new Uri("/Image/Tracer.bmp", UriKind.Relative));

        private List<BitmapImage> FigureList; // List of NPC's bitmap
        private Queue<Image> store;

        int[] size = {7,3,5,5,4,3}; // The number of sentences in each dialogue

        public Dialogue(int index)
        {
            InitializeComponent();
            FigureList = new List<BitmapImage>();
            store = new Queue<Image>();
            this.index = index;
            count = 0;

            LoadConversation();
            LoadImage();

            ShowDialogue();
            ShowFigure();
            count++;
        }

        public void LoadConversation() // The content of each dialogue
        {
            Conversation0 = new List<string>();
            Conversation0.Add("Mum...It hurts...Where am I? Where is Pikachu??\nOh! I nearly forget!! I must save Pikachu from the tracer!!!");
            Conversation0.Add("Calm down please. I am Clementine. I am a store owner nearby.\nPikachu? You mean the yellow ceature trapped in the island?\n");
            Conversation0.Add("The island! I must protect Pikachu out of the devil's reach.\n I think can swim there!");
            Conversation0.Add("Don't be silly! You will drown yourself in the water!\nThe surrounding sea water has been cursed!\nIn a century, no one has reached that island but our prophet.");
            Conversation0.Add("Your what?");
            Conversation0.Add("Our prophet Bernard. The oldest person in our village.\nBut to visit him, you must win the stranger's challenge.\nIt is our custom here, you must defeat his son Nick in the Gym.");
            Conversation0.Add("For pickachu, I can do everything.");
            Conversation1 = new List<string>();
            Conversation1.Add("Stranger there! Stop!\nYou can't walk in my Gym without losing a battle!");
            Conversation1.Add("I mean nothing harmful.\nI just want to see the prophet Bernard.");
            Conversation1.Add("So challenge me.\nIf you win, go to the other Gym in the left boundary of the map, and you shall see my father as you wish.");
            Conversation2 = new List<string>();
            Conversation2.Add("Guard! Stop!\nDon't you know you are entering the holy ground of our prophet?");
            Conversation2.Add("I really need some help.\nI just want to see the prophet Bernard.");
            Conversation2.Add("Are you? without his permission, anyone who is entering the goly ground will be killed in sight.");
            Conversation2.Add("Please, I am a good guy.");
            Conversation2.Add("My sword will tell whether you are kind or not.");
            Conversation3 = new List<string>();
            Conversation3.Add("Stop fighting!\nCome in, child.\nYou seems in a hurry.");
            Conversation3.Add("I must save Pikachu!\nHe was trapped in that mysterious island!");
            Conversation3.Add("For hundreds of years, nearly nobody has made his way to the island.\nIt is...Em...too evil.\nAre you sure you want to do this?");
            Conversation3.Add("Yes...Pikachu is my friend and I can risk my life for him.");
            Conversation3.Add("Child. You have learnt how to overcome the cursed water.\nWish you good luck.");
            Conversation4 = new List<string>();
            Conversation4.Add("Pikachu?...Pikachu??...Pikachu???...Where you are????");
            Conversation4.Add("Pika?!...Pika!...PikaPika!!");
            Conversation4.Add("Hm...human...weak and greedy creature. Pixelmons are not meant for you.");
            Conversation4.Add("Careful! Pikachu!");
            Conversation5 = new List<string>();
            Conversation5.Add("You...De...feat...me...Impressive.....(Last Breath).....");
            Conversation5.Add("Pikachu! Pika...Pika!");
            Conversation5.Add("Now it is time for us to go home.");
        }

        public void LoadImage() // Load the Image of the NPCs
        {
            FigureList.Add(Bob);
            FigureList.Add(Nick);
            FigureList.Add(Clementine);
            FigureList.Add(Bernard);
            FigureList.Add(Pikachu);
            FigureList.Add(Tracer);

        }

        public void ShowDialogue()
        {
            switch (index)
            {
                case 0:
                    TextBlock.Text = Conversation0[count];     
                    break;
                case 1:
                    TextBlock.Text = Conversation1[count];
                    break;
                case 2:
                    TextBlock.Text = Conversation2[count];
                    break;
                case 3:
                    TextBlock.Text = Conversation3[count];
                    break;
                case 4:
                    TextBlock.Text = Conversation4[count];
                    break;
                case 5:
                    TextBlock.Text = Conversation5[count];
                    break;
            } 
        }

        public void DrawFigure( int which, int Left) // Draw image of NPCs
        {
            if( canvas.Children.Count != 0)
                canvas.Children.Remove(store.Dequeue());
            Image temp = new Image();
            temp.Source = FigureList[which];
            temp.Height = 125;
            temp.Width = 125;
            Canvas.SetLeft(temp, Left);
            Canvas.SetTop(temp, 0);
            canvas.Children.Add(temp);
            store.Enqueue(temp);
            temp = null;
        }

        public void ShowFigure() // As the dialogue pushes forward, the location of the two persons (or Pikcachu?) changes.
        {
            switch(index)
            {
                case 0:
                    if (count % 2 == 0)
                        DrawFigure(0, 0);
                    else
                        DrawFigure(2,247);
                    break;
                case 1:
                    if (count % 2 == 0)
                        DrawFigure(1, 0);
                    else
                        DrawFigure(0, 247);
                    break;
                case 2:
                    if (count % 2 == 0)
                        DrawFigure(1, 0);
                    else
                        DrawFigure(0, 247);
                    break;
                case 3:
                    if (count % 2 == 0)
                        DrawFigure(3, 0);
                    else
                        DrawFigure(0, 247);
                    break;
                case 4:
                    if (count == 0)
                        DrawFigure(0, 0);
                    else if (count == 1)
                        DrawFigure(4, 247);
                    else if (count == 2)
                        DrawFigure(5, 0);
                    else
                        DrawFigure(0, 247);
                    break;
                case 5:
                    if (count == 0)
                        DrawFigure(5, 0);
                    else if (count == 1)
                        DrawFigure(4, 247);
                    else if (count == 2)
                        DrawFigure(0, 0);
                    break;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e) // Click the button, move to the next dialogue
        {
            if (count < size[index] - 1)
            {
                ShowDialogue();
                ShowFigure();
                count++;
            }
            else if (count == size[index] - 1)
            {
                ShowDialogue();
                ShowFigure();
                count++;
                button.Content = "Quit";
            }
            else
            {
                this.Close();
            }
        }
    }
}
