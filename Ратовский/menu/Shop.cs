using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    class Shop
    {
        private Dictionary<Product, int> products;
        public decimal Profit { get; private set; }

        public Shop()
        {
            products = new Dictionary<Product, int>();
        }

        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        public void CreateProduct(string name, decimal price, int count)
        {
            products.Add(new Product(name, price), count);
        }

        public void Sell(Product product)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] == 0)
                {
                    Console.WriteLine("Нет в наличии!");
                }
                else
                {
                    products[product]--;
                    Profit += product.Price; // Увеличиваем прибыль
                }
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }

        public void Sell(string productName)
        {
            Product toSell = FindByName(productName);
            if (toSell != null)
            {
                this.Sell(toSell);
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
        public List<ProductInfo> GetProducts()
        {
            List<ProductInfo> result = new List<ProductInfo>();
            foreach (var kvp in products)
            {
                result.Add(new ProductInfo
                {
                    Name = kvp.Key.Name,
                    Price = kvp.Key.Price,
                    Count = kvp.Value
                });
            }
            return result;
        }
        // Класс для передачи данных о продукте
        public class ProductInfo
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }
        }
    }
}
