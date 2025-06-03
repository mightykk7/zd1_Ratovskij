using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    class Cat
    {
        //Имя
        private string name;
        //Вес
        private double weight;
        //Публичный вес
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                //Если значение отрицательное выводим что вес не может быть отрицательным
                if (value < 0)
                {
                    Console.WriteLine($"{value} Вес кота не может быть отрицательным!!!");
                }
                //Если значение нулевое то выводим что вес не может быть нулевым
                else if (value == 0)
                {
                    Console.WriteLine($"{value} Вес кота не может быть нулевым!!!");
                }
                //Если значение подходит присваиваем его коту
                else
                    weight = value;
            }
        }
        //Публичное имя
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                //Проверка на цифры в слове
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }
                //Если цифр нет то присваиваем значение
                if (OnlyLetters)
                {
                    name = value;
                }
                //Если есть то пишем что имя не правильное
                else
                {
                    Console.WriteLine($"{value} - неправильное имя!!!");
                }
            }
        }
        //Конструктор кота
        public Cat(string CatName)
        {
            Name = CatName;
        }
        //Информация о коте
        public void Meow()
        {
            //Если вес не ноль то информация выводится
            if (Weight > 0)
            {
                Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
                Console.WriteLine($"Вес кота = {weight} !!!!");
            }
        }
    }
}
