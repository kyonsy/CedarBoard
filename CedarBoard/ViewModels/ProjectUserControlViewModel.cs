using Prism.Mvvm;
using Prism.Commands;
using CedarBoard.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation.Regions;
using CedarBoard.Views;
using CedarBoard.Model.Poco;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
using Prism.Events;


namespace CedarBoard.ViewModels
{
    /// <summary>
    ///プロジェクトのビューモデル
    /// </summary>
    public class ProjectUserControlViewModel : BindableBase
    {
        //フィールド
        private double _zoomLevel = 1.0;
        private Project _project;
        private double _horizontalOffset;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControlViewModel(Project project)
        {
            _project = project;
            foreach (KeyValuePair<string, INode> nodeKeyValuePair in _project.NodeDictionary)
            {
                NodeUserControlViewModel nodeUserControlViewModel = new NodeUserControlViewModel()
                {
                    Name = nodeKeyValuePair.Key,
                    Message = nodeKeyValuePair.Value.Message,
                    CanvasLeft = nodeKeyValuePair.Value.Point.X,
                    CanvasTop = nodeKeyValuePair.Value.Point.Y,
                    Children = nodeKeyValuePair.Value.ChildNode
                };
                NodeViewModel nodeViewModel = new NodeViewModel() { Context = nodeUserControlViewModel };
                Nodes.Add(nodeViewModel);
            }
            AddNodeCommand = new DelegateCommand<object>(OnAddNode);
            SelectNodeCommand = new DelegateCommand<object>(OnSelectNode);
            ZoomCommand = new DelegateCommand<object>(OnZoom);
            ScrollVerticalCommand = new DelegateCommand<object>(OnScrollVertical);
            ScrollHorizontalCommand = new DelegateCommand<int?>(OnScrollHorizontal);
        }

        // デリゲート
        /// <summary>
        /// ノードを追加するコマンド
        /// </summary>
        public DelegateCommand<object> AddNodeCommand { get; }

        /// <summary>
        /// ノードを選択するコマンド
        /// </summary>
        public DelegateCommand<object> SelectNodeCommand { get; }

        /// <summary>
        /// Canvasを拡大縮小するコマンド
        /// </summary>
        public DelegateCommand<object> ZoomCommand { get; }

        /// <summary>
        /// Canvasを縦にスクロールするコマンド
        /// </summary>
        public DelegateCommand<object> ScrollVerticalCommand { get; }

        /// <summary>
        /// Canvasを横にスクロールするコマンド
        /// </summary>
        public DelegateCommand<int?> ScrollHorizontalCommand { get; }

        // プロパティ
        /// <summary>
        /// ズームレベル
        /// </summary>
        public double ZoomLevel
        {
            get => _zoomLevel;
            set => SetProperty(ref _zoomLevel, value);
        }

        /// <summary>
        /// 水平方向の移動
        /// </summary>
        public double HorizontalOffset
        {
            get => _horizontalOffset;
            set => SetProperty(ref _horizontalOffset, value);
        }

        /// <summary>
        /// ノードのリスト
        /// </summary>
        public ObservableCollection<NodeViewModel> Nodes { get; set; } = new ObservableCollection<NodeViewModel>();


        // メソッド
        private void OnAddNode(object parameter)
        {
            
        }

        private void OnSelectNode(object parameter)
        {
            // Select node logic
        }

        /// <summary>
        /// ズーム
        /// </summary>
        /// <param name="parameter"></param>
        private void OnZoom(object parameter)
        {
            
        }

        /// <summary>
        /// 縦方向のスクロール
        /// </summary>
        /// <param name="parameter"></param>
        private void OnScrollVertical(object parameter)
        {

        }

        private void OnScrollHorizontal(int? delta)
        {
            if (delta.HasValue)
            {
                HorizontalOffset = delta.Value;
            }
            
        }
    }
}
