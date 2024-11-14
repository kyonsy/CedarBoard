using CedarBoard.Views.EditPage;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Regions;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Navigation;

namespace CedarBoard.ViewModels
{
    //  各ページが正常に動いているかどうかを確かめるための暫定的な実装
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager _regionManager;

        private readonly IContainerProvider _containerProvider;

        private string _title = "Apple pen";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _containerProvider = containerProvider;
            _regionManager = regionManager;
            
        }

        private DelegateCommand createNewPageButton;
        public ICommand CreateNewPageButton => createNewPageButton ??= new DelegateCommand(PerformCreateNewPageButton);

        private void PerformCreateNewPageButton()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(CreateNewPage));
        }

        private DelegateCommand editorWindowButton;
        public ICommand EditorWindowButton => editorWindowButton ??= new DelegateCommand(PerformEditorWindowButton);

        private void PerformEditorWindowButton()
        {
            var editWindow = _containerProvider.Resolve<EditorWindow>();
            editWindow.Show();
        }

        private DelegateCommand homePageButton;
        public ICommand HomePageButton => homePageButton ??= new DelegateCommand(PerformHomePageButton);

        private void PerformHomePageButton()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomePage));
        }
    }
}
