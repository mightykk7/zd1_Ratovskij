using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    class Product
    {
        //Цена продукта
        public decimal Price { get; set; }
        //Имя продукта
        public string Name { get; set; }
        //Конструктор продукта
        public Product(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        //Информация о продукте
        public string GetInfo()
        {
            return $"Наименование: {Name}; Цена: {Price} руб.";
        }

    }
}
