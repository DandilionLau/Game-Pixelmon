using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_3080
{
    public class Pokemon : List<Int32> // Derived class on List<Int 32>
    {
        private int CP;
        private int HP;
        private int Level;
        private int Attack;
        private int CanEvolve;
        private string pName;
        private string secondName; // The second the is to store the new name of the pokemon after player renaming it
        private List<string> Skill;

        private Random rnd;

        public String Name { get { if (secondName == null) { return pName; } else { return secondName; } } }

        public int EvolveArg { get { return CanEvolve; } } // Tell whethe the pokemon has evolved to its ultimate state

        public Pokemon(string Name)
        {
            Skill = new List<string>();
            CanEvolve = 1;
            secondName = null;
            long tick = DateTime.Now.Ticks;
            rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32)); // Use system time to intialize the random object
            this.pName = Name;
            Initailize();
        }

        public string GetName()
        {
            return pName;
        }

        public void Initailize() // Initialize pokemons, all of which are unevolved
        {
            if (Name != null)
            {
                switch (pName)
                {
                    case "Bulbasaur":
                        Skill.Add("Tackle");
                        Level = 1;
                        CP = rnd.Next() % 90 + 10;
                        Attack = rnd.Next() % 90 + 10;
                        HP = rnd.Next() % 90 + 10;
                        break;
                    case "Charmander":
                        Skill.Add("Scratch");
                        Level = 1;
                        CP = rnd.Next() % 90 + 10;
                        Attack = rnd.Next() % 90 + 10;
                        HP = rnd.Next() % 90 + 10;
                        break;
                    case "Squirtle":
                        Skill.Add("Tackle");
                        Level = 1;
                        CP = rnd.Next() % 90 + 10;
                        Attack = rnd.Next() % 90 + 10;
                        HP = rnd.Next() % 90 + 10;
                        break;
                    case "Psyduck":
                        Skill.Add("Zen Headbutt");
                        Level = 1;
                        CP = rnd.Next() % 90 + 10;
                        Attack = rnd.Next() % 90 + 10;
                        HP = rnd.Next() % 90 + 10;
                        break;
                    case "Caterpie":
                        Skill.Add("Tackle");
                        Level = 1;
                        CP = rnd.Next() % 90 + 10;
                        Attack = rnd.Next() % 90 + 10;
                        HP = rnd.Next() % 90 + 10;
                        break;
                }
            }
        }

        public string SecondName
        {
            set { secondName = value; }
        }

        public void LevelUp() //LevelUp, as the same function as PowerUp
        {
            HP += 8;
            CP += 12;
            Attack += 5;
            Level += 1;
        }

        public void SetCp(int num)
        {
            CP = num;
        }

        public void SetHp(int num)
        {
            HP = num;
        }

        public void SetLevel(int num)
        {
            Level = num;
        }

        public void SetAttack(int num)
        {
            Attack = num;
        }

        public void SetSkill(string store)
        {
            Skill.Clear();
            string [] substrings = store.Split('+');
            foreach (string x in substrings)
                Skill.Add(x);
        }

        public void Evolve() // After Evolve, a new name will be given to pokemons
        {
            switch (pName)
            {
                case "Bulbasaur":
                    pName = "Ivysaur";
                    Skill.Add("Leech Seed");
                    break;
                case "Charmander":
                    pName = "Charmeleon";
                    Skill.Add("Fire Punch");
                    break;
                case "Squirtle":
                    pName = "Wartortle";
                    Skill.Add("Aqua Tail");
                    break;
                case "Psyduck":
                    pName = "Goldduck";
                    Skill.Add("Psych Up");
                    CanEvolve = 2;
                    break;
                case "Caterpie":
                    pName = "Metapod";
                    Skill.Add("Sting");
                    break;
                case "Ivysaur":
                    pName = "Venusaur";
                    Skill.Add("Seed Bomb");
                    CanEvolve = 2;
                    break;
                case "Charmeleon":
                    pName = "Charizard";
                    Skill.Add("Flare Blitz");
                    CanEvolve = 2;
                    break;
                case "Wartortle":
                    pName = "Blastoise";
                    Skill.Add("Hydro Pump");
                    CanEvolve = 2;
                    break;
                case "Metapod":
                    pName = "Butterfree";
                    Skill.Add("Wind Shell");
                    CanEvolve = 2;
                    break;
            }
        }

        public List<string> GetSkill() // Get the skills in form of List<string>
        {
            return Skill;
        }

        public int GetCP()
        {
            return CP;
        }

        public int GetHP()
        {
            return HP;
        }

        public int GetLevel()
        {
            return Level;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public override string ToString() // Override the ToString(), for showing the Pokemon name in the ListBox
        {
            if (secondName == null)
            {
                return pName;
            }
            else
            {
                return secondName;
            }
        }

    }
}
