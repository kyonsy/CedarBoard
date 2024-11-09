using CedarBoard.ViewModels.HomePage;
using CedarBoard.Views;
using CedarBoard.Views.EditPage;
using CedarBoard.Views.HomePage;
using Prism.Ioc;
using System.Windows;

namespace CedarBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<HomePageViewModel>();


            containerRegistry.RegisterForNavigation<WorkspaceListControl> ();
            containerRegistry.RegisterForNavigation<CreateNewButtonControl> ();
            containerRegistry.RegisterForNavigation<CreateNewInputControl>();
            containerRegistry.RegisterForNavigation<ArrowControl> ();
            containerRegistry.RegisterForNavigation<CanvasControl>();
            containerRegistry.RegisterForNavigation<LookNodeWindow> ();
            containerRegistry.RegisterForNavigation<NodeControl> ();
            containerRegistry.RegisterForNavigation<ProjectControl> ();
            containerRegistry.RegisterForNavigation<FileBarControl> ();
            containerRegistry.RegisterForNavigation<SettingBarControl> ();
            containerRegistry.RegisterForNavigation<TaskBarControl> ();
            containerRegistry.RegisterForNavigation<EditorWindow> ();
        }
    }
}
