// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// プロジェクト名を変えるダイアログ
    /// </summary>
    public class ChangeProjectNameUserControlViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ChangeProjectNameUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        private string _title = "プロジェクト名の変更";
        private string _projectName = "";
        private string _newProjectName = "";

        /// <summary>
        /// ノードの新規作成を完了させる(正確にはデータの入力を完了させる)
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        ///　プロジェクトの名前
        /// </summary>
        public string ProjectName { get { return _projectName; } set { SetProperty(ref _projectName, value); } }

        /// <summary>
        /// 新しいプロジェクトの名前
        /// </summary>
        public string NewProjectName { get { return _newProjectName; } set { SetProperty(ref _newProjectName, value); } }

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
                {"newProjectName",NewProjectName }
            };
            var result = new DialogResult(ButtonResult.OK) { Parameters = p };
            RequestClose.Invoke(result);
        }
    }
}

