using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menu
{
    class Playlist
    {
        private List<Song> list;
        private int currentIndex;

        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }
        //Публичная копия листа
        public List<Song> GetAllSongs()
        {
            return new List<Song>(list); // Возвращаем копию, чтобы внешний код не мог изменить оригинал
        }
        // Текущая запись
        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        // Проверка на название файла есть ли такой файл уже или нет
        private bool IsFilenameUnique(string filename)
        {
            return !list.Any(song => song.Filename == filename);
        }

        // Добавление аудиозаписи с полной информацией
        public void AddSong(string title, string author, string filename)
        {
            if (!IsFilenameUnique(filename))
                throw new IndexOutOfRangeException($"Файл '{filename}' уже существует!");

            list.Add(new Song(title, author, filename));
        }

        // Перегрузка: добавление без указания автора
        public void AddSong(string title, string filename)
        {
            if (!IsFilenameUnique(filename))
                throw new IndexOutOfRangeException($"Файл '{filename}' уже существует!");

            list.Add(new Song(title, "Неизвестно", filename));
        }

        // Переход к следующей песне
        public void NextSong()
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Плейлист пустой!");

            currentIndex = (currentIndex + 1) % list.Count;
        }

        // Переход к предыдущей песне
        public void PreviousSong()
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Плейлист пустой!");

            currentIndex = (currentIndex - 1 + list.Count) % list.Count;
        }

        // Переход по индексу записи
        public void GoToIndex(int index)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Плейлист пустой!");

            if (index < 0 || index >= list.Count)
                throw new IndexOutOfRangeException("Индекс выходит за границы плейлиста!");

            currentIndex = index;
        }

        // Переход к началу списка
        public void GoToStart()
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Плейлист пустой!");

            currentIndex = 0;
        }

        // Удаление композиции
        public void RemoveSong(int index)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Плейлист пустой!");

            if (index < 0 || index >= list.Count)
                throw new IndexOutOfRangeException("Индекс выходит за границы плейлиста!");

            list.RemoveAt(index);

            // Обновляем currentIndex, если он был больше или равен удаленному индексу
            if (currentIndex > index)
                currentIndex--;
            else if (currentIndex == index && list.Count > 0)
                currentIndex = 0; // Устанавливаем на первую песню, если была удалена текущая
        }
        // очищаем плейлист
        public void ClearPlaylist()
        {
            list.Clear();
            currentIndex = 0;
        }
    }
}
