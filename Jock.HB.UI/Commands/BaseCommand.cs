namespace Jock.HB.UI.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Базовая команда.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Возможность выполнения.
        /// </summary>
        /// <param name="parameter"> Параметр. </param>
        /// <returns> Успешность операции. </returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Событие выполнения.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Выполнение.
        /// </summary>
        /// <param name="parameter">Объект вью-модели.</param>
        public abstract void Execute(object parameter);
    }
}
