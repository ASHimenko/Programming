using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Команда для сохранения данных контакта в файл.
    /// </summary>
    public class SaveCommand : ICommand
    {
        /// <summary>
        /// Вызывается при изменении условий, влияющих на то, может ли команда выполняться.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Проверяет, может ли команда быть выполнена.
        /// </summary>
        /// <param name="parameter">Параметр команды (объект контакта).</param>
        /// <returns>Всегда true.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполняет логику сохранения контакта.
        /// </summary>
        /// <param name="parameter">Объект <see cref="Contact"/>, который нужно сохранить.</param>
        public void Execute(object parameter)
        {
            if (parameter is Contact contact)
            {
                //ContactSerializer.Save(contact);
            }
        }
    }
}
