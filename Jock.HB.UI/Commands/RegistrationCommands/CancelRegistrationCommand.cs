namespace Jock.HB.UI.Commands.RegistrationCommands
{
    using Jock.HB.UI.ViewModels;

    using System.Windows;

    /// <summary>
    /// Команда отмены регистрации.
    /// </summary>
    public class CancelRegistrationCommand : TypedCommand<WelcomeFormRegistrationVM>
    {
        /// <summary>
        /// Флаг возможности выполнения.
        /// </summary>
        /// <param name="mainWindowVM">Вью-модель окна регистрации.</param>
        /// <returns>Возвращает возможность выполнения.</returns>
        protected override bool CanExecute(WelcomeFormRegistrationVM welcomeFormRegistrationVM)
        {
            return true;
        }

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter">Вью-модель окна регистрации.</param>
        protected override void Execute(WelcomeFormRegistrationVM welcomeFormRegistrationVM)
        {
            welcomeFormRegistrationVM.Visibility = Visibility.Hidden;
        }
    }
}
