﻿using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// 新しいプロジェクトを作るときのダイアログ
    /// </summary>
    public class NewProjectUserControlViewModel : BindableBase,IDialogAware
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewProjectUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }
        private string _title = "プロジェクトの新規作成";
        private string _nodeName = "";

        /// <summary>
        /// ノードの新規作成を完了させる(正確にはデータの入力を完了させる)
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string ProjectName { get { return _nodeName; } set { SetProperty(ref _nodeName, value); } }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }

        /// <summary>
        /// 閉じるときのリスナー
        /// </summary>
        public DialogCloseListener RequestClose { get; set; }


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
                { "projectName", ProjectName },
            };
            var result = new DialogResult(ButtonResult.OK) { Parameters = p };
            RequestClose.Invoke(result);
        }
    }
}
