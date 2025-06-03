using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя Кота");
                //Создание обьекта Кот
                Cat Kot = new Cat(Console.ReadLine());
                Console.WriteLine("Введите вес Кота");
                //Присваивание коту веса
                Kot.Weight = Convert.ToDouble(Console.ReadLine());
                //Вывод информации о коте
                Kot.Meow();
            }
            catch (Exception)
            {
                Console.WriteLine("Некорректный ввод");
            }
            Console.ReadKey();
        }
    }
}
