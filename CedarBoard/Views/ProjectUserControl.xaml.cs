using CedarBoard.ViewModels;
using Prism.Events;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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
        private const int WM_GESTURE = 0x119;
        private const int MK_COMTROL = 0x0008;
        private HwndSource? _hwndSource;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ProjectUserControl()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            Unloaded += OnUnLoaded;
        }

        private void OnLoaded(object sender,RoutedEventArgs e)
        {
            if (_hwndSource == null) {
                _hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                _hwndSource?.AddHook(WndProc);
            }
           
        }

        
        private void OnUnLoaded(object sender, RoutedEventArgs e) { 
            if(_hwndSource != null)
            {
                _hwndSource.RemoveHook(WndProc);
                _hwndSource = null;
            }
        }

        private IntPtr WndProc(IntPtr hwnd,int msg, IntPtr wParam, IntPtr lParam,ref bool handled)
        {
            switch (msg)
            {
                case MK_COMTROL:
                    OnMouseControl(wParam);
                    break;
                case WM_GESTURE:
                    OnGesture(wParam);
                    break;
                case WM_MOUSEHWHEEL:
                    OnMouseHorizontalWheel(wParam); 
                    break;

                case WM_MOUSEWHEEL:
                    OnMouseWheel(wParam);
                    break;           
            }
            return IntPtr.Zero;
        }

        private void OnMouseHorizontalWheel(IntPtr wParam)
        {
            int delta = unchecked((short)((long)wParam >> 16));
            if (delta is 0)
            {
                return;
            }

            CanvasScroller.ScrollToHorizontalOffset(CanvasScroller.HorizontalOffset + delta);
        }

        private void OnMouseWheel(IntPtr wParam)
        {
            int delta = unchecked((short)((long)wParam >> 16));
            if (delta is 0)
            {
                return;
            }
            CanvasScroller.ScrollToVerticalOffset(CanvasScroller.VerticalOffset - delta);
        }

        private void OnMouseControl(IntPtr wParam)
        {
            int delta = unchecked((short)((long)wParam >> 16));
            if (delta is 0)
            {
                return;
            }
            double zoomLevel = 1.0 + (delta / 100);
            GridScaleTransform.ScaleX *= zoomLevel;
            GridScaleTransform.ScaleY *= zoomLevel;
        }

        private void OnGesture(IntPtr wParam)
        {
            int delta = unchecked((short)((long)wParam >> 16));
            if (delta is 0)
            {
                return;
            }
            double zoomLevel = 1.0 + (delta / 100);
            GridScaleTransform.ScaleX *= zoomLevel;
            GridScaleTransform.ScaleY *= zoomLevel;
        }
    }
}
