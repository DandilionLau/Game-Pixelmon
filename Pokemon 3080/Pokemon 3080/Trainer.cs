using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_3080
{
    public class Trainer
    {
        private string Name;

        private int Eggs;
        private int Stardust;

        public int GetEggs
        {
            get { return Eggs; }
            set { Eggs = value; }
        }

        public int GetStardust
        {
            get { return Stardust; }
            set { Stardust = value; }
        }

        public void AddStardust(int num)
        {
            Stardust += num;
        }

        public void AddEggs(int num)
        {
            Eggs += num;
        }

        public Trainer(string Name)
        {
            this.Name = Name;
            Eggs = 15;
            Stardust = 150;
        }

        public string GetName()
        {
            return Name;
        }

    }
}
