namespace Jock.HB.UI.Commands.RegistrationCommands
{
    using Jock.HB.UI.ViewModels;
    using Jock.HB.BL.Utilities;
    using System.Windows;

    /// <summary>
    /// Команда подтверждение регистрации.
    /// </summary>
    public class ApplyRegistrationCommand : TypedCommand<WelcomeFormRegistrationVM>
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
            var dataBaseWorker = welcomeFormRegistrationVM.DataBaseWorker;

            var name = welcomeFormRegistrationVM.UserRegistrationName;
            var mail = welcomeFormRegistrationVM.UserRegistrationMail;

            var password = welcomeFormRegistrationVM.UserRegistrationPassword;
            var secondPassword = welcomeFormRegistrationVM.UserRegistrationValidPassword;

            if (password != secondPassword)
            {
                MessageBoxer.Error("Введённый пароль не совпадает с первоначальным!\nПовторите ввод пароля.");

                welcomeFormRegistrationVM.UserRegistrationPassword = null;
                welcomeFormRegistrationVM.UserRegistrationValidPassword = null;
            }
            else
            {
                if (!IsUserExist(dataBaseWorker, name, mail))
                {
                    var isSucces = dataBaseWorker.AddUser(name, mail, password);

                    if (isSucces)
                    {
                        MessageBoxer.Info("Регистрация успешно завершена!");

                        welcomeFormRegistrationVM.IsNeedEvent = false;
                        welcomeFormRegistrationVM.IsNeedRunWorkSpace = true;

                        welcomeFormRegistrationVM.UserMailRegistrationSucces = 
                            welcomeFormRegistrationVM.UserRegistrationMail;

                        welcomeFormRegistrationVM.Visibility = Visibility.Hidden;
                    }
                    if (!isSucces)
                        MessageBoxer.Error("Не удалось зарегестрироваться!");
                }
                else
                    MessageBoxer.Error("Пользователь с такими данными уже зарегестрирован!");
            }
        }

        /// <summary>
        /// Флаг проверки существования идентичного пользователя в БД.
        /// </summary>
        /// <param name="dataBaseWorker">Инструмент работы с БД.</param>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="mail">Почта пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Возвращает флаг существования пользователя.</returns>
        private bool IsUserExist(UserDataBaseWorker dataBaseWorker, string name, string mail)
        {
            var users = dataBaseWorker.GetUsers();

            foreach (var user in users)
            {
                if (user.Name == name && user.Mail == mail)
                    return true;
            }

            return false;
        }
    }
}
