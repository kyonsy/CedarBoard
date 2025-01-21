using Prism.Mvvm;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    ///プロジェクトのビューモデル
    /// </summary>
    public class ProjectUserControlViewModel : BindableBase
    {
        private double _zoomLevel = 1.0;

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
    }
}
