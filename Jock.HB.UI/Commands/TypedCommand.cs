namespace Jock.HB.UI.Commands
{
    using System;

    using Jock.HB.BL.Utilities;

    /// <summary>
    /// Базовый класс для команд с типизованным параметром.
    /// </summary>
    /// <typeparam name="T">Тип вью-модели.</typeparam>
    public abstract class TypedCommand<T> : BaseCommand
    {
        /// <summary>
        /// Указывает, доступна ли возможность вызова команды.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        /// <returns> True - доступна. </returns>
        public override bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
                return CanExecute(typedParameter);

            return true;
        }

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        public override void Execute(object parameter)
        {
            try
            {
                if (parameter is T typedParameter)
                    Execute(typedParameter);
            }
            catch (Exception ex)
            {
                MessageBoxer.Error("Ошибка", ex.ToString());
            }
        }

        /// <summary>
        /// Указывает, доступна ли возможность вызова команды с типизированным параметром.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        /// <returns> True - доступна. </returns>
        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        /// <summary>
        /// Выполнение комманды с типизированным параметром.
        /// </summary>
        /// <param name="parameter"> Параметр для команды. </param>
        protected abstract void Execute(T parameter);
    }
}
