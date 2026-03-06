using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Команда для загрузки данных контакта из файла.
    /// </summary>
    internal class LoadCommand : ICommand
    {
        /// <summary>
        /// Событие, уведомляющее об изменении возможности выполнения команды.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Проверяет, может ли команда быть выполнена.
        /// </summary>
        /// <returns>Всегда true.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет логику загрузки контакта.
        /// </summary>
        /// <param name="parameter">Ссылка на MainVM, чтобы обновить в ней контакт.</param>
        public void Execute(object parameter)
        {
            var loadedContact = ContactSerializer.Load();

            if (parameter is MainVM mainVM)
            {
                //mainVM.Contact = loadedContact;
            }
        }
    }
}
