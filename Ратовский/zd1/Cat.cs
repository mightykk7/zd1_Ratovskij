using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    class Cat
    {
        private string name;
        private double weight;
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"{value} Вес кота не может быть отрицательным!!!");
                }
                else if (value == 0)
                {
                    Console.WriteLine($"{value} Вес кота не может быть нулевым!!!");
                }
                else
                    weight = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }
                if (OnlyLetters)
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        public Cat(string CatName, double Catweight)
        {
            Name = CatName;
            Weight = Catweight;
        }
        public void Meow()
        {
            if (Weight > 0)
            {
                Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
                Console.WriteLine($"{weight}: Вес кота!!!!");
            }
        }
    }
}
