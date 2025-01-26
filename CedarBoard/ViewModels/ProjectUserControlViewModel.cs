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
        private double nodeSize = 200.0;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControlViewModel(IDialogService dialogService,Project project)
        {
            _dialogService = dialogService;
            _project = project;
            ProjectToNodes();
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
        public void CreateNewNode(NodeUserControlViewModel viewModel)
        {
            _dialogService.ShowDialog(nameof(NewNodeUserControl), null, (IDialogResult dialogResult) =>
            {               
                if (dialogResult.Result == ButtonResult.OK)
                {
                    try
                    {
                        string nodeName = dialogResult.Parameters.GetValue<string>("nodeName");
                        string parentNodeName = viewModel.Name;
                        InsertNewNode(nodeName, parentNodeName);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("無効な名前です\nエラーメッセージ: " + ex.Message, "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }
                    
                }
            });
        }

        /// <summary>
        /// 新しいノードを挿入する
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="parentNodeName"></param>
        private void InsertNewNode(string nodeName,string parentNodeName)
        {
            Point point = _project.NodeDictionary[parentNodeName].Point;
            if (_project.NodeDictionary[parentNodeName].ChildNode.Count == 0)
            {               
                _project.Add(nodeName, parentNodeName,new(point.X , point.Y + nodeSize * 1.5));
            }
            else
            {
                int childNum = _project.NodeDictionary[parentNodeName].ChildNode.Count;
                INode maxNode = _project.NodeDictionary[parentNodeName].ChildNode
                    .Select(nodeName => _project.NodeDictionary[nodeName])
                    .OrderByDescending(node => node.Data)
                    .First();

                Point newPoint = new(maxNode.Point.X + 1.5 * nodeSize , point.Y + nodeSize * 1.5);
                _project.Add(nodeName,parentNodeName,newPoint);
                foreach (var keyValuePair in _project.NodeDictionary)
                { 
                    if(keyValuePair.Value is Node node && 
                        keyValuePair.Value.Point.X >= newPoint.X && 
                        node.ParentNode != parentNodeName)
                    {
                        keyValuePair.Value.Point.X += nodeSize * 1.5;
                    }
                }
            }
            ProjectToNodes();
        }

        /// <summary>
        /// Projectの内容をNodesに繁栄させる
        /// </summary>
        private void ProjectToNodes()
        {
            Nodes.Clear();
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
        }
    }
}
