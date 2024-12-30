using CedarBoard.Model;
using CedarBoard.Views.HomePage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
        private IDialogService _dialogService;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EditContentButtonControlViewModel(IDialogService dialogService)
        { 
            _dialogService = dialogService;
            EditContent = new DelegateCommand(EditContentExecute);
        }
        /// <summary>
        /// EditContentExecuteを実行するためのバインド用プロパティ
        /// </summary>
        public DelegateCommand EditContent {  get; }
        private void EditContentExecute()
        {
            _dialogService.ShowDialog(nameof(EditContentWindow), null, null);
        }
    }
}
