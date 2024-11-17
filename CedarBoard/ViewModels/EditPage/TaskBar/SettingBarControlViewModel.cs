using CedarBoard.Model.Poco;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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
        public SettingBarControlViewModel()
        {
            
        }

        public DelegateCommand SettingMenuItemClick { get; }

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
