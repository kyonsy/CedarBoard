using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    public class HomePageViewModel : BindableBase,INavigationAware
    {
        // テスト用のモックを引数に入れておく
        public WorkspaceSelector WorkspaceSelector { get; set; }
            = new WorkspaceSelector(new TextFileMock(),new DirectoryMock());

        public HomePageViewModel()
        {

        }

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
