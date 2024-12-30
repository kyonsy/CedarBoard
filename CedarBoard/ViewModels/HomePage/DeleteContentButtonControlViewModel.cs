using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// 洗濯した作品を削除するためのボタン
    /// </summary>
    public class DeleteContentButtonControlViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DeleteContentButtonControlViewModel()
        {
            DeleteContent = new DelegateCommand(DeleteContentExecute);
        }
        /// <summary>
        /// 選択した作品を削除するためのバインド用プロパティ
        /// </summary>
        public DelegateCommand DeleteContent { get; }
        private void DeleteContentExecute()
        {

        }
    }
}
