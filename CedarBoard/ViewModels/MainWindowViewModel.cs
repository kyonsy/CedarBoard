// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Views;
using Prism.Mvvm;
using Prism.Navigation.Regions;

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
        /// コンストラクタ。最初�Eホ�Eム画面に遷移する
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


