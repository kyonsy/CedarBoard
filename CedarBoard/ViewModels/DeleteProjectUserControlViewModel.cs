// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// プロジェクトを削除する際のダイアログ
    /// </summary>
	public class DeleteProjectUserControlViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DeleteProjectUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        private string _title = "プロジェクトの削除";
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

