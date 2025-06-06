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
        //Лист магазина
        private Shop shop = new Shop();
        //Лист плейлиста
        private Playlist playlist = new Playlist();
        public Menu()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            //Создаем колонки в dataGridView1
            dataGridView1.Columns.Add("Column1", "Название товара");
            dataGridView1.Columns.Add("Column2", "Цена товара");
            dataGridView1.Columns.Add("Column3", "Количество товара");
            dataGridView2.Columns.Clear();
            //Создаем колонки в dataGridView2
            dataGridView2.Columns.Add("Column1", "Название");
            dataGridView2.Columns.Add("Column2", "Исполнитель");
            dataGridView2.Columns.Add("Column3", "Файл");
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
        private void UpdatePlaylistGrid()
        {
            dataGridView2.Rows.Clear();

            // Получаем список всех песен через метод GetAllSongs()
            foreach (var song in playlist.GetAllSongs())
            {
                dataGridView2.Rows.Add(song.Title, song.Author, song.Filename);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстовых полей
                string title = textBox4.Text.Trim();
                string author = textBox5.Text.Trim();
                string filename = textBox6.Text.Trim();
                // Проверяем, что все поля заполнены корректно
                if (string.IsNullOrEmpty(filename))
                {
                    MessageBox.Show("Введите название файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                filename += ".mp3";
                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("Введите название песни!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Если автор указан то добавляем с автором если нет то используем перезагрузу без указания автора
                if (!string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(filename))
                {
                    playlist.AddSong(title, author, filename);
                }
                else
                {
                    playlist.AddSong(title, filename);
                }

                // Обновляем DataGridView
                UpdatePlaylistGrid();
                MessageBox.Show("Песня успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем текстовые поля
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем выбранную строку в DataGridView
                if (dataGridView2.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите песню для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedIndex = dataGridView2.SelectedRows[0].Index;
                playlist.RemoveSong(selectedIndex);

                // Обновляем DataGridView
                UpdatePlaylistGrid();
                MessageBox.Show("Песня успешно удалена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Чистим плейлист с помощью метода ClearPlaylist()
                playlist.ClearPlaylist();
                //Обновляем DataGridView
                UpdatePlaylistGrid();
                label5.Text = "Проигрывает: ";
                MessageBox.Show("Плейлист успешно очищен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //Получаем индекс который выбрал пользователь
                int index = Convert.ToInt32(numericUpDown1.Value);
                //Проверяем есть ли такой индекс
                playlist.GoToIndex(index);
                //Включаем песню
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"Проигрывает: {currentSong.Title} - {currentSong.Author}";
                MessageBox.Show($"Текущая песня: {currentSong.Title}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //Предыдущая песня
                playlist.PreviousSong();
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"Проигрывает: {currentSong.Title} - {currentSong.Author}";
                MessageBox.Show($"Текущая песня: {currentSong.Title}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //Переход к началу
                playlist.GoToStart();
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"Проигрывает: {currentSong.Title} - {currentSong.Author}";
                MessageBox.Show($"Текущая песня: {currentSong.Title}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //Следующая песня
                playlist.NextSong();
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"Проигрывает: {currentSong.Title} - {currentSong.Author}";
                MessageBox.Show($"Текущая песня: {currentSong.Title}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //Переход к концу
                playlist.GoToIndex(playlist.GetAllSongs().Count - 1);
                Song currentSong = playlist.CurrentSong();
                label5.Text = $"Проигрывает: {currentSong.Title} - {currentSong.Author}";
                MessageBox.Show($"Текущая песня: {currentSong.Title}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
