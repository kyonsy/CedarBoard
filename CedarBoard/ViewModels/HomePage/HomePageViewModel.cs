using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    public class HomePageViewModel : BindableBase
    {
        // テスト用のモックを引数に入れておく
        public WorkspaceSelector WorkspaceSelector { get; set; }
            = new WorkspaceSelector(new TextFileMock(),new DirectoryMock());

        public HomePageViewModel()
        {

        }
    }
}
