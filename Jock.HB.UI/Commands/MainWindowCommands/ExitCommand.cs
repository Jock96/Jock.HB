namespace Jock.HB.UI.Commands.MainWindowCommands
{
    using System;
    using Jock.HB.UI.ViewModels;
    using Jock.HB.BL.Utilities;

    /// <summary>
    /// Команда выхода из приложения
    /// </summary>
    class ExitCommand : TypedCommand<MainWindowVM>
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
            if(MessageBoxer.YesNoQuestion("Внимание", "Вы действительно хотите выйти?"))
                Environment.Exit(0);
        }
    }
}
