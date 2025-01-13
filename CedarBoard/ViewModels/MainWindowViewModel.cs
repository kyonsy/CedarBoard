using CedarBoard.Model;
using Prism.Mvvm;
using Prism;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation.Regions;
using CedarBoard.Views;

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
        /// タイトルのプロパティ
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager _regionManager;


        /// <summary>
        /// コンストラクタ。最初はホーム画面に遷移する
        /// </summary>
        public MainWindowViewModel(IRegionManager regionManager)
        {
           _regionManager = regionManager;
            _regionManager.RequestNavigate("ContentRegion", nameof(HomePage));
        }
        
    }
}
