using CedarBoard.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// 今まで作ったワークスペースのリスト
    /// </summary>
    public class WorkspaceListControlViewModel : BindableBase
    {
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

        private KeyValuePair<string, string>? _selectedKeyValuePair;

        /// <summary>
        /// ユーザーが選択している作品
        /// </summary>
        public KeyValuePair<string,string>? SelectedKeyValuePair { get { return _selectedKeyValuePair; } set { SetProperty(ref _selectedKeyValuePair, value); } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="workspaceSelector"></param>
        public WorkspaceListControlViewModel(WorkspaceSelector workspaceSelector)
        {
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
               workspaceSelector.SelectorPoco.PathDictionary);
        }
    }
}