namespace Jock.HB.UI
{
    using System.Windows;
    using Jock.HB.UI.ViewModels;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowVM();
        }
    }
}
