using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// ワークスペースの設定を変更するウィンドウ
    /// </summary>
    public class EditContentWindowViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditContentWindowViewModel()
        {

        }

        /// <summary>
        /// 画面のタイトル
        /// </summary>
        public string Title => "設定の編集";

        /// <summary>
        /// アクション
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// この画面を閉じることが出来るか
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 閉じるときの動作
        /// </summary>
        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 画面が開くときの動作
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
