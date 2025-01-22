using Prism.Mvvm;
using Prism.Commands;
using CedarBoard.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation.Regions;

namespace CedarBoard.ViewModels
{
    /// <summary>
    ///プロジェクトのビューモデル
    /// </summary>
    public class ProjectUserControlViewModel : BindableBase,INavigationAware
    {
        private double _zoomLevel = 1.0;
        private Project _project;

        /// <summary>
        /// ズームレベル
        /// </summary>
        public double ZoomLevel
        {
            get => _zoomLevel;
            set => SetProperty(ref _zoomLevel, value);
        }

        /// <summary>
        /// ノードのリスト
        /// </summary>
        public ObservableCollection<NodeUserControlViewModel> Nodes { get; set; } = new ObservableCollection<NodeUserControlViewModel>();

        /// <summary>
        /// ノードを追加するコマンド
        /// </summary>
        public DelegateCommand<object> AddNodeCommand { get; }

        /// <summary>
        /// ノードを選択するコマンド
        /// </summary>
        public DelegateCommand<object> SelectNodeCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControlViewModel()
        {
            AddNodeCommand = new DelegateCommand<object>(OnAddNode);
            SelectNodeCommand = new DelegateCommand<object>(OnSelectNode);
        }

        private void OnAddNode(object parameter)
        {
            
        }

        private void OnSelectNode(object parameter)
        {
            // Select node logic
        }

        /// <summary>
        /// この画面に移動するときの操作
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _project = navigationContext.Parameters.GetValue<Project>("Project");

        }

        /// <summary>
        /// 値は保持する
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// この画面から移動するときの操作
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
