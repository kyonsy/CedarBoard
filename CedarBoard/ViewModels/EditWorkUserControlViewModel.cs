using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// 作品を編集する
    /// </summary>
	public class EditWorkUserControlViewModel : BindableBase
	{
        private IRegionManager _regionManager;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditWorkUserControlViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            BackHome = new DelegateCommand(BackHomeExecute);
            NewEntry = new DelegateCommand(NewEntryExecute);
        }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// 新規作成
        /// </summary>
        public DelegateCommand NewEntry { get; }

        /// <summary>
        /// ホーム画面へ戻る
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }

        private void NewEntryExecute()
        {

        }
    }
}
