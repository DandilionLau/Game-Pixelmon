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
    /// Interaction logic for GymBattle.xaml
    /// </summary>
    public partial class GymBattle : Window
    {
        private System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private string BattleResult = "No"; // Store the result of the battle
        private int timer = 0;
        private int pPokemonHP; // 'p' means player's, and c means computer's
        private int cPokemonHP;
        Pokemon playerPokemon;
        Pokemon computerPokemon;
        private List<string> PokemonNameList;
        List<string> playerPokemonSkills;
        List<string> computerPokemonSkills;

        public String Result { get { return BattleResult; } }

        public GymBattle(string cPokemonName, int cHP, int cCP, int cLevel, int cAttack, String cSkill, string pPokemonName, string secondName, int pHP, int pCP, int pLevel, int pAttack, String pSkill)
            //The custom constructor recieved all the parameters of the two pokemons, then initailize the pokemon of the player and the pokemon of the computer, respectively
        {
            InitializeComponent();

            PokemonNameList = new List<string>();
            playerPokemonSkills = new List<string>();
            computerPokemonSkills = new List<string>();

            playerPokemon = new Pokemon(pPokemonName);
            playerPokemon.SecondName = secondName; 
            computerPokemon = new Pokemon(cPokemonName);

            InitailizePlayer(pHP,pCP,pLevel,pAttack, pSkill);
            InitailizeComputer(cHP, cCP, cLevel, cAttack, cSkill); 
                
            Timer.Tick += Timer_Tick;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Start();

            LoadSkillButton();
        }

        public void InitailizePlayer(int pHP, int pCP, int pLevel,int pAttack, string pSkill) //Initialize the pokemon of the player
        {
            playerPokemon.SetHp(pHP);
            playerPokemon.SetCp(pCP);
            playerPokemon.SetLevel(pLevel);
            playerPokemon.SetAttack(pAttack);
            playerPokemon.SetSkill(pSkill);
            playerPokemonSkills = playerPokemon.GetSkill();
            pPokemonHP = playerPokemon.GetHP();
            HP1.Text = playerPokemon.GetHP().ToString();
            level1.Text = playerPokemon.GetLevel().ToString();
        }

        public void InitailizeComputer(int cHP, int cCP, int cLevel, int cAttack, string cSkill) // Initialize the pokemon of the computer
        {
            computerPokemon.SetHp(cHP);
            computerPokemon.SetCp(cCP);
            computerPokemon.SetLevel(cLevel);
            computerPokemon.SetAttack(cAttack);
            computerPokemon.SetSkill(cSkill);
            computerPokemonSkills = computerPokemon.GetSkill();
            cPokemonHP = computerPokemon.GetHP();
            HP2.Text = computerPokemon.GetHP().ToString();
            level2.Text = computerPokemon.GetLevel().ToString(); ;
        }


        public void LoadSkillButton() // Load the skill as the content as the skill button
        {
            if (playerPokemonSkills.Count > 0)
                skill1.Content = playerPokemonSkills[0];
            else
                skill1.Visibility = Visibility.Hidden;
            if (playerPokemonSkills.Count > 1)
                skill2.Content = playerPokemonSkills[1];
            else
                skill2.Visibility = Visibility.Hidden;
            if (playerPokemonSkills.Count > 2)
                skill3.Content = playerPokemonSkills[2];
            else
                skill3.Visibility = Visibility.Hidden;
        }

        public void Timer_Tick(object sender, EventArgs e) // A timer for the computer to decide when to attack or use skill
        {
            timer++;
            if (timer % 2 == 1)
            {
                //computer pokemon's turn to attack
                computerPokemon_attack();
            }
            else
            {
                fightingrecord.Text += Environment.NewLine + "Now it's your time to attack!";
                Timer.Tick -= Timer_Tick;
                Timer.Stop();
            }
        }

        private void runaway_Click(object sender, RoutedEventArgs e) // Runaway(same as quit) and the player will lose in that way
        {
            if (timer % 2 == 0)
            {
                MessageBox.Show("You're going to leave this battle...");
                BattleResult = "No";
                this.Close();
            }
        }

        private void skill1_Click(object sender, RoutedEventArgs e) // Using the first skill of our player's pokemon
        {
            if (timer % 2 == 0)
            {
                fightingrecord.Text = "Your Pokemon uses " + playerPokemonSkills[0] + ", hurting your enemy " + playerPokemon.GetCP().ToString() + " HP";
                cPokemonHP = cPokemonHP - playerPokemon.GetCP();
                HP2.Text = cPokemonHP.ToString();
                skill1.Visibility = Visibility.Hidden;
                if (cPokemonHP > 0)
                {
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromSeconds(1);
                    Timer.Start();
                }
                else
                {
                    playerwin();
                }
            }
        }

        private void skill2_Click(object sender, RoutedEventArgs e) // Using the second skill of our player's pokemon
        {
            if (playerPokemonSkills[1] != null && timer % 2 == 0)
            {
                fightingrecord.Text = "Your Pokemon uses " + playerPokemonSkills[1] + ", hurting your enemy " + ((int)(1.2 * playerPokemon.GetCP())).ToString() + " HP";
                cPokemonHP = (int)(cPokemonHP - playerPokemon.GetCP() * 1.2);
                HP2.Text = cPokemonHP.ToString();
                skill2.Visibility = Visibility.Hidden;
                if (cPokemonHP > 0)
                {
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromSeconds(1);
                    Timer.Start();
                }
                else
                {
                    playerwin();
                }
            }
        }

        private void skill3_Click(object sender, RoutedEventArgs e) // Using the third skill of the player's pokemon
        {
            if (playerPokemonSkills[2] != null && timer % 2 == 0)
            {
                fightingrecord.Text = "Your Pokemon uses " + playerPokemonSkills[2] + ", hurting your enemy " + ((int)(1.5 * playerPokemon.GetCP())).ToString() + " HP";
                cPokemonHP = (int)(cPokemonHP - playerPokemon.GetCP() * 1.5);
                HP2.Text = cPokemonHP.ToString();
                skill3.Visibility = Visibility.Hidden;
                if (cPokemonHP > 0)
                {
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromSeconds(1);
                    Timer.Start();
                }
                else
                {
                    playerwin();
                }
            }
        }

        private void normalattack_Click(object sender, RoutedEventArgs e) // Using normal attack
        {
            if (timer % 2 == 0)
            {
                fightingrecord.Text = "Your Pokemon uses Normal Attack, hurting your enemy " + playerPokemon.GetAttack().ToString() + " HP";
                cPokemonHP = cPokemonHP - playerPokemon.GetAttack();
                HP2.Text = cPokemonHP.ToString();
                if (cPokemonHP > 0)
                {
                    Timer.Tick += Timer_Tick;
                    Timer.Interval = TimeSpan.FromSeconds(1);
                    Timer.Start();
                }
                else
                {
                    playerwin();
                }
            }
        }

        private void computerPokemon_attack() // Computer attack pattern, chioces are made according to the occurance of the next random number
        {
            Random rnd = new Random();
            int fightindex = rnd.Next(0, 11);
            if (fightindex < 4)
            {
                fightingrecord.Text = "Your enemy uses Normal Attack, hurting your pokemon " + computerPokemon.GetAttack().ToString() + " HP";
                pPokemonHP = pPokemonHP - computerPokemon.GetAttack();
                HP1.Text = pPokemonHP.ToString();
                if (pPokemonHP < 0)
                {
                    playerloss();
                }
            }
            else if (fightindex < 8 && fightindex > 3 && computerPokemonSkills.Count > 0)
            {
                fightingrecord.Text = "Your enemy uses skill: " + computerPokemonSkills[0] + " hurting your pokemon " + computerPokemon.GetCP().ToString() + " HP";
                pPokemonHP = pPokemonHP - computerPokemon.GetCP();
                HP1.Text = pPokemonHP.ToString();
                if (pPokemonHP < 0)
                {
                    playerloss();
                }
            }
            else if (fightindex < 10 && fightindex > 7 && computerPokemonSkills.Count > 1)
            {
                fightingrecord.Text = "Your enemy uses skill: " + computerPokemonSkills[1] + " hurting your pokemon " + ((int)(1.2 * computerPokemon.GetCP())).ToString() + " HP";
                pPokemonHP = pPokemonHP - (int)(1.2 * computerPokemon.GetCP());
                HP1.Text = pPokemonHP.ToString();
                if (pPokemonHP < 0)
                {
                    playerloss();
                }
            }
            else if (fightindex == 10 && computerPokemonSkills.Count > 2)
            {
                fightingrecord.Text = "Your enemy uses skill: " + computerPokemonSkills[2] + " hurting your pokemon " + ((int)(1.5 * computerPokemon.GetCP())).ToString() + " HP";
                pPokemonHP = pPokemonHP - (int)(1.5 * computerPokemon.GetCP()); ;
                HP1.Text = pPokemonHP.ToString();
                if (pPokemonHP < 0)
                {
                    playerloss();
                }
            }
        }

        private void playerwin() // If win, close window
        {
            MessageBox.Show("Congratulations!You beat your emeny.");
            Timer.Stop();
            BattleResult = "Yes";
            this.Close();
        }

        private void playerloss() // If loss, close window
        {
            MessageBox.Show("Sorry for your loss.Just get stronger and come back later!");
            Timer.Stop();
            BattleResult = "No";
            this.Close();
        }
    }
}
