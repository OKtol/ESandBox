﻿using System.Windows;
using ESandBox.Core;

namespace ESandBox.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;

        public MainViewModel()
        {
            ProtectionViewModel = new ProtectionViewModel();
            CurrentView = ProtectionViewModel;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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

        public ProtectionViewModel ProtectionViewModel { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutDownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }

        #endregion
    }
}
