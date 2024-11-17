using CedarBoard.Views.EditPage.TaskBar;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels.EditPage.TaskBar
{
    public class TaskBarControlViewModel : BindableBase,INavigationAware
    {
        private readonly IDialogService _dialogService;
        public TaskBarControlViewModel()
        {
            SettingMenuItemClick = new DelegateCommand(SettingMenuItemClickExecute);
        }

        public DelegateCommand SettingMenuItemClick { get; }

        private void SettingMenuItemClickExecute()
        {
            _dialogService.ShowDialog(nameof(SettingSettingControl));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}
