namespace Jock.HB.UI.ViewModels
{
    using Jock.HB.BL.Utilities;
    using Jock.HB.UI.Commands.RegistrationCommands;

    using System;
    using System.Windows;

    /// <summary>
    /// Вью-модель формы регистрации.
    /// </summary>
    public class WelcomeFormRegistrationVM : BaseVM
    {
        /// <summary>
        /// Вью-модель формы регистрации.
        /// </summary>
        public WelcomeFormRegistrationVM(UserDataBaseWorker dataBaseWorker)
        {
            ApplyRegistrationCommand = new ApplyRegistrationCommand();
            CancelRegistrationCommand = new CancelRegistrationCommand();

            DataBaseWorker = dataBaseWorker;
        }

        /// <summary>
        /// Почта пользователя при успешной регистрации.
        /// </summary>
        private string _userMailRegistrationSucces { get; set; }

        /// <summary>
        /// Почта пользователя при успешной регистрации.
        /// </summary>
        public string UserMailRegistrationSucces
        {
            get => _userMailRegistrationSucces;
            set
            {
                _userMailRegistrationSucces = value;
                OnPropertyChanged();
            }
        }

        public UserDataBaseWorker DataBaseWorker { get; set; }

        #region Команды.

        /// <summary>
        /// Команда подтверждение регистрации.
        /// </summary>
        public ApplyRegistrationCommand ApplyRegistrationCommand { get; set; }

        /// <summary>
        /// Команда отмены регистрации.
        /// </summary>
        public CancelRegistrationCommand CancelRegistrationCommand { get; set; }

        #endregion

        #region Данные пользователя.

        /// <summary>
        /// Имя пользователя при регистрации.
        /// </summary>
        private string _userRegistrationName { get; set; }

        /// <summary>
        /// Почта пользователя при регистрации.
        /// </summary>
        private string _userRegistrationMail { get; set; }

        /// <summary>
        /// Пароль пользователя при регистрации.
        /// </summary>
        private string _userRegistrationPassword { get; set; }

        /// <summary>
        /// Повторный пароль пользователя для валидации при регистрации.
        /// </summary>
        private string _userRegistrationValidPassword { get; set; }

        /// <summary>
        /// Пароль пользователя при регистрации.
        /// </summary>
        public string UserRegistrationPassword
        {
            get => _userRegistrationPassword;
            set
            {
                _userRegistrationPassword = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Повторный пароль пользователя для валидации при регистрации.
        /// </summary>
        public string UserRegistrationValidPassword
        {
            get => _userRegistrationValidPassword;
            set
            {
                _userRegistrationValidPassword = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Имя пользователя при регистрации.
        /// </summary>
        public string UserRegistrationName
        {
            get => _userRegistrationName;
            set
            {
                _userRegistrationName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Почта пользователя при регистрации.
        /// </summary>
        public string UserRegistrationMail
        {
            get => _userRegistrationMail;
            set
            {
                _userRegistrationMail = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Событие изменения видимости.

        /// <summary>
        /// Флаг необходимости применять событие.
        /// </summary>
        public bool IsNeedEvent { get; set; } = true;

        /// <summary>
        /// Флаг необходимости запустить рабочее пространство.
        /// </summary>
        public bool IsNeedRunWorkSpace { get; set; } = false;

        /// <summary>
        /// Видимость элемента.
        /// </summary>
        private Visibility _visibility { get; set; } = Visibility.Hidden;

        /// <summary>
        /// Видимость элемента.
        /// </summary>
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();

                if (IsNeedEvent)
                    ValueChanged();

                if (IsNeedRunWorkSpace)
                    RunWorkSpace();
            }
        }

        public delegate void EventHandler(object sender, EventArgs args);

        /// <summary>
        /// Событие отображения окна входа.
        /// </summary>
        public event EventHandler ThrowEvent = delegate { };

        /// <summary>
        /// Изменение значения.
        /// </summary>
        public void ValueChanged()
        {
            if (_visibility == Visibility.Hidden)
                ThrowEvent(this, new EventArgs());
        }

        /// <summary>
        /// Событие отображения рабочего пространства.
        /// </summary>
        public event EventHandler RunWorkSpaceEvent = delegate { };

        /// <summary>
        /// Запуск рабочего пространства.
        /// </summary>
        private void RunWorkSpace()
        {
            if (_visibility == Visibility.Hidden)
                RunWorkSpaceEvent(this, new EventArgs());
        }

        #endregion
    }
}
