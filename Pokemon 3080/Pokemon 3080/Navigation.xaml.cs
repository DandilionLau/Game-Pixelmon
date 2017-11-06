using System;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class Navigation : Window
    {
        private BitmapImage bmp0 = new BitmapImage(new Uri("/Image/Ground_Texture.bmp", UriKind.Relative));
        private BitmapImage bmp1 = new BitmapImage(new Uri("/Image/Grass_Texture.bmp", UriKind.Relative));
        private BitmapImage bmp2 = new BitmapImage(new Uri("/Image/River_Texture.bmp", UriKind.Relative));
        private BitmapImage bmp3 = new BitmapImage(new Uri("/Image/Gym.bmp", UriKind.Relative));
        private BitmapImage bmp4 = new BitmapImage(new Uri("/Image/Store.bmp", UriKind.Relative));
        private BitmapImage bmp5 = new BitmapImage(new Uri("/Image/Tree.bmp", UriKind.Relative));
        private BitmapImage bmp6 = new BitmapImage(new Uri("/Image/Grass.bmp", UriKind.Relative));
        private BitmapImage bmp7 = new BitmapImage(new Uri("/Image/Bob_Ground_Texture.bmp", UriKind.Relative));
        private BitmapImage bmp8 = new BitmapImage(new Uri("/Image/Bob_Grass_Texture.bmp", UriKind.Relative));
        private BitmapImage bmp9 = new BitmapImage(new Uri("/Image/Bob_Grass.bmp", UriKind.Relative));
        private BitmapImage bmp10 = new BitmapImage(new Uri("/Image/NPC0.bmp", UriKind.Relative));
        private BitmapImage bmp11 = new BitmapImage(new Uri("/Image/NPC1.bmp", UriKind.Relative));
        private BitmapImage bmp12 = new BitmapImage(new Uri("/Image/NPC2.bmp", UriKind.Relative));
        private BitmapImage bmp13 = new BitmapImage(new Uri("/Image/NPC3.bmp", UriKind.Relative));
        private BitmapImage bmp14 = new BitmapImage(new Uri("/Image/Pikachu.bmp", UriKind.Relative));
        private BitmapImage bmp15 = new BitmapImage(new Uri("/Image/Bob_River.bmp", UriKind.Relative));
        private BitmapImage bmp16 = new BitmapImage(new Uri("/Image/Out_Left.bmp", UriKind.Relative));
        private BitmapImage bmp17 = new BitmapImage(new Uri("/Image/Out_Right.bmp", UriKind.Relative));

        private List<BitmapImage> BitmapImageList; // Store all the images
        private List<BitmapImage> PokemonImageList; // Store the images for the pokemon
        private List<string> PokemonNameList; // Keep all the name of the unevolved pokemon

        private int[,] NumberMatrix = new int[10, 10]; // The number matrix: model of the map
        private List<int[,]> NumberMatrixList; // Store the three matrices of three maps
        private Image[,] ImageMatrix = new Image[10, 10]; // Store image matrix, for all the block image shown in the view
        private List<Image[,]> ImageMatrixList; // Store the images shown in all three maps

        private int StoryMode; // Story Mode: to control the progress of our storyline
        private int MessageBlockLines; // Count the lines in the MessageBox, in order to do regular clear to show more information
        private int ImageSize; // The length and heigh of the image
        private int CurrentMap; // Decide which map we are now, decide whether to change to the next map
        private bool Initailized = false; // Initialization parameter, to prevent unexpected error
        private bool CanSwim; // Whether our character can siwm
        private int X; // The location of our charactor in X axis
        private int Y; // The location of our charactor in Y axis

        private Trainer Master; // The Trainer object, for our player
        private List<Pokemon> Pokemons; // A list of pokemons, to store the pokemons our player owns

        public Navigation(string PlayerName, string FirstPokemonName) // Custom Constructor, the name of the player and the name of the first Pokemon is passed as parameter
        {
            Master = new Trainer(PlayerName);
            PokemonNameList = new List<string>();
            Pokemons = new List<Pokemon>();
            Pokemon FirstPokemon = new Pokemon(FirstPokemonName);
            Pokemons.Add(FirstPokemon); // Add the first Pokemon
            InitializeComponent();
            RefreshPlayerInfo();
            InitailizeListBox();
            Startup();
        }

        public void Startup() // General Initialization
        {
            BitmapImageList = new List<BitmapImage>();
            PokemonImageList = new List<BitmapImage>();
            NumberMatrixList = new List<int[,]>(3);
            ImageMatrixList = new List<Image[,]>(3);
            StoreBitmap();

            LoadPokemonImage();
            LoadPokemonName();

            CanSwim = true;
            CurrentMap = 1;
            MessageBlockLines = 0;
            ImageSize = 40;
            InitailizeNumberMatirx();
            InitailizeMap();

            StoryMode = 0;
            X = 5;
            Y = 5;

            DrawCharacter(5, 5);
            Initailized = true;
        }

        public void LoadPokemonImage() // Loading All Bitmap for pokemons
        {
            for (int i = 0; i <= 13; i++)
            {
                string filename = "/PokemonImage/" + i.ToString() + ".bmp";
                BitmapImage bmImg = new BitmapImage(new Uri(filename, UriKind.Relative));
                PokemonImageList.Add(bmImg);
            }
        }

        public void RefreshPlayerInfo() // Function to refresh the player info
        {
            PlayerNameTextBlock.Text = "PlayerName: " + Master.GetName();
            PlayerInfoTextBlock.Text = "Stardust: " + Master.GetStardust.ToString() + "\nEggs: " + Master.GetEggs.ToString() + "\nPixelmons: " + Pokemons.Count().ToString();
        }

        public void InitailizeListBox() // Initialize the ListBox for choosing pokemon from Pokemons
        {
            ListBox.ItemsSource = Pokemons;
            ListBox.DisplayMemberPath = "Name";
        }

        public void StoreBitmap() // Loading the general bitmap
        {
            BitmapImageList.Add(bmp0);
            BitmapImageList.Add(bmp1);
            BitmapImageList.Add(bmp2);
            BitmapImageList.Add(bmp3);
            BitmapImageList.Add(bmp4);
            BitmapImageList.Add(bmp5);
            BitmapImageList.Add(bmp6);
            BitmapImageList.Add(bmp7);
            BitmapImageList.Add(bmp8);
            BitmapImageList.Add(bmp9);
            BitmapImageList.Add(bmp10);
            BitmapImageList.Add(bmp11);
            BitmapImageList.Add(bmp12);
            BitmapImageList.Add(bmp13);
            BitmapImageList.Add(bmp14);
            BitmapImageList.Add(bmp15);
            BitmapImageList.Add(bmp16);
            BitmapImageList.Add(bmp17);
        }

        public void LoadPokemonName() // Loading all possible pokemon names
        {
            PokemonNameList.Add("Bulbasaur");
            PokemonNameList.Add("Charmander");
            PokemonNameList.Add("Squirtle");
            PokemonNameList.Add("Psyduck");
            PokemonNameList.Add("Caterpie");
            PokemonNameList.Add("Ivysaur");
            PokemonNameList.Add("Charmeleon");
            PokemonNameList.Add("Wartortle");
            PokemonNameList.Add("Goldduck");
            PokemonNameList.Add("Metapod");
            PokemonNameList.Add("Venusaur");
            PokemonNameList.Add("Charizard");
            PokemonNameList.Add("Blastoise");
            PokemonNameList.Add("Butterfree");
        }

        public void InitailizeNumberMatirx() // Intialization of our number matrix, which is the model of the navigation system
        {
            int[] row0 = { 1, 3, 6, 6, 0, 0, 5, 0, 0, 1 };
            int[] row1 = { 1, 0, 6, 6, 1, 1, 5, 4, 0, 1 };
            int[] row2 = { 1, 0, 0, 6, 5, 1, 2, 2, 0, 1 };
            int[] row3 = { 6, 6, 6, 5, 6, 0, 2, 5, 1, 1 };
            int[] row4 = { 5, 6, 6, 6, 0, 0, 1, 6, 1, 1 };
            int[] row5 = { 0, 0, 0, 6, 0, 1, 0, 6, 6, 1 };
            int[] row6 = { 1, 0, 6, 6, 0, 5, 5, 1, 6, 6 };
            int[] row7 = { 1, 2, 2, 2, 6, 5, 1, 1, 1, 5 };
            int[] row8 = { 2, 2, 2, 2, 6, 6, 1, 1, 1, 5 };
            int[] row9 = { 5, 1, 1, 1, 6, 6, 6, 6, 6, 5 };

            for (int i = 0; i <= 9; i++)
            {
                NumberMatrix.SetValue(row0[i], 0, i);
                NumberMatrix.SetValue(row1[i], 1, i);
                NumberMatrix.SetValue(row2[i], 2, i);
                NumberMatrix.SetValue(row3[i], 3, i);
                NumberMatrix.SetValue(row4[i], 4, i);
                NumberMatrix.SetValue(row5[i], 5, i);
                NumberMatrix.SetValue(row6[i], 6, i);
                NumberMatrix.SetValue(row7[i], 7, i);
                NumberMatrix.SetValue(row8[i], 8, i);
                NumberMatrix.SetValue(row9[i], 9, i);
            }

            int[,] NumberMatrix0 = new int[10, 10];
            int[,] NumberMatrix1 = new int[10, 10];
            int[,] NumberMatrix2 = new int[10, 10];

            for (int c = 0; c <= 9; c++)
            {
                for (int r = 0; r <= 9; r++)
                {
                    NumberMatrix1.SetValue(NumberMatrix[r, c], r, c);
                    NumberMatrix2.SetValue(2, r, c);
                    if (NumberMatrix[r, c] == 1 || NumberMatrix[r, c] == 2)
                    {
                        NumberMatrix0.SetValue(0, r, c);
                    }
                    else
                        NumberMatrix0.SetValue(NumberMatrix[r, c], r, c);
                }
            }

            NumberMatrix1.SetValue(11, 4, 5);
            NumberMatrix2.SetValue(14, 5, 5);
            NumberMatrix2.SetValue(13, 4, 5);

            NumberMatrixList.Add(NumberMatrix0);
            NumberMatrixList.Add(NumberMatrix1);
            NumberMatrixList.Add(NumberMatrix2);
        }

        public void InitailizeMap() // Draw all the blocks in map, according to different number appearing in the number matrix
        {
            DrawBoundary();
            LoadMap();
            for (int r = 0; r <= 9; r++)
                for (int c = 0; c <= 9; c++)
                    DrawMap(r, c);
        }

        public void DrawBoundary() // Draw the boundary, which is consisted by trees in view
        {
            for (int c = 0; c <= 11; c++)
            {
                Image temp = new Image();
                temp.Source = bmp5;
                temp.Height = ImageSize;
                temp.Width = ImageSize;
                Canvas.SetLeft(temp, c * ImageSize);
                Canvas.SetTop(temp, 0);
                canvas.Children.Add(temp);
                temp = null;
            }

            for (int c = 0; c <= 11; c++)
            {
                Image temp = new Image();
                temp.Source = bmp5;
                temp.Height = ImageSize;
                temp.Width = ImageSize;
                Canvas.SetLeft(temp, c * ImageSize);
                Canvas.SetTop(temp, ImageSize * 11);
                canvas.Children.Add(temp);
                temp = null;
            }

            for (int r = 1; r <= 10; r++)
            {
                if (r != 5 && r != 6)
                {
                    Image temp = new Image();
                    temp.Source = bmp5;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 0);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
                else if (CurrentMap == 1 || CurrentMap == 2)
                {
                    Image temp = new Image();
                    temp.Source = bmp16;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 0);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
                else
                {
                    Image temp = new Image();
                    temp.Source = bmp5;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 0);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
            }

            for (int r = 1; r <= 10; r++)
            {
                if (r != 5 && r != 6)
                {
                    Image temp = new Image();
                    temp.Source = bmp5;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 11 * ImageSize);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
                else if (CurrentMap == 0 || CurrentMap == 1)
                {
                    Image temp = new Image();
                    temp.Source = bmp17;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 11 * ImageSize);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
                else
                {
                    Image temp = new Image();
                    temp.Source = bmp5;
                    temp.Height = ImageSize;
                    temp.Width = ImageSize;
                    Canvas.SetLeft(temp, 11 * ImageSize);
                    Canvas.SetTop(temp, ImageSize * r);
                    canvas.Children.Add(temp);
                    temp = null;
                }
            }
        }

        public void DrawMap(int r, int c) // DarwMap function in detailed location
        {
            Image temp = new Image();
            temp.Source = BitmapImageList.ElementAt(NumberMatrixList.ElementAt(CurrentMap)[r, c]);
            temp.Height = ImageSize;
            temp.Width = ImageSize;
            Canvas.SetLeft(temp, c * ImageSize + ImageSize);
            Canvas.SetTop(temp, r * ImageSize + ImageSize);
            ImageMatrixList.ElementAt(CurrentMap).SetValue(temp, r, c);
            canvas.Children.Add(temp);
            temp = null;
        }

        public void LoadMap() // Load the current map into the ImageMatrixList
        {
            foreach (int[,] NumberMatirx in NumberMatrixList)
            {
                for (int r = 0; r <= 9; r++)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        Image temp = new Image();
                        temp.Source = BitmapImageList.ElementAt(NumberMatrix[r, c]);
                        temp.Height = ImageSize;
                        temp.Width = ImageSize;
                        ImageMatrix.SetValue(temp, r, c);
                        temp = null;
                    }
                }
                ImageMatrixList.Add(ImageMatrix);
            }
        }

        public bool DrawCharacter(int x, int y) // Draw character in detailed location, for player's movement in view
        {
            int state = NumberMatrixList.ElementAt(CurrentMap)[x, y];
            if (state == 0 || state == 1 || state == 6)
            {
                canvas.Children.Remove(ImageMatrixList.ElementAt(CurrentMap)[x, y]);
                switch (state)
                {
                    case 0:
                        Image temp1 = new Image();
                        temp1.Source = BitmapImageList.ElementAt(7);
                        temp1.Height = ImageSize;
                        temp1.Width = ImageSize;
                        Canvas.SetLeft(temp1, y * ImageSize + ImageSize);
                        Canvas.SetTop(temp1, x * ImageSize + ImageSize);
                        ImageMatrixList.ElementAt(CurrentMap).SetValue(temp1, x, y);
                        canvas.Children.Add(temp1);
                        temp1 = null;
                        break;
                    case 1:
                        Image temp2 = new Image();
                        temp2.Source = BitmapImageList.ElementAt(8);
                        temp2.Height = ImageSize;
                        temp2.Width = ImageSize;
                        Canvas.SetLeft(temp2, y * ImageSize + ImageSize);
                        Canvas.SetTop(temp2, x * ImageSize + ImageSize);
                        ImageMatrixList.ElementAt(CurrentMap).SetValue(temp2, x, y);
                        canvas.Children.Add(temp2);
                        temp2 = null;
                        break;
                    case 6:
                        Image temp3 = new Image();
                        temp3.Source = BitmapImageList.ElementAt(9);
                        temp3.Height = ImageSize;
                        temp3.Width = ImageSize;
                        Canvas.SetLeft(temp3, y * ImageSize + ImageSize);
                        Canvas.SetTop(temp3, x * ImageSize + ImageSize);
                        ImageMatrixList.ElementAt(CurrentMap).SetValue(temp3, x, y);
                        canvas.Children.Add(temp3);
                        temp3 = null;
                        break;
                }
                return true;
            }
            else if (state == 2 && CanSwim)
            {
                canvas.Children.Remove(ImageMatrixList.ElementAt(CurrentMap)[x, y]);
                Image temp1 = new Image();
                temp1.Source = BitmapImageList.ElementAt(15);
                temp1.Height = ImageSize;
                temp1.Width = ImageSize;
                Canvas.SetLeft(temp1, y * ImageSize + ImageSize);
                Canvas.SetTop(temp1, x * ImageSize + ImageSize);
                ImageMatrixList.ElementAt(CurrentMap).SetValue(temp1, x, y);
                canvas.Children.Add(temp1);
                temp1 = null;
                return true;
            }
            else
                return false;
        }

        public void ifCapture() // Capture Function, tell whether we will encounter a pokemon at specific location
        {
            Random rnd = new Random();
            if (NumberMatrixList.ElementAt(CurrentMap)[X, Y] == 6)
                if (rnd.Next(0, 4) == 1 && Pokemons.Count <= 10)
                {
                    bool temp = true;
                    Capture newCaptureWindow = new Capture();
                    newCaptureWindow.ShowDialog();
                    foreach (Pokemon x in Pokemons)
                        if (x.Name == newCaptureWindow.NewName)
                            temp = false;
                    if (newCaptureWindow.Result != "No")
                    {
                        if (temp)
                        {
                            Pokemon newPokemon = new Pokemon(newCaptureWindow.NewName);
                            Pokemons.Add(newPokemon);
                            ListBox.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Sorry. You can't keep two pixelmon of the same name.");
                        }
                        Master.AddStardust(30);
                        Master.AddEggs(3);
                        RefreshPlayerInfo();
                    }
                }
        }

        public void IfGymBattle() // Tell whether the player will walk into the gym
        {
            if (CurrentMap == 1)
            {
                if(NumberMatrixList[CurrentMap][X, Y] == 3 || NumberMatrixList[CurrentMap][X, Y] == 4)
                {
                    if (StoryMode == 0)
                    {
                        Dialogue newDialogue = new Dialogue(1);
                        newDialogue.ShowDialog();
                        
                    }
                    Pokemon temp = Pokemons[0];
                    foreach (Pokemon x in Pokemons)
                    {
                        if (x.GetCP() > temp.GetCP())
                        {
                            temp = x;
                        }
                    }
                    string store = "";
                    foreach (string x in temp.GetSkill())
                    {
                        store += x + "+";
                    }
                    string substring = store.Substring(0, store.Count() - 1);
                    AddInfo("\nEntering Gym...");
                    MessageBox.Show("Ready to enter the battle field?\nThe system will automatically choose your strongest pixelmon.");
                    GymBattle newBattle = new GymBattle("Wartortle", 150, 40, 10, 32, "Tackle+Hydro Pump", temp.GetName(), temp.Name, temp.GetHP(), temp.GetCP(), temp.GetLevel(), temp.GetAttack(), substring);
                    newBattle.ShowDialog();
                    AddInfo("\nLeaving Gym: ");
                    if (newBattle.Result == "Yes")
                    {
                        if (StoryMode == 0)
                            StoryMode = 1;
                        Master.AddStardust(100);
                        Master.AddEggs(20);
                        RefreshPlayerInfo();
                        MessageBox.Show("Battle Prize: 300 stardust and 50 eggs has been added to your pocket.");
                        AddInfo("300 stardust and 50 eggs has been added to your pocket.");
                    }
                }
            }
            else if (CurrentMap == 0)
            {
                if (NumberMatrixList[CurrentMap][X, Y] == 3 || NumberMatrixList[CurrentMap][X, Y] == 4)
                {
                    if (StoryMode == 1)
                    {
                        Dialogue newDialogue = new Dialogue(2);
                        newDialogue.ShowDialog();
                    }
                    Pokemon temp = Pokemons[0];
                    foreach (Pokemon x in Pokemons)
                    {
                        if (x.GetCP() > temp.GetCP())
                        {
                            temp = x;
                        }
                    }
                    string store = "";
                    foreach (string x in temp.GetSkill())
                    {
                        store += x + "+";
                    }
                    string substring = store.Substring(0, store.Count() - 1);
                    AddInfo("\nEntering Gym...");
                    MessageBox.Show("Ready to enter the battle field?\nThe system will automatically choose your strongest pixelmon.");
                    GymBattle newBattle = new GymBattle("Butterfree", 350, 75, 18, 55, "Tackle+Sting+Wind Shell", temp.GetName(), temp.Name, temp.GetHP(), temp.GetCP(), temp.GetLevel(), temp.GetAttack(), substring);
                    newBattle.ShowDialog();
                    AddInfo("\nLeaving Gym: ");
                    if (newBattle.Result == "Yes")
                    {
                        if (StoryMode == 1)
                            StoryMode = 2;
                        Master.AddStardust(200);
                        Master.AddEggs(40);
                        RefreshPlayerInfo();
                        MessageBox.Show("Battle Prize: 300 stardust and 50 eggs has been added to your pocket.");
                        AddInfo("300 stardust and 50 eggs has been added to your pocket.");
                    }
                    if (StoryMode == 2)
                    {
                        Dialogue newDialogue0 = new Dialogue(3);
                        newDialogue0.ShowDialog();
                        StoryMode = 3;
                    }
                }
            }
            else
            {
                if (NumberMatrixList[CurrentMap][X, Y] == 13 || NumberMatrixList[CurrentMap][X, Y] == 14)
                {
                    if (StoryMode == 3)
                    {
                        Dialogue newDialogue = new Dialogue(4);
                        newDialogue.ShowDialog();
                       
                        Pokemon temp = Pokemons[0];
                        foreach (Pokemon x in Pokemons)
                        {
                            if (x.GetCP() > temp.GetCP())
                            {
                                temp = x;
                            }
                        }
                        string store = "";
                        foreach (string x in temp.GetSkill())
                        {
                            store += x + "+";
                        }

                        string substring = store.Substring(0, store.Count() - 1);
                        AddInfo("\nEntering Battle...");
                        MessageBox.Show("Ready to enter the battle field?\nThe system will automatically choose your strongest pixelmon.");
                        GymBattle newBattle = new GymBattle("Venusaur", 1000, 220, 35, 200, "Tackle+Leech Seed+Seed Bomb", temp.GetName(), temp.Name, temp.GetHP(), temp.GetCP(), temp.GetLevel(), temp.GetAttack(), substring);
                        newBattle.ShowDialog();
                        AddInfo("\nLeaving Battle: ");
                        if (newBattle.Result == "Yes")
                        {
                            StoryMode = 4;
                            Master.AddStardust(300);
                            Master.AddEggs(50);
                            RefreshPlayerInfo();
                            MessageBox.Show("Battle Prize: 300 stardust and 50 eggs has been added to your pocket.");
                            AddInfo("300 stardust and 50 eggs has been added to your pocket.");
                        }
                        if (StoryMode == 4)
                        {
                            Dialogue newDialogue0 = new Dialogue(5);
                            newDialogue0.ShowDialog();
                            StoryMode = 5;
                        }
                    }
                }
            }
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (Initailized)
            {
                if (X != 0)
                {
                    X = X - 1;
                    IfGymBattle();
                    if (DrawCharacter(X, Y))
                    {
                        DrawMap(X + 1, Y);
                    }
                    else
                        X = X + 1;
                }
                ifCapture();
            }
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            if (Initailized)
            {
                if (Y != 0)
                {
                    Y = Y - 1;
                    IfGymBattle();
                    if (DrawCharacter(X, Y))
                    {
                        DrawMap(X, Y + 1);
                    }
                    else
                        Y = Y + 1;
                }
                else if (CurrentMap != 0 && (X == 4 || X == 5))
                {
                    CurrentMap -= 1;
                    Y = 9;
                    for (int r = 0; r <= 9; r++)
                        for (int c = 0; c <= 9; c++)
                            DrawMap(r, c);
                    DrawCharacter(X, Y);
                }
                ifCapture();
            }
        }

        private void DOWN_Click(object sender, RoutedEventArgs e)
        {
            if (Initailized)
            {
                if (X != 9)
                {
                    X = X + 1;
                    IfGymBattle();
                    if (DrawCharacter(X, Y))
                    {
                        DrawMap(X - 1, Y);
                    }
                    else
                        X = X - 1;
                }
                ifCapture();
            }
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            if (Initailized)
            {
                if (Y != 9)
                {
                    Y = Y + 1;
                    IfGymBattle();
                    if (DrawCharacter(X, Y))
                    {
                        DrawMap(X, Y - 1);
                    }
                    else
                        Y = Y - 1;
                }
                else if (CurrentMap != 2 && (X == 4 || X == 5))
                {
                    CurrentMap += 1;
                    Y = 0;
                    for (int r = 0; r <= 9; r++)
                        for (int c = 0; c <= 9; c++)
                            DrawMap(r, c);
                    DrawCharacter(X, Y);
                }
                ifCapture();
            }
        }

        private void Pokemon_3080_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S )
                DOWN_Click(sender, e);
            if (e.Key == Key.W )
                Up_Click(sender, e);
            if (e.Key == Key.A )
                Left_Click(sender, e);
            if (e.Key == Key.D )
                Right_Click(sender, e);

        }

        public void DisplayPokemon(Pokemon X) // Display Pokemon in the main window
        {
            if (X == null)
            {
                canvas0.Children.Clear();
                HPTextBlock.Text = "";
                CPTextBlock.Text = "";
                LevelTextBlock.Text = "";
                SkillTextBlock.Text = "";
                ListBox.Items.Refresh();
            }
            else
            {
                if (canvas0.Children.Count != 0)
                    canvas0.Children.Clear();
                int countIndex = 0;
                Image newPokemonImage = new Image();
                foreach (string PokemonName in PokemonNameList)
                {
                    if (PokemonName == X.GetName())
                        break;
                    countIndex++;
                }
                newPokemonImage.Source = PokemonImageList[countIndex];
                newPokemonImage.Width = 120;
                newPokemonImage.Height = 120;
                Canvas.SetTop(newPokemonImage, 0);
                Canvas.SetLeft(newPokemonImage, 0);
                canvas0.Children.Add(newPokemonImage);
                HPTextBlock.Text = "HP: " + X.GetHP().ToString();
                CPTextBlock.Text = "CP: " + X.GetCP().ToString();
                LevelTextBlock.Text = "Level: " + X.GetLevel().ToString();
                List<string> temp = X.GetSkill();
                string skill = "Skill: \n";
                foreach (string x in temp)
                    skill = skill + x + " ";
                SkillTextBlock.Text = skill;
                ListBox.Items.Refresh();
                temp = null;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string SelectedPokemonName = ListBox.SelectedItem.ToString();
                foreach (Pokemon X in Pokemons)
                {
                    if (X.Name == SelectedPokemonName)
                    {
                        DisplayPokemon(X);
                    }
                }
            }
            else
            {
                AddInfo("Please select and click a pixelmon.");
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        private void LevelUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string SelectedPokemonName = ListBox.SelectedItem.ToString();
                foreach (Pokemon X in Pokemons)
                {
                    if (X.Name == SelectedPokemonName)
                    {
                        if (Master.GetStardust >= 30)
                        {
                            X.LevelUp();
                            Master.AddStardust(-30);
                            RefreshPlayerInfo();
                            DisplayPokemon(X);
                            AddInfo("\nPower Up! Your " + X.Name + " is LV." + X.GetLevel().ToString() + " now.");
                        }
                        else
                        {
                            AddInfo("\nYou don't have enough stardust for level up.");
                            MessageBox.Show("Sorry. You don't have enough stardust for level up.");
                        }
                    }
                }
            }
            else
            {
                AddInfo("Please select and click a pixelmon.");
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        private void EvolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string SelectedPokemonName = ListBox.SelectedItem.ToString();
                foreach (Pokemon X in Pokemons)
                {
                    if (X.EvolveArg == 1)
                    {
                        if (X.Name == SelectedPokemonName)
                        {
                            if (Master.GetEggs >= 10)
                            {
                                string temp = X.GetName();
                                X.Evolve();
                                Master.AddEggs(-10);
                                RefreshPlayerInfo();
                                DisplayPokemon(X);
                                AddInfo("\nEvolution complete! ");
                                string text = "\nYour " + temp;
                                if (X.Name != X.GetName())
                                    text += " (" + X.Name + ") ";
                                text += " has become " + X.GetName() + ".";
                                AddInfo(text);
                            }
                            else
                            {
                                AddInfo("\nYou don't have enough eggs for evolution.");
                                MessageBox.Show("Sorry. You don't have enough eggs for evolution.");
                            }
                        }
                    }
                    else if (X.EvolveArg == 2)
                    {
                        AddInfo("\nYour pixelmon has already reached its ultimate status.");
                        MessageBox.Show("Sorry. Your pixelmon has already reached its ultimate status.");
                    }
                }
            }
            else
            {
                AddInfo("Please select and click a pixelmon.");
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string SelectedPokemonName = ListBox.SelectedItem.ToString();
                Rename_Input newWindow = new Rename_Input(SelectedPokemonName);
                newWindow.ShowDialog();
                string newName = newWindow.Name;
                foreach (Pokemon X in Pokemons)
                {
                    if (X.Name == SelectedPokemonName)
                    {
                        string temp = X.Name;
                        X.SecondName = newName;
                        ListBox.Items.Refresh();
                        DisplayPokemon(X);
                        AddInfo("\nPixelmon " + temp + " has change its name into " + X.Name);
                    }
                }
            }
            else
            {
                AddInfo("Please select and click a pixelmon.");
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        private void SellButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                string SelectedPokemonName = ListBox.SelectedItem.ToString();
                foreach (Pokemon X in Pokemons)
                {
                    if (X.Name == SelectedPokemonName)
                    {
                        string temp = X.Name;
                        Pokemons.Remove(X);
                        DisplayPokemon(null);
                        Master.AddEggs(10);
                        Master.AddStardust(100);
                        RefreshPlayerInfo();
                        MessageBox.Show("You have sold your pixelmon " + temp + ".\nExtra 100 stardust and 10 eggs have been added to your pocket.");
                        AddInfo("\nYou have sold your pixelmon " + temp);
                        AddInfo("\nExtra 100 stardust and 10 eggs have been added to your pocket.");
                        break;
                    }
                }
            }
            else
            {
                AddInfo("Please select and click a pixelmon.");
                MessageBox.Show("Ops. Please select and click a pixelmon.");
            }
        }

        public void AddInfo(string msg) // Add info in the MessageBlock, clean all the info if it is full
        {
            if (MessageBlockLines == 10)
            {
                MessageBlock.Text = "Gaming Info: ";
                MessageBlockLines = 0;
            }
            MessageBlock.Text += msg;
            MessageBlockLines++;
        }
    }
}
