namespace Jock.HB.UI.ViewModels
{
    using Jock.HB.UI.Commands.WelcomeFormCommands;
    using Jock.HB.BL.Utilities;

    using System.Windows;
    using System;

    /// <summary>
    /// Вью-модель приветственного контрола.
    /// </summary>
    class WelcomeFormVM : BaseVM
    {
        /// <summary>
        /// Вью-модель приветственного контрола.
        /// </summary>
        public WelcomeFormVM(UserDataBaseWorker dataBaseWorker)
        {
            WelcomeFormEnterCommand = new WelcomeFormEnterCommand();
            WelcomeFormRegistrationCommand = new WelcomeFormRegistrationCommand();

            DataBaseWorker = dataBaseWorker;
        }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        private string _userMail { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        public string UserMail
        {
            get => _userMail;
            set
            {
                _userMail = value;
                OnPropertyChanged();
            }
        }

        public UserDataBaseWorker DataBaseWorker { get; set; }

        #region Команды.

        /// <summary>
        /// Команда входа в систему.
        /// </summary>
        public WelcomeFormEnterCommand WelcomeFormEnterCommand { get; set; }

        /// <summary>
        /// Команда регистрации в системе.
        /// </summary>
        public WelcomeFormRegistrationCommand WelcomeFormRegistrationCommand { get; set; }

        #endregion

        #region Данные пользователя.

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        private string _userName { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        private string _userPassword { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string UserPassword
        {
            get => _userPassword;
            set
            {
                _userPassword = value;
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
        private Visibility _visibility { get; set; }

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

                if(IsNeedEvent)
                    ValueChanged();

                if (IsNeedRunWorkSpace)
                    RunWorkSpace();
            }
        }

        public delegate void EventHandler(object sender, EventArgs args);

        /// <summary>
        /// Событие отображения регистрации.
        /// </summary>
        public event EventHandler ThrowEvent = delegate { };

        /// <summary>
        /// Изменение значения.
        /// </summary>
        private void ValueChanged()
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
