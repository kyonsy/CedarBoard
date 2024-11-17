using CedarBoard.Views.HomePage;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Controls;

namespace CedarBoard.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private readonly IRegionManager _regionManager;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            // UserControlをRegionに追加
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeControl));
        }
    }
}
