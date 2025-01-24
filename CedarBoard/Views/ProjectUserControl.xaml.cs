using CedarBoard.ViewModels;
using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace CedarBoard.Views
{
    /// <summary>
    /// Interaction logic for ProjectUserControl
    /// </summary>
    public partial class ProjectUserControl : UserControl
    {
        private const int VM_MOUSEHWEEL = 0x020E;
        private HwndSource? _hwndSource;
        private ProjectUserControlViewModel _viewModel;
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
            if (_hwndSource != null) {
                _hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                _hwndSource?.AddHook(WndProc);
            }
           
        }


        private void OnUnLoaded(object sender, RoutedEventArgs e)
        {
            if (_hwndSource != null)
            {
                _hwndSource.RemoveHook(WndProc);
                _hwndSource = null;
            }
        }

        private IntPtr WndProc(IntPtr hwnd,int msg, IntPtr wParam, IntPtr lParam,ref bool handled)
        {
            if (msg == VM_MOUSEHWEEL)
            {
                int delta = unchecked((short)((long)wParam >> 16));
                if (delta != 0)
                {
                    Dispatcher.Invoke(() =>
                    {
                        _viewModel.ScrollHorizontalCommand.Execute(delta);
                    });
                }
            }
            return IntPtr.Zero;
        }

    }
}
