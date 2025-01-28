// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoardTest.Tests.ViewModels.HomePage
{
    [TestClass()]
    public class WorkspaceListControlViewModelTests
    {
        [TestMethod()]
        public void WorkspaceListControlViewModelTest()
        {
            WorkspaceListControl view = new();
            WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock())
            {
                SelectorPoco = new()
                {
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
