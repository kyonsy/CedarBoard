using CedarBoard.Model.Accessor;
using CedarBoard.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    public class HomeControlViewModel : BindableBase,INavigationAware
    {
        public string _test = "test";
        public string Test {
            get { return _test; }
            set { SetProperty(ref _test, value); }
            }


        public HomeControlViewModel()
        {

        }
        // テスト用のモックを引数に入れておく
        public WorkspaceSelector WorkspaceSelector { get; set; }
            = new WorkspaceSelector(new TextFileMock(), new DirectoryMock());


        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
