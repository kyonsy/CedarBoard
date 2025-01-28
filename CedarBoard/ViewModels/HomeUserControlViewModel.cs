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
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

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
            OpenFile = new DelegateCommand(OpenFileExecute);
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


        /// <summary>
        /// ファイルを開く
        /// </summary>
        public DelegateCommand OpenFile { get; }

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
                var result = System.Windows.MessageBox.Show("本当に削除してもよろしいでしょうか？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == System.Windows.MessageBoxResult.OK)
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
            try
            {
                if (SelectedKeyValuePair is null) return;
                Workspace workspace = _workspaceSelector.GetWorkSpace(SelectedKeyValuePair.Value.Key);
                var p = new NavigationParameters
                {
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl), p);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("無効なワークスペースです。ワークスペースの場所を変えた場合、「開く」からもう一度登録してください\nエラー："+ex.ToString()
                    , "無効なワークスペース", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
          
        }

        /// <summary>
        /// 他の画面から遷移してきたとき
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// インスタンスを保持しない
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// この画面から他の画面へ遷移するとき
        /// </summary>
        /// <param name="navigationContext">ナビゲーション元からのパラメータ</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        
        }

        private void OpenFileExecute()
        {
            try
            {
                string path = "";
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "フォルダを選択してください";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = folderDialog.SelectedPath;
                    }
                };
                if (!FileExistsInDirectory(path, "workspace.json"))
                {
                    throw new Exception("workspace.json is not");
                }
                string worksaceName = Path.GetFileName(path);
                _workspaceSelector.SelectorPoco.PathDictionary.Add(worksaceName, path);
                _workspaceSelector.Save();
                Workspace workspace = _workspaceSelector.GetWorkSpace(worksaceName);
                var p = new NavigationParameters
                {
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl), p);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("無効なワークスペースです。ワークスペースの場所を変えた場合、「開く」からもう一度登録してください\nエラー：" + ex.ToString()
                    , "無効なワークスペース", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool FileExistsInDirectory(string directoryPath, string fileName)
        {
            // パスを結合して完全なファイルパスを生成
            string fullPath = Path.Combine(directoryPath, fileName);

            // ファイルの存在確認
            return File.Exists(fullPath);
        }
    }
}
