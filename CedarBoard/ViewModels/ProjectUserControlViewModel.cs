// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Poco;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CedarBoard.ViewModels
{
    /// <summary>
    ///�v���W�F�N�g�̃r���[���f��
    /// </summary>
    public class ProjectUserControlViewModel : BindableBase
    {
        //�t�B�[���h
        private double _zoomLevel = 1.0;
        private int _slidLevel = 50;
        private Project _project;
        IDialogService _dialogService;
        private double _nodeSize = 200.0;
        private string _projectName;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ProjectUserControlViewModel(IDialogService dialogService, Project project, string projectName)
        {
            _projectName = projectName;
            _dialogService = dialogService;
            _project = project;
            ProjectToNodes();
            ZoomHighCommand = new DelegateCommand(OnZoomHigh);
            ZoomLowCommand = new DelegateCommand(OnZoomLow);
        }

        // �f���Q�[�g

        /// <summary>
        /// Canvas���g��k������R�}���h
        /// </summary>
        public DelegateCommand ZoomHighCommand { get; }

        /// <summary>
        /// Canvas���g��k������R�}���h
        /// </summary>
        public DelegateCommand ZoomLowCommand { get; }

        // �v���p�e�B
        /// <summary>
        /// �Y�[�����x��
        /// </summary>
        public double ZoomLevel
        {
            get => _zoomLevel;
            set => SetProperty(ref _zoomLevel, value);
        }

        /// <summary>
        /// �X���C�_�[�̃��x��
        /// </summary>
        public int SlidLevel
        {
            get => _slidLevel;
            set
            {
                SetProperty(ref _slidLevel, value);
                // �X���C�_�[�̃��x���ɍ��킹�Ċg��k�����s��
                ZoomLevel = 1.0 + (value - 50) / 100.0;
            }
        }

        /// <summary>
        /// �m�[�h�̃��X�g
        /// </summary>
        public ObservableCollection<NodeUserControlViewModel> Nodes { get; set; } = new ObservableCollection<NodeUserControlViewModel>();

        /// <summary>
        /// ���̃��X�g
        /// </summary>
        public ObservableCollection<Line> Lines { get; set; } = new ObservableCollection<Line>();

        /// <summary>
        /// �����Ă��郏�[�N�X�y�[�X
        /// </summary>
        public required Workspace Workspace { get; set; }

        /// <summary>
        /// �g��
        /// </summary>
        private void OnZoomHigh()
        {
            if (_zoomLevel > 5) return;
            ZoomLevel *= 1.1;
        }

        /// <summary>
        /// �k��
        /// </summary>
        private void OnZoomLow()
        {
            if (_zoomLevel < 0.093)
            {
                return;
            }
            ZoomLevel /= 1.1;
        }

        /// <summary>
        /// �m�[�h�̖��O��ς���
        /// </summary>
        /// <param name="viewModel"></param>
        public void EditNodeName(NodeUserControlViewModel viewModel)
        {
            _dialogService.ShowDialog(nameof(EditNodeUserControl), null, (IDialogResult dialogResult) =>
            {
                if (dialogResult.Result == ButtonResult.OK)
                {
                    try
                    {
                        string newNodeName = dialogResult.Parameters.GetValue<string>("nodeName");
                        if (_project.NodeDictionary.ContainsKey(newNodeName))
                        {
                            throw new Exception("�d���������O");
                        }
                        string message = viewModel.Message;
                        string nodeName = viewModel.Name;
                        _project.Rename(nodeName, newNodeName, message);

                        ProjectToNodes();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("�����Ȗ��O�ł�\n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }

                }
            });
        }

        /// <summary>
        /// �m�[�h�ɕR�Â���ꂽ�e�L�X�g�t�@�C����ҏW����
        /// </summary>
        /// <param name="viewModel"></param>
        public void EditNodeText(NodeUserControlViewModel viewModel)
        {
            if (viewModel.Children.Count > 0)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox
                    .Show("�q�v�f�����m�[�h�͏㏑���ۑ��ł��܂���B�G�f�B�^�ɂ���Ă͕ۑ��ł��邩������܂��񂪁A����ȓ���͕ۏ؂ł��܂���B\n�q�m�[�h��ǉ����ĕҏW���邱�Ƃ𐄏����܂��B", "�x��",
                    System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
                if (result != System.Windows.MessageBoxResult.OK) return;
            }
            try
            {
                Workspace.Open(_projectName, viewModel.Name);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("�L���ȃG�f�B�^�̃p�X���w�肳��Ă��܂���\n�G���[���b�Z�[�W: " + ex.Message, "�G���[",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }

        }

        /// <summary>
        /// �V�����m�[�h�����
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
                        System.Windows.MessageBox.Show("�����Ȗ��O�ł�\n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }

                }
            });
        }

        /// <summary>
        /// �V�����m�[�h��}������
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="parentNodeName"></param>
        private void InsertNewNode(string nodeName, string parentNodeName)
        {
            Point point = _project.NodeDictionary[parentNodeName].Point;
            if (_project.NodeDictionary[parentNodeName].ChildNode.Count == 0)
            {
                _project.Add(nodeName, parentNodeName, new(point.X, point.Y + _nodeSize * 1.5));
            }
            else
            {
                int childNum = _project.NodeDictionary[parentNodeName].ChildNode.Count;
                INode maxNode = _project.NodeDictionary[parentNodeName].ChildNode
                    .Select(nodeName => _project.NodeDictionary[nodeName])
                    .OrderByDescending(node => node.Data)
                    .First();

                Point newPoint = new(maxNode.Point.X + 1.5 * _nodeSize, point.Y + _nodeSize * 1.5);
                _project.Add(nodeName, parentNodeName, newPoint);
                foreach (var keyValuePair in _project.NodeDictionary)
                {
                    if (keyValuePair.Value is Node node &&
                        keyValuePair.Value.Point.X >= newPoint.X &&
                        node.ParentNode != parentNodeName)
                    {
                        keyValuePair.Value.Point.X += _nodeSize * 1.5;
                    }
                }
            }
            ProjectToNodes();
        }

        /// <summary>
        /// Project�̓��e��Nodes�ɔɉh������
        /// </summary>
        private void ProjectToNodes()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            foreach (NodeUserControlViewModel node in Nodes)
            {
                keyValuePairs.Add(node.Name, node.Message);
            }

            Nodes.Clear();

            foreach (KeyValuePair<string, INode> nodeKeyValuePair in _project.NodeDictionary)
            {
                string message = "";
                if (keyValuePairs.ContainsKey(nodeKeyValuePair.Key))
                {
                    message = keyValuePairs[nodeKeyValuePair.Key];
                }
                else
                {
                    message = nodeKeyValuePair.Value.Message;
                }

                NodeUserControlViewModel nodeUserControlViewModel = new NodeUserControlViewModel()
                {
                    Name = nodeKeyValuePair.Value.Name,
                    Message = message,
                    CanvasLeft = nodeKeyValuePair.Value.Point.X,
                    CanvasTop = nodeKeyValuePair.Value.Point.Y,
                    Children = nodeKeyValuePair.Value.ChildNode,
                    Date = nodeKeyValuePair.Value.Data,
                };
                Nodes.Add(nodeUserControlViewModel);
            }



            Lines.Clear();
            foreach (KeyValuePair<string, INode> nodeKeyValuePair in _project.NodeDictionary)
            {
                INode parentNode = nodeKeyValuePair.Value;
                if (parentNode.ChildNode.Count == 0)
                {
                    continue;
                }
                List<INode> children = nodeKeyValuePair.Value.ChildNode
                    .Select(n => _project.NodeDictionary[n])
                    .ToList();
                Point parentPoint = new(parentNode.Point.X + _nodeSize / 2, parentNode.Point.Y + _nodeSize / 2);
                foreach (INode childNode in children)
                {
                    Lines.Add(new()
                    {
                        X1 = parentPoint.X,
                        Y1 = parentPoint.Y,
                        X2 = childNode.Point.X + _nodeSize / 2,
                        Y2 = childNode.Point.Y + _nodeSize / 2,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2
                    });
                }
            }
        }
    }
}

