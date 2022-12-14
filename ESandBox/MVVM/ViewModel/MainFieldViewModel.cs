using ESandBox.Core;
using ESandBox.MVVM.Model;
using System.Windows.Media;

namespace ESandBox.MVVM.ViewModel
{
    class MainFieldViewModel : ObservableObject
    {
        private DrawingImage _frame;

        public MainFieldViewModel()
        {
            Rendering.frame = _frame;
        }

        public DrawingImage Frame
        {
            get { return _frame; }
            set
            {
                _frame= value;
                OnPropertyChanged();
            }
        }
    }
}
