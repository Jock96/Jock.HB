namespace Jock.HB.UI.Commands.WelcomeFormCommands
{
    using Jock.HB.UI.ViewModels;

    using System.Windows;

    /// <summary>
    /// Команда регистрации в системе.
    /// </summary>
    class WelcomeFormRegistrationCommand : TypedCommand<WelcomeFormVM>
    {
        /// <summary>
        /// Флаг возможности выполнения.
        /// </summary>
        /// <param name="mainWindowVM">Вью-модель окна входа.</param>
        /// <returns>Возвращает возможность выполнения.</returns>
        protected override bool CanExecute(WelcomeFormVM welcomeFormVM)
        {
            return true;
        }

        /// <summary>
        /// Выполнение комманды.
        /// </summary>
        /// <param name="parameter">Вью-модель окна входа.</param>
        protected override void Execute(WelcomeFormVM welcomeFormVM)
        {
            welcomeFormVM.Visibility = Visibility.Hidden;
        }
    }
}
