using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model.Services
{
    /// <summary>
    /// Сервис для сохранения и загрузки данных контакта.
    /// </summary>
    public class ContactSerializer
    {
        /// <summary>
        /// Путь к файлу сохранения.
        /// </summary>
        private static string _path;

        /// <summary>
        /// Возвращает или задает путь к файлу, в котором хранятся данные.
        /// </summary>
        public static string Path
        {
            get => _path;
            set => _path = value;
        }

        /// <summary>
        /// Статический конструктор для инициализации пути по умолчанию.
        /// </summary>
        static ContactSerializer()
        {
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _path = System.IO.Path.Combine(myDocuments, "Contacts", "contacts.json");
        }

        /// <summary>
        /// Сохраняет объект контакта в файл.
        /// </summary>
        /// <param name="contact">Экземпляр контакта для сохранения.</param>
        public static void Save(ObservableCollection<Contact> contacts)
        {
            string directory = System.IO.Path.GetDirectoryName(_path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(_path, json);
        }

        /// <summary>
        /// Загружает объект контакта из файла.
        /// </summary>
        /// <returns>Экземпляр контакта. Если файла нет, возвращает новый пустой контакт.</returns>
        public static ObservableCollection<Contact> Load()
        {
            if (!File.Exists(_path))
            {
                return new ObservableCollection<Contact>();
            }

            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<ObservableCollection<Contact>>(json);
        }
    }
}
