using CedarBoard.Views.HomePage;
using Prism.Mvvm;
using Prism.Regions;

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
        /// コンポーネントの遷移を司る奴
        /// </summary>
        private readonly IRegionManager _regionManager;

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
        /// <param name="regionManager">コンポーネントの遷移を司る奴</param>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            // UserControlをRegionに追加
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(HomeControl));
        }
    }
}
