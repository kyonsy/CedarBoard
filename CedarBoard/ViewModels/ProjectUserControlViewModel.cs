using Prism.Mvvm;
using Prism.Commands;
using CedarBoard.Model;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Navigation.Regions;
using CedarBoard.Views;
using CedarBoard.Model.Poco;
using System.Collections.Generic;

namespace CedarBoard.ViewModels
{
    /// <summary>
    ///プロジェクトのビューモデル
    /// </summary>
    public class ProjectUserControlViewModel : BindableBase,INavigationAware
    {
        //フィールド
        private double _zoomLevel = 1.0;
        private Project _project;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControlViewModel()
        {

            AddNodeCommand = new DelegateCommand<object>(OnAddNode);
            SelectNodeCommand = new DelegateCommand<object>(OnSelectNode);
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
        /// ノードのリスト
        /// </summary>
        public ObservableCollection<NodeUserControl> Nodes { get; set; } = new ObservableCollection<NodeUserControl>();


        // メソッド
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
            foreach(KeyValuePair<string, INode> node in _project.NodeDictionary)
            {
                NodeUserControlViewModel nodeUserControlViewModel = new NodeUserControlViewModel()
                {
                    Name = node.Key,
                    Message = node.Value.Message,
                    CanvasLeft = node.Value.Point.X,
                    CanvasTop = node.Value.Point.Y,
                    Children = node.Value.ChildNode
                };  
                Nodes.Add(new NodeUserControl()
                {
                    DataContext = nodeUserControlViewModel
                });
            }
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
