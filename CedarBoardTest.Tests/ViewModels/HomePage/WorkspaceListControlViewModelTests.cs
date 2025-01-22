using Microsoft.VisualStudio.TestTools.UnitTesting;
using CedarBoard.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedarBoard.Model.Accessor;
using CedarBoard.Model;
using CedarBoard.Views;

namespace CedarBoardTest.Tests.ViewModels.HomePage
{
    [TestClass()]
    public class WorkspaceListControlViewModelTests
    {
        [TestMethod()]
        public void WorkspaceListControlViewModelTest()
        {
            WorkspaceListControl view = new();
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { 
                SelectorPoco = new() { 
                    PathDictionary = new()
                    {
                        { "apple","200"},
                        {"orange","300"},
                        { "strbery","400"}
                    }
                } 
            };
            HomePageViewModel parent = new() { WorkspaceSelector = sel };
            WorkspaceListControlViewModel viewModel = new(parent);
            view.DataContext = viewModel;
        }

        [TestMethod()]
        public void WorkspaceListControlViewModelTest1()
        {
            Assert.Fail();
        }
    }
}