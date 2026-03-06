using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace View.ViewModel
{
    /// <summary>
    /// Универсальный класс для команд, позволяющий передавать логику через делегаты.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Поле для хранения логики выполнения команды.
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Поле для хранения логики проверки доступности команды.
        /// </summary>
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// Событие, которое уведомляет UI о том, что состояние доступности команды изменилось.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Конструктор команды.
        /// </summary>
        /// <param name="execute">Метод, который будет вызван при нажатии.</param>
        /// <param name="canExecute">Метод, проверяющий, активна ли кнопка.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Проверяет, может ли команда быть выполнена в данный момент.
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        /// <summary>
        /// Запускает логику команды.
        /// </summary>
        public void Execute(object parameter) => _execute(parameter);
    }
}
