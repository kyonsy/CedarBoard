using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.HomePage
{
    /// <summary>
    /// ワークスペースの情報を編集する
    /// </summary>
    public class EditContentButtonControlViewModel : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditContentButtonControlViewModel()
        { 
            EditContent = new DelegateCommand(EditContentExecute);
        }
        /// <summary>
        /// EditContentExecuteを実行するためのバインド用プロパティ
        /// </summary>
        public DelegateCommand EditContent {  get; }
        private void EditContentExecute()
        {

        }
    }
}
