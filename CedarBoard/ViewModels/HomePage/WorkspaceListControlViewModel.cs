using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    public class WorkspaceListControlViewModel : BindableBase
    {

        // ObservableCollectionをプロパティとして定義
        public ObservableCollection<KeyValuePair<string, string>> _dictionaryItems;
        public ObservableCollection<KeyValuePair<string, string>> DictionaryItems
        {
            get { return _dictionaryItems; }
            set { SetProperty(ref _dictionaryItems, value); }
        }


        public WorkspaceListControlViewModel(HomePageViewModel _homePageViewModel)
        {
            // テストコード
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                new Dictionary<string, string>
                {
                    { "apple","200"},
                    {"orange","300"},
                    { "strbery","400"}
                });

            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                _homePageViewModel.WorkspaceSelector.SelectorPoco.PathDictionary);



        }
    }
}
