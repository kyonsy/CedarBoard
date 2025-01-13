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
    /// 新規作成画面
    /// </summary>
	public class NewEntryUserControlViewModel : BindableBase
	{
        private IRegionManager _regionManager;


        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewEntryUserControlViewModel(IRegionManager regionManager)
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

        private void NewEntryExecute() { 
            
        }
	}
}
