﻿using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// 新しくノードを作るときに出てくるダイアログ
    /// </summary>
	public class NewNodeUserControlViewModel : BindableBase,IDialogAware
	{
        private string _title = "ノードの新規作成";
        private string _nodeName="";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewNodeUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        /// <summary>
        /// ノードの新規作成を完了させる(正確にはデータの入力を完了させる)
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string NodeName { get { return _nodeName; } set { SetProperty(ref _nodeName, value); } }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }

        /// <summary>
        /// 閉じるときのリスナー
        /// </summary>
        public DialogCloseListener RequestClose {  get; set; }


        /// <summary>
        /// ダイアログを閉じれるかどうか
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// ダイアログが閉じるとき
        /// </summary>
        public void OnDialogClosed()
        {
            
        }

        /// <summary>
        /// ダイアログが開くとき
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        private void OKButtonExecute()
        {
            var p = new DialogParameters
            {
                { "nodeName", NodeName },
            };
            var result = new DialogResult(ButtonResult.OK) { Parameters = p };
            RequestClose.Invoke(result);
        }
    }
}
