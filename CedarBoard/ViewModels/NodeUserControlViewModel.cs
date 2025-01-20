using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ノードのビューモデル
    /// </summary>
    public class NodeUserControlViewModel : BindableBase
    {
        private string _name;

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _message;

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private double _canvasLeft;

        /// <summary>
        /// キャンバスの左(X座標)
        /// </summary>
        public double CanvasLeft
        {
            get => _canvasLeft;
            set => SetProperty(ref _canvasLeft, value);
        }

        private double _canvasTop;

        /// <summary>
        /// キャンバスの上(Y座標)
        /// </summary>
        public double CanvasTop
        {
            get => _canvasTop;
            set => SetProperty(ref _canvasTop, value);
        }

        /// <summary>
        /// テキストエディタを開くコマンド
        /// </summary>
        public DelegateCommand OpenTextEditorCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NodeUserControlViewModel()
        {
            OpenTextEditorCommand = new DelegateCommand(OpenTextEditor);
        }


        /// <summary>
        /// 子ノードのリスト
        /// </summary>
        public List<string> Children { get; set; } = new List<string>();



        /// <summary>
        /// テキストエディタを開く
        /// </summary>
        public void OpenTextEditor()
        {
            
        }

        /// <summary>
        /// ノードを削除する
        /// </summary>
        public void EditNode()
        {
            
        }
    }
}
