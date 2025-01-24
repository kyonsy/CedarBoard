using CedarBoard.Model;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ワークスペースの画面
    /// </summary>
    public class WorkspaceUserControlViewModel : BindableBase,INavigationAware
    {
        // フィールド
        private IRegionManager _regionManager;
        private Workspace _workspace;
        private ObservableCollection<TreeItem> _workspaceItems;
        private ObservableCollection<TabViewModel> _tabs;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WorkspaceUserControlViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            BackNewEntry = new DelegateCommand(BackNewEntryExecute);
            BackHome = new DelegateCommand(BackHomeExecute);
            SaveWorkspace = new DelegateCommand(SaveWorkspaceExecute);
            AddProject = new DelegateCommand(AddProjectExecute);
            DeleteProject = new DelegateCommand(DeleteProjectExecute);
            AddNode = new DelegateCommand(AddNodeExecute);
            DeleteNode = new DelegateCommand(DeleteNodeExecute);
            BackEditWork = new DelegateCommand(BackEditWorkExecute);
        }

        // デリゲート
        /// <summary>
        /// 新規作成画面へ移動
        /// </summary>
        public DelegateCommand BackNewEntry { get; }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// ワークスペースを保存する
        /// </summary>
        public DelegateCommand SaveWorkspace { get; }

        /// <summary>
        /// 新しいプロジェクトを作る
        /// </summary>
        public DelegateCommand AddProject { get; }

        /// <summary>
        /// プロジェクトを削除する
        /// </summary>
        public DelegateCommand DeleteProject { get; }

        /// <summary>
        /// ノードを追加する
        /// </summary>
        public DelegateCommand AddNode { get; }

        /// <summary>
        /// ノードを削除する
        /// </summary>
        public DelegateCommand DeleteNode { get; }

        /// <summary>
        /// ワークスペース編集画面へ戻る
        /// </summary>
        public DelegateCommand BackEditWork { get; }


        //プロパティ
        /// <summary>
        /// タブのリスト
        /// </summary>
        public ObservableCollection<TabViewModel> Tabs
        {
            get => _tabs;
            set => SetProperty(ref _tabs, value);
        }

        private TabViewModel _selectedTab;

        /// <summary>
        /// 選択されたタブ
        /// </summary>
        public TabViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        /// <summary>
        /// データモデルにワークスペースを入れる
        /// </summary>
        public ObservableCollection<TreeItem> WorkspaceItems { get { return _workspaceItems; } set { SetProperty(ref _workspaceItems, value); } }

        /// <summary>
        /// 新規作成
        /// </summary>
        private void BackNewEntryExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NewEntryUserControl));
        }

        /// <summary>
        /// 開く
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void SaveWorkspaceExecute()
        {
        }

        /// <summary>
        /// 新規プロジェクト
        /// </summary>
        private void AddProjectExecute() { }

        /// <summary>
        /// プロジェクトを削除
        /// </summary>
        private void DeleteProjectExecute() { }

        /// <summary>
        /// ノードを追加
        /// </summary>
        private void AddNodeExecute() { }

        /// <summary>
        /// ノードを削除
        /// </summary>
        private void DeleteNodeExecute() { }

        /// <summary>
        /// ワークスペースの設定
        /// </summary>
        private void BackEditWorkExecute() {
            _regionManager.RequestNavigate("ContentRegion", nameof(EditWorkUserControl));
        }

        /// <summary>
        /// 他の画面から他の画面に移動するときの操作
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _workspace = navigationContext.Parameters.GetValue<Workspace>("Workspace");
            MakeTreeItemList();
            MakeTabsList();    
        }

        /// <summary>
        /// アイテムツリーのリストを作る
        /// </summary>
        private void MakeTreeItemList()
        {
            WorkspaceItems = new ObservableCollection<TreeItem>();
            TreeItem items = new(_workspace.WorkspacePoco.Setting.Name);
            foreach (var projectKetValuePair in _workspace.WorkspacePoco.ProjectDictionary)
            {
                TreeItem ProjectTree = new(projectKetValuePair.Key);
                foreach (var node in projectKetValuePair.Value.NodeDictionary)
                {
                    ProjectTree.Children.Add(new TreeItem(node.Key));
                }
                items.Children.Add(ProjectTree);
            }
            WorkspaceItems.Add(items);
        }

        /// <summary>
        /// タブのリストを作る
        /// </summary>
        private void MakeTabsList()
        {
            Tabs = new ObservableCollection<TabViewModel>();
            foreach (var projectKetValuePair in _workspace.WorkspacePoco.ProjectDictionary)
            {
                Tabs.Add(CreateTabViewModel(projectKetValuePair));
            }
            SelectedTab = Tabs[0];
        }

        /// <summary>
        /// タブViewModelを作る
        /// </summary>
        private TabViewModel CreateTabViewModel(KeyValuePair<string,Project> projectKetValuePair)
        {
            TabViewModel tabViewModel = new TabViewModel();
            tabViewModel.Header = projectKetValuePair.Key;
            tabViewModel.ProjectViewModel = new(projectKetValuePair.Value);
            return tabViewModel;
        }

        /// <summary>
        /// 遷移する際はインスタンスを使いまわさない
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        /// <returns>インスタンスを使いまわすかどうか</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// この画面から他の画面に移動するときの操作
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
