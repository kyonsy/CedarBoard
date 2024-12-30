﻿using CedarBoard.Model;
using CedarBoard.Model.Accessor;
using Prism.Mvvm;
using Prism.Regions;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// ホーム画面
    /// </summary>
    public class HomeControlViewModel : BindableBase,INavigationAware
    {
        private string _title = "CedarBoard";

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title {  get { return _title; } set { SetProperty(ref _title, value); } }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HomeControlViewModel()
        {

        }

        /// <summary>
        /// (他の画面から)ナビゲーションしたときの動作
        /// </summary>
        /// <param name="navigationContext">ナビゲーションの情報</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 前のナビゲーションを保存するか
        /// </summary>
        /// <param name="navigationContext">ナビゲーションの情報</param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// (この画面から)ナビゲーションした時の動作
        /// </summary>
        /// <param name="navigationContext">ナビゲーションの情報</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
