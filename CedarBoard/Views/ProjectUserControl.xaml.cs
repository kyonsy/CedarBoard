using CedarBoard.ViewModels;
using Prism.Events;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace CedarBoard.Views
{
    /// <summary>
    /// バインドできるプロパティの制限よりViewModeを使うのが困難
    /// ScrollViewerの処理はコードビハインドに記述
    /// </summary>
    public partial class ProjectUserControl : UserControl
    {
        private const int WM_MOUSEHWHEEL = 0x020E;
        private const int WM_MOUSEWHEEL = 0x020A;
        private HwndSource? _hwndSource;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControl()
        {
            InitializeComponent();
           // Loaded += OnLoaded;
           // Unloaded += OnUnLoaded;
        }

        //private void OnLoaded(object sender,RoutedEventArgs e)
        //{
        //    if (_hwndSource == null) {
        //        _hwndSource = PresentationSource.FromVisual(this) as HwndSource;
        //        _hwndSource?.AddHook(WndProc);
        //    }
           
        //}

        
        //private void OnUnLoaded(object sender, RoutedEventArgs e) { 
        //    if(_hwndSource != null)
        //    {
        //        _hwndSource.RemoveHook(WndProc);
        //        _hwndSource = null;
        //    }
        //}

        //private IntPtr WndProc(IntPtr hwnd,int msg, IntPtr wParam, IntPtr lParam,ref bool handled)
        //{
        //    switch (msg)
        //    {
        //        case WM_MOUSEHWHEEL:
        //            OnMouseHorizontalWheel(wParam); 
        //            break;

        //        case WM_MOUSEWHEEL:
        //            OnMouseWheel(wParam);
        //            break;           
        //    }
        //    return IntPtr.Zero;
        //}

        //private void OnMouseHorizontalWheel(IntPtr wParam)
        //{
        //    int delta = unchecked((short)((long)wParam >> 16));
        //    if (delta is 0)
        //    {
        //        return;
        //    }

        //    CanvasScroller.ScrollToHorizontalOffset(CanvasScroller.HorizontalOffset + delta);
        //}

        //private void OnMouseWheel(IntPtr wParam)
        //{
        //    int delta = unchecked((short)((long)wParam >> 16));
        //    if (delta is 0)
        //    {
        //        return;
        //    }
        //    CanvasScroller.ScrollToVerticalOffset(CanvasScroller.VerticalOffset - delta);
        //}

        


        private void NodeUserControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void NodeUserControl_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (ProjectUserControlViewModel)DataContext;
            NodeUserControl nodeNodeUserControl = sender as NodeUserControl;
            if (nodeNodeUserControl != null)
            {
                viewModel.EditNodeText(nodeNodeUserControl.DataContext as NodeUserControlViewModel);
            }
        }

        private void MenuItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (ProjectUserControlViewModel)DataContext; 
            var menuItem = sender as MenuItem;
            var contextMenu = menuItem?.Parent as ContextMenu;
            NodeUserControl nodeUserControl = contextMenu?.PlacementTarget as NodeUserControl;
            if (nodeUserControl != null)
            {
                viewModel.CreateNewNode(nodeUserControl.DataContext as NodeUserControlViewModel);
            }
        }

        private void MenuItem_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var viewModel = (ProjectUserControlViewModel)DataContext;
            var menuItem = sender as MenuItem;
            var contextMenu = menuItem?.Parent as ContextMenu;
            NodeUserControl nodeUserControl = contextMenu?.PlacementTarget as NodeUserControl;
            if (nodeUserControl != null)
            {
                viewModel.EditNodeName(nodeUserControl.DataContext as NodeUserControlViewModel);
            }
        }
    }
}
