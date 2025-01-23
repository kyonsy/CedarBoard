using CedarBoard.Model;
using Prism.Mvvm;
using Prism;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation.Regions;
using CedarBoard.Views;
using System.Windows.Media.Animation;
using System.Threading;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// メインウィンドウ
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "CedarBoard";
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(HomeUserControl));
        }
        /// <summary>
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
