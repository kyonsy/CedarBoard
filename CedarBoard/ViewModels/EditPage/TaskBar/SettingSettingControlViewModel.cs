using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.EditPage.TaskBar
{
    public class SettingSettingControlViewModel : BindableBase, IDialogAware
    {
        public SettingSettingControlViewModel()
        {

        }

        public string Title => throw new NotImplementedException();

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
