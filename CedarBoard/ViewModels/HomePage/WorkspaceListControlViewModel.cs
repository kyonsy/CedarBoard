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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_homeControlViewModel">親のコントロール(HomeControl)を受け取る</param>
        public WorkspaceListControlViewModel(HomeControlViewModel _homeControlViewModel)
        {
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
               _homeControlViewModel.WorkspaceSelector.SelectorPoco.PathDictionary);
        }
    }
}