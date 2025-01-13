using CedarBoard.Model;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ホーム画面
    /// </summary>
	public class HomeUserControlViewModel : BindableBase
	{
        /// <summary>
        /// アプリケーションのタイトル
        /// </summary>
        private string _title = "CedarBoard";

        /// <summary>
        /// 表示されるリスト
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> _dictionaryItems;

        private IRegionManager _regionManager;

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
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public HomeUserControlViewModel(WorkspaceSelector workspaceSelector,IRegionManager regionManager)
        {
            _regionManager = regionManager;
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                workspaceSelector.SelectorPoco.PathDictionary);
            NewEntry = new DelegateCommand(NewEntryExecute);
            EditWork = new DelegateCommand(EditWorkExecute);
            DeleteWork = new DelegateCommand(DeleteWorkExecute);
        }

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
            _regionManager.RequestNavigate("ContentRegion", nameof(EditWorkUserControl));
        }

        /// <summary>
        /// 作品を削除する
        /// </summary>
        public void DeleteWorkExecute()
        {

        }
    }
}
