// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
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
    /// 繝｡繧､繝ｳ繧ｦ繧｣繝ｳ繝峨え
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "CedarBoard";
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 繧ｳ繝ｳ繧ｹ繝医Λ繧ｯ繧ｿ縲よ怙蛻昴・繝帙・繝逕ｻ髱｢縺ｫ驕ｷ遘ｻ縺吶ｋ
        /// </summary>
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(HomeUserControl));
        }
        /// <summary>
        /// 繧ｿ繧､繝医Ν縺ｮ繝励Ο繝代ユ繧｣
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}


