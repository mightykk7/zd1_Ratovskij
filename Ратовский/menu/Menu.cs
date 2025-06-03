using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace menu
{
    public partial class Menu : Form
    {
        private Shop shop = new Shop();
        public Menu()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Column1", "Название товара");
            dataGridView1.Columns.Add("Column2", "Цена товара");
            dataGridView1.Columns.Add("Column3", "Количество товара");
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстовых полей
                string productName = textBox1.Text.Trim();
                decimal productPrice = decimal.Parse(textBox2.Text);
                int productCount = int.Parse(textBox3.Text);
                // Проверяем, что все поля заполнены корректно
                if (string.IsNullOrEmpty(productName) || productPrice <= 0 || productCount <= 0)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Создаем новый продукт и добавляем его в магазин
                Product newProduct = new Product(productName, productPrice);
                shop.CreateProduct(productName, productPrice, productCount);
                // Обновляем DataGridView
                UpdateProductsGrid();
                // Очищаем текстбоксы
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateProductsGrid()
        {
            dataGridView1.Rows.Clear();

            // Получаем список всех товаров через метод GetProducts()
            foreach (var productInfo in shop.GetProducts())
            {
                dataGridView1.Rows.Add(productInfo.Name, productInfo.Price, productInfo.Count);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранную строку в DataGridView
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Пожалуйста, выберите товар для продажи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Получаем имя товара из выбранной строки
                string productName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                // Продаем товар по имени
                shop.Sell(productName);
                // Обновляем DataGridView
                UpdateProductsGrid();
                label4.Text = $"Прибыль: {shop.Profit} руб.";
                MessageBox.Show("Товар успешно продан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
