namespace Jock.HB.UI.ViewModels
{
    using Jock.HB.UI.Commands.MainWindowCommands;
    using Jock.HB.BL.Utilities;

    using System.Windows;
    using System.Configuration;
    using System.Data.Common;

    /// <summary>
    /// Вью-модель главного окна.
    /// </summary>
    class MainWindowVM : BaseVM
    {
        /// <summary>
        /// Вью-модель главного окна.
        /// </summary>
        public MainWindowVM()
        {
            ExitCommand = new ExitCommand();
            MinimizeCommand = new MinimizeCommand();

            var userConnectionString = ConfigurationManager.ConnectionStrings["UserInfoConnection"].ConnectionString;
            var hotelConnectionString = ConfigurationManager.ConnectionStrings["HotelInfoConnection"].ConnectionString;

            var dataProvider = "System.Data.SqlClient";
            var factory = DbProviderFactories.GetFactory(dataProvider);

            var userDataBaseWorker = new UserDataBaseWorker(userConnectionString, factory);
            var hotelDataBaseWorker = new HotelDataBaseWorker(hotelConnectionString, factory);

            WelcomeFormVM = new WelcomeFormVM(userDataBaseWorker);
            WelcomeFormRegistrationVM = new WelcomeFormRegistrationVM(userDataBaseWorker);

            WelcomeFormVM.ThrowEvent += (sender, args) => { WelcomeControlChange(); };
            WelcomeFormRegistrationVM.ThrowEvent += (sender, args) => { RegistrationCotrolChange(); };

            WorkSpaceVM = new WorkSpaceVM(hotelDataBaseWorker);

            WelcomeFormVM.RunWorkSpaceEvent += (sender, args) => 
            {
                WorkSpaceVM.Visibility = Visibility.Visible;
                WorkSpaceVM.UserMail = WelcomeFormVM.UserMail;
            };

            WelcomeFormRegistrationVM.RunWorkSpaceEvent += (sender, args) => 
            {
                WorkSpaceVM.Visibility = Visibility.Visible;
                WorkSpaceVM.UserMail = WelcomeFormRegistrationVM.UserMailRegistrationSucces;
            };
        }

        #region Вью-модели.

        /// <summary>
        /// Вью-модель рабочего пространства.
        /// </summary>
        public WorkSpaceVM WorkSpaceVM { get; set; }

        /// <summary>
        /// Вью-модель формы регистрации.
        /// </summary>
        public WelcomeFormRegistrationVM WelcomeFormRegistrationVM { get; set; }

        /// <summary>
        /// Вью-модель приветственного контрола.
        /// </summary>
        public WelcomeFormVM WelcomeFormVM { get; set; }

        #endregion

        #region Работа с состоянием окна.

        /// <summary>
        /// Команда выхода.
        /// </summary>
        public ExitCommand ExitCommand { get; set; }

        /// <summary>
        /// Команда минимизирования.
        /// </summary>
        public MinimizeCommand MinimizeCommand { get; set; }

        /// <summary>
        /// Состояние окна.
        /// </summary>
        private WindowState _windowState { get; set; }

        /// <summary>
        /// Состояние окна.
        /// </summary>
        public WindowState WindowState
        {
            get => _windowState;
            set
            {
                _windowState = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Изменение состояния контроллов.

        /// <summary>
        /// Изменение состояния контролла приветственной формы.
        /// </summary>
        private void WelcomeControlChange()
        {
            if(WelcomeFormVM.Visibility == Visibility.Hidden)
                WelcomeFormRegistrationVM.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Изменение состояние контролла регистрационной формы.
        /// </summary>
        private void RegistrationCotrolChange()
        {
            if(WelcomeFormRegistrationVM.Visibility == Visibility.Hidden)
                WelcomeFormVM.Visibility = Visibility.Visible;
        }

        #endregion
    }
}
