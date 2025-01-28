// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.ViewModels;
using Prism.Events;
using System.ComponentModel;
using System.Windows;

namespace CedarBoard.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// �R�[�h�r�n�C���h
        /// </summary>
        public MainWindow(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            _eventAggregator.GetEvent<WindowClosingEvent>().Publish(e);
        }
    }
}


