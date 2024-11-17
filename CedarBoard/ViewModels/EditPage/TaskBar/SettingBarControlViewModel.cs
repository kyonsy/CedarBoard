using CedarBoard.Model.Poco;
using CedarBoard.Views.EditPage.TaskBar;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace CedarBoard.ViewModels.EditPage.TaskBar
{
    public class SettingBarControlViewModel : BindableBase,INavigationAware
    {
        private readonly IDialogService _dialogService;

        public SettingBarControlViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SettingMenuItemClick = new DelegateCommand(SettingMenuItemClickExecute);
        }

        public DelegateCommand SettingMenuItemClick { get; }

        private void SettingMenuItemClickExecute()
        {
            _dialogService.ShowDialog(nameof(SettingSettingControl), null, null);
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
