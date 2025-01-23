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
using System.Windows;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ホーム画面
    /// </summary>
	public class HomeUserControlViewModel : BindableBase,INavigationAware
	{
        //フィールド
        private string _title = "CedarBoard";
        WorkspaceSelector _workspaceSelector;
        private IRegionManager _regionManager;

        /// <summary>
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public HomeUserControlViewModel(WorkspaceSelector workspaceSelector, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _workspaceSelector = workspaceSelector;
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                workspaceSelector.SelectorPoco.PathDictionary);
            NewEntry = new DelegateCommand(NewEntryExecute);
            EditWork = new DelegateCommand(EditWorkExecute);
            DeleteWork = new DelegateCommand(DeleteWorkExecute);
            OpenWork = new DelegateCommand(OpenWorkExecute);
        }

        //デリゲート
        /// <summary>
        /// 新規作成画面への遷移
        /// </summary>
        public DelegateCommand NewEntry { get; }

        /// <summary>
        /// 作品を編集する
        /// </summary>
        public DelegateCommand EditWork { get; }

        /// <summary>
        /// 作品を削除する
        /// </summary>
        public DelegateCommand DeleteWork { get; }

        /// <summary>
        /// 作品を開く
        /// </summary>
        public DelegateCommand OpenWork { get; }

        // プロパティ
        /// <summary>
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// 表示されるリスト
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> _dictionaryItems;

        /// <summary>
        /// 表示されるリストのプロパティ
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> DictionaryItems
        {
            get { return _dictionaryItems; }
            set { SetProperty(ref _dictionaryItems, value); }
        }

        /// <summary>
        /// ユーザーが選択している作品
        /// </summary>
        private KeyValuePair<string, string>? _selectedKeyValuePair;

        /// <summary>
        /// ユーザーが選択している作品のプロパティ
        /// </summary>
        public KeyValuePair<string, string>? SelectedKeyValuePair { get { return _selectedKeyValuePair; } set { SetProperty(ref _selectedKeyValuePair, value); } }

        /// <summary>
        /// ユーザーがダブルクリックした作品
        /// </summary>
        private KeyValuePair<string, string> _clickedKeyValuePair;

        /// <summary>
        /// ユーザーがダブルクリックした作品のプロパティ
        /// </summary>
        public KeyValuePair<string, string> ClickedKeyValuePair { get { return _clickedKeyValuePair; } set { SetProperty(ref _clickedKeyValuePair, value); } }

        // メソッド
        /// <summary>
        /// 新規作成画面への遷移を行う
        /// </summary>
        public void NewEntryExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NewEntryUserControl));
        }

        /// <summary>
        /// 作品を編集する
        /// </summary>
        public void EditWorkExecute()
        {
            if(SelectedKeyValuePair is not null)
            {
                Workspace workspace = _workspaceSelector.GetWorkSpace(SelectedKeyValuePair.Value.Key);
                var p = new NavigationParameters
                {
                    { "Setting", workspace.WorkspacePoco.Setting },
                    { "Path", SelectedKeyValuePair.Value.ToString()},
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(EditWorkUserControl),p);
            }
        }

        /// <summary>
        /// 作品を削除する
        /// </summary>
        public void DeleteWorkExecute()
        {
            if (SelectedKeyValuePair is not null)
            {
                var result = MessageBox.Show("本当に削除してもよろしいでしょうか？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    _workspaceSelector.Remove(SelectedKeyValuePair.Value.Key);
                }
                // 画面をリロードする
                _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
            }      
        }

        /// <summary>
        /// ワークスペースを開く
        /// </summary>
        public void OpenWorkExecute()
        {
            Workspace workspace = _workspaceSelector.GetWorkSpace(SelectedKeyValuePair.Value.Key);
            var p = new NavigationParameters
                {
                    {"Workspace",workspace }
                };
            _regionManager.RequestNavigate("ContentRegion",nameof(WorkspaceUserControl),p);
        }

        /// <summary>
        /// 他の画面から遷移してきたとき
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// インスタンスを保持しない
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// この画面から他の画面へ遷移するとき
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        
        }
    }
}
