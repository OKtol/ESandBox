using ESandBox.MVVM.Model.Engine;
using ESandBox.MVVM.View;
using ESandBox.MVVM.ViewModel;
using System;
using System.Windows;

namespace ESandBox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();

            var window = new MainWindowView();
            var viewModel = new MainWindowViewModel();
            window.DataContext = viewModel;
            var controller = new Controller(viewModel.Screen);

            app.Run(window);
        }
    }
}
