using System.Windows;
using ESandBox.Utility;
using System.Windows.Controls;

namespace ESandBox.MVVM.ViewModel
{
    class MainWindowViewModel : ObservableObject
    {
        private Canvas _screen;

        public MainWindowViewModel()
        {
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            _screen = new Canvas();

            InitializeCommands();
        }

        public Canvas Screen
        {
            get { return _screen; }
            set
            {
                _screen = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public RelayCommand? MoveWindowCommand { get; set; }
        public RelayCommand? ShutDownWindowCommand { get; set; }
        public RelayCommand? MaximizeWindowCommand { get; set; }
        public RelayCommand? MinimizeWindowCommand { get; set; }

        #endregion

        private void InitializeCommands()
        {
            MoveWindowCommand = new RelayCommand(o => { Application.Current.MainWindow.DragMove(); });
            ShutDownWindowCommand = new RelayCommand(o => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(o =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(o => {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });
        }
    }
}
