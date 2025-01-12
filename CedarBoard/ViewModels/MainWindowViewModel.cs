using CedarBoard.Model;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// メインウィンドウ
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// アプリケーションのタイトル
        /// </summary>
        private string _title = "CedarBoard";

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
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public MainWindowViewModel(WorkspaceSelector workspaceSelector)
        {
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                workspaceSelector.SelectorPoco.PathDictionary);
        }

    }
}
