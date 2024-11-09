using Prism.Mvvm;

namespace CedarBoard.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Apple pen";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
