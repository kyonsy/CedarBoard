// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ノードのビューモデル
    /// </summary>
    public class NodeUserControlViewModel : BindableBase
    {
        private string _name;
        private string _message;
        private double _canvasTop;


        /// <summary>
        /// 作成日時
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


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
        /// ノードを編集するコマンド
        /// </summary>
        public DelegateCommand EditNodeCommand { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NodeUserControlViewModel()
        {
            OpenTextEditorCommand = new DelegateCommand(OpenTextEditor);
            EditNodeCommand = new DelegateCommand(EditNode);
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

