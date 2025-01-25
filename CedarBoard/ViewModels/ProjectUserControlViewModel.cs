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
        private int _slidLevel = 50;
        private Project _project;
        private NodeUserControl _selectedNode;

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
                Nodes.Add(nodeUserControlViewModel);
            }
            MouseDoubleClickCommand = new DelegateCommand<object>(OnMouseDoubleClick);
            MouseClickCommand = new DelegateCommand<object>(OnMouseClick);
            MouseRightClickCommand = new DelegateCommand<object>(OnMouseRightClick);
            ZoomHighCommand = new DelegateCommand(OnZoomHigh);
            ZoomLowCommand = new DelegateCommand(OnZoomLow);
        }

        // デリゲート
        /// <summary>
        /// クリックしたときの
        /// </summary>
        public DelegateCommand<object> MouseClickCommand { get; }

        /// <summary>
        /// ダブルクリックしたときの動作
        /// </summary>
        public DelegateCommand<object> MouseDoubleClickCommand { get; }

        /// <summary>
        ///　右クリックしたときの動作
        /// </summary>
        public DelegateCommand<object> MouseRightClickCommand { get; }

        /// <summary>
        /// Canvasを拡大縮小するコマンド
        /// </summary>
        public DelegateCommand ZoomHighCommand { get; }

        /// <summary>
        /// Canvasを拡大縮小するコマンド
        /// </summary>
        public DelegateCommand ZoomLowCommand { get; }

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
        /// スライダーのレベル
        /// </summary>
        public int SlidLevel
        {
            get => _slidLevel;
            set {
                SetProperty(ref _slidLevel, value);
                // スライダーのレベルに合わせて拡大縮小を行う
                ZoomLevel = 1.0 + (value - 50) / 100.0;
            } 
        }

        /// <summary>
        /// 選択されているノード
        /// </summary>
        public NodeUserControl SelectedNode { get => _selectedNode; set => SetProperty(ref _selectedNode, value); }

        /// <summary>
        /// ノードのリスト
        /// </summary>
        public ObservableCollection<NodeUserControlViewModel> Nodes { get; set; } = new ObservableCollection<NodeUserControlViewModel>();

        private void OnMouseDoubleClick(object parameter)
        {

        }

        // メソッド
        private void OnMouseClick(object parameter)
        {
            Debug.WriteLine(parameter);
        }

        private void OnMouseRightClick(object parameter)
        {
            // Select node logic
        }

        /// <summary>
        /// 拡大
        /// </summary>
        private void OnZoomHigh()
        {
            if (_zoomLevel > 5) return;
            ZoomLevel *= 1.1;
        }

        /// <summary>
        /// 拡大
        /// </summary>
        private void OnZoomLow()
        {
            if(_zoomLevel < 0.093)
            {
                return;
            }
            ZoomLevel /= 1.1;
        }
    }
}
