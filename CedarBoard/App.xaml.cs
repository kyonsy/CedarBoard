// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using CedarBoard.ViewModels;

namespace CedarBoard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App: PrismApplication
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

            containerRegistry.RegisterForNavigation<EditWorkUserControl>();
            containerRegistry.RegisterForNavigation<NewEntryUserControl>();
            containerRegistry.RegisterForNavigation<HomeUserControl>();
            containerRegistry.RegisterForNavigation<WorkspaceUserControl>();
            containerRegistry.RegisterForNavigation<NodeUserControl>();
            containerRegistry.RegisterDialog<NewNodeUserControl,NewNodeUserControlViewModel>();
            containerRegistry.RegisterDialog<EditNodeUserControl, EditNodeUserControlViewModel>();
            containerRegistry.RegisterDialog<NewProjectUserControl, NewProjectUserControlViewModel>();
            containerRegistry.RegisterDialog<ChangeProjectNameUserControl, ChangeProjectNameUserControlViewModel>();
            containerRegistry.RegisterDialog<DeleteProjectUserControl, DeleteProjectUserControlViewModel>();
            // チE��ト用にシングルトンにはモチE��を登録しておく
            containerRegistry.RegisterSingleton<WorkspaceSelector>(() =>
            {

                WorkspaceSelector sel = new(new TextFileAccessor(), new DirectoryAccessor()) { SelectorPoco = new() { PathDictionary = [] } };
                return sel;
            });
        }
    }
}

