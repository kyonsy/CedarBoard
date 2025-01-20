using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using CedarBoard.ViewModels;

namespace CedarBoard.Views
{
    public partial class NodeUserControl : UserControl
    {
        public NodeUserControl()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += OnMouseLeftButtonDown;
            this.MouseMove += OnMouseMove;
            this.MouseLeftButtonUp += OnMouseLeftButtonUp;
            this.MouseRightButtonUp += OnMouseRightButtonUp;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.CaptureMouse();
            _isDragging = true;
            _startPoint = e.GetPosition((Canvas)Parent);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && Parent is Canvas canvas)
            {
                Point position = e.GetPosition(canvas);
                Canvas.SetLeft(this, position.X - _startPoint.X);
                Canvas.SetTop(this, position.Y - _startPoint.Y);
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ReleaseMouseCapture();
            _isDragging = false;
        }

        private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is NodeUserControlViewModel viewModel)
            {
                viewModel.EditNode();
            }
        }

        private bool _isDragging;
        private Point _startPoint;
    }
}
