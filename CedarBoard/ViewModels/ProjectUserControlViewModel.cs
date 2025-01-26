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
using System;
using Prism.Dialogs;


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
        IDialogService _dialogService;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControlViewModel(IDialogService dialogService,Project project)
        {
            _dialogService = dialogService;
            _project = project;
            foreach (KeyValuePair<string, INode> nodeKeyValuePair in _project.NodeDictionary)
            {
                NodeUserControlViewModel nodeUserControlViewModel = new NodeUserControlViewModel()
                {
                    Name = nodeKeyValuePair.Value.Name,
                    Message = nodeKeyValuePair.Value.Message,
                    CanvasLeft = nodeKeyValuePair.Value.Point.X,
                    CanvasTop = nodeKeyValuePair.Value.Point.Y,
                    Children = nodeKeyValuePair.Value.ChildNode,
                    Date = nodeKeyValuePair.Value.Data,
                };
                Nodes.Add(nodeUserControlViewModel);
            }
         
            ZoomHighCommand = new DelegateCommand(OnZoomHigh);
            ZoomLowCommand = new DelegateCommand(OnZoomLow);
        }

        // デリゲート
       
        /// <summary>
        /// Canvasを拡大縮小するコマンド
        /// </summary>
        public DelegateCommand ZoomHighCommand { get; }

        /// <summary>
        /// Canvasを拡大縮小するコマンド
        /// </summary>
        public DelegateCommand ZoomLowCommand { get; }

        /// <summary>
        /// 新しいノードを作る
        /// </summary>
        public DelegateCommand<object> CreateNewNode { get; }

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
        /// ノードのリスト
        /// </summary>
        public ObservableCollection<NodeUserControlViewModel> Nodes { get; set; } = new ObservableCollection<NodeUserControlViewModel>();


        /// <summary>
        /// 拡大
        /// </summary>
        private void OnZoomHigh()
        {
            if (_zoomLevel > 5) return;
            ZoomLevel *= 1.1;
        }

        /// <summary>
        /// 縮小
        /// </summary>
        private void OnZoomLow()
        {
            if(_zoomLevel < 0.093)
            {
                return;
            }
            ZoomLevel /= 1.1;
        }

        /// <summary>
        /// 新しいノードを作る
        /// </summary>
        /// <param name="viewModel"></param>
        public void CreateNewNodeExecute(NodeUserControlViewModel viewModel)
        {
            _dialogService.ShowDialog(nameof(NewNodeUserControl), null, (IDialogResult dialogResult) =>
            {
                if (dialogResult.Result == ButtonResult.OK)
                {
                    string nodeName = dialogResult.Parameters.GetValue<string>("nodeName");
                    string parentNodeName = viewModel.Name;
                    Point point = new(viewModel.CanvasLeft,viewModel.CanvasTop);
                    _project.Add(nodeName, parentNodeName,point);
                    //ノードの座標を再構成
                }
            });
        }

    }
}
