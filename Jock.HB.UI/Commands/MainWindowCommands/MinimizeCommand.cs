namespace Jock.HB.UI.Commands.MainWindowCommands
{
    using System.Windows;

    using Jock.HB.UI.ViewModels;
    using Jock.HB.BL.Utilities;

    /// <summary>
    /// Команда минимизирования окна.
    /// </summary>
    class MinimizeCommand : TypedCommand<MainWindowVM>
    {
        /// <summary>
        /// Флаг возможности выполнения.
        /// </summary>
        /// <param name="mainWindowVM">Вью-модель главного окна.</param>
        /// <returns>Возвращает возможность выполнения.</returns>
        protected override bool CanExecute(MainWindowVM mainWindowVM)
        {
            return true;
        }

        /// <summary>
        /// Выполнение комманды.
        /// </summary>
        /// <param name="mainWindowVM">Вью-модель главного окна.</param>
        protected override void Execute(MainWindowVM mainWindowVM)
        {
            mainWindowVM.WindowState = WindowState.Minimized;
        }
    }
}
