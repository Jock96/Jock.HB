namespace Jock.HB.UI.Commands.WelcomeFormCommands
{
    using Jock.HB.UI.ViewModels;
    using Jock.HB.BL.Utilities;

    using System.Windows;

    /// <summary>
    /// Команда входа в систему.
    /// </summary>
    class WelcomeFormEnterCommand : TypedCommand<WelcomeFormVM>
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
            var dataBaseWorker = welcomeFormVM.DataBaseWorker;
            var userExist = false;

            var userName = welcomeFormVM.UserName;
            var userPassword = welcomeFormVM.UserPassword;

            var users = dataBaseWorker.GetUsers();

            foreach (var user in users)
            {
                if (user.Name == userName && user.Password == userPassword)
                {
                    userExist = true;

                    welcomeFormVM.IsNeedEvent = false;
                    welcomeFormVM.IsNeedRunWorkSpace = true;

                    welcomeFormVM.UserMail = user.Mail;
                    welcomeFormVM.Visibility = Visibility.Hidden;
                    
                    break;
                }
            }

            if (!userExist)
                MessageBoxer.Error("Пользователь с такими данными не зарегестрирован!");
        }
    }
}
