using CedarBoard.ViewModels.HomePage;
using CedarBoard.Views;
using CedarBoard.Views.EditPage;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using CedarBoard.Views.HomePage;
using CedarBoard.Views.EditPage.Project;
using CedarBoard.Views.EditPage.TaskBar;
using CedarBoard.Model;
using CedarBoard.Model.Accessor;

namespace CedarBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// シェルを作る
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 遷移するコントロールを登録する
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                var viewModelName = viewName
                    .Replace(".Views.", ".ViewModels.")
                    + "ViewModel";
                return Type.GetType(viewModelName);
            });
            containerRegistry.RegisterForNavigation<WorkspaceListControl> ();
            containerRegistry.RegisterForNavigation<CreateNewButtonControl> ();
            containerRegistry.RegisterForNavigation<HomeControl> ();
            containerRegistry.RegisterForNavigation<CreateNewInputControl>();
            containerRegistry.RegisterForNavigation<CreateNewControl>();
            containerRegistry.RegisterForNavigation<ArrowControl> ();
            containerRegistry.RegisterForNavigation<CanvasControl>();
            containerRegistry.RegisterForNavigation<LookNodeWindow> ();
            containerRegistry.RegisterForNavigation<NodeControl> ();
            containerRegistry.RegisterForNavigation<ProjectControl> ();
            containerRegistry.RegisterForNavigation<FileBarControl> ();
            containerRegistry.RegisterForNavigation<SettingBarControl> ();
            containerRegistry.RegisterForNavigation<TaskBarControl> ();
            containerRegistry.RegisterForNavigation<EditorWindow>();
            containerRegistry.RegisterDialog<EditContentWindow, EditContentWindowViewModel>();
            // テスト用にシングルトンにはモックを登録しておく
            containerRegistry.RegisterSingleton<WorkspaceSelector>(() =>
            {
                WorkspaceSelector sel = new(new TextFileMock(), new DirectoryMock()) { SelectorPoco = new() { PathDictionary = [] } };
                sel.Add(new()
                {
                    Author = "kyonsy",
                    Editor = "notepad",
                    Encode = "UTF-8",
                    Format = "default",
                    Language = "ja",
                    Name = "hogehoge",
                    CreatedDate = "2024/10/24",
                    UpdatedDate = "2024/10/24",
                    Message = "始めに作ったやつ"
                }, "C:");
                return sel;
            });
        }
    }
}
