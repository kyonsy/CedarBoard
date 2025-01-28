// Copyright (c) 2024 YourName
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Dialogs;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ���[�N�X�y�[�X�̉��
    /// </summary>
    public class WorkspaceUserControlViewModel : BindableBase, INavigationAware,System.ComponentModel.INotifyPropertyChanged, IDisposable
    {
        // �t�B�[���h
        private IRegionManager _regionManager;
        private Workspace _workspace;
        private ObservableCollection<TreeItem> _workspaceItems;
        private ObservableCollection<TabViewModel> _tabs;
        private IDialogService _dialogService;
        private readonly SubscriptionToken _closingToken;


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public WorkspaceUserControlViewModel(IRegionManager regionManager,IDialogService dialogService, IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            BackNewEntry = new DelegateCommand(BackNewEntryExecute);
            BackHome = new DelegateCommand(BackHomeExecute);
            SaveWorkspace = new DelegateCommand(SaveWorkspaceExecute);
            AddProject = new DelegateCommand(AddProjectExecute);
            DeleteProject = new DelegateCommand(DeleteProjectExecute);
            BackEditWork = new DelegateCommand(BackEditWorkExecute);
            ChangeProjectName = new DelegateCommand(ChangeProjectNameExecute);
            _closingToken = eventAggregator
            .GetEvent<WindowClosingEvent>()
            .Subscribe(OnWindowClosing);
        }

        // �f���Q�[�g
        /// <summary>
        /// �V�K�쐬��ʂֈړ�
        /// </summary>
        public DelegateCommand BackNewEntry { get; }

        /// <summary>
        /// �z�[����ʂ֖߂�
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// ���[�N�X�y�[�X��ۑ�����
        /// </summary>
        public DelegateCommand SaveWorkspace { get; }

        /// <summary>
        /// �V�����v���W�F�N�g�����
        /// </summary>
        public DelegateCommand AddProject { get; }

        /// <summary>
        /// �v���W�F�N�g���폜����
        /// </summary>
        public DelegateCommand DeleteProject { get; }

        /// <summary>
        /// ���[�N�X�y�[�X�ҏW��ʂ֖߂�
        /// </summary>
        public DelegateCommand BackEditWork { get; }

        /// <summary>
        /// �v���W�F�N�g���̕ύX
        /// </summary>
        public DelegateCommand ChangeProjectName { get; }


        //�v���p�e�B
        /// <summary>
        /// �^�u�̃��X�g
        /// </summary>
        public ObservableCollection<TabViewModel> Tabs
        {
            get => _tabs;
            set => SetProperty(ref _tabs, value);
        }

        private TabViewModel _selectedTab;

        /// <summary>
        /// �I�����ꂽ�^�u
        /// </summary>
        public TabViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        /// <summary>
        /// �f�[�^���f���Ƀ��[�N�X�y�[�X������
        /// </summary>
        public ObservableCollection<TreeItem> WorkspaceItems { get { return _workspaceItems; } set { SetProperty(ref _workspaceItems, value); } }

        /// <summary>
        /// �v���W�F�N�g�̖��O��ς���
        /// </summary>
        private void ChangeProjectNameExecute()
        {
            _dialogService.ShowDialog(nameof(ChangeProjectNameUserControl), null, (IDialogResult dialogResult) =>
            {
                if (dialogResult.Result == ButtonResult.OK)
                {
                    try
                    {
                        string projectName = dialogResult.Parameters.GetValue<string>("projectName");
                        string newProjectName = dialogResult.Parameters.GetValue<string>("newProjectName");
                        _workspace.Rename(projectName, newProjectName);
                        TabViewModel newTabViewModel = new TabViewModel()
                        {
                            Header = newProjectName,
                            ProjectViewModel = new(_dialogService, _workspace.WorkspacePoco.ProjectDictionary[newProjectName], newProjectName) { Workspace = _workspace },
                        };
                        TabViewModel tabViewModel = Tabs.Where(tab => tab.Header == projectName).First();
                        Tabs.Add(newTabViewModel);           
                        Tabs.Remove(tabViewModel);
                        MakeTreeItemList();
                        MakeTabsList();
                        _workspace.Save();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("�����Ȗ��O�ł�\n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }
                }
            });
        }

        /// <summary>
        /// �V�K�쐬
        /// </summary>
        private void BackNewEntryExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NewEntryUserControl));
        }

        /// <summary>
        /// �J��
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }
        /// <summary>
        /// �ۑ�
        /// </summary>
        private void SaveWorkspaceExecute()
        {
            _workspace.Save();
        }

        /// <summary>
        /// �V�K�v���W�F�N�g
        /// </summary>
        private void AddProjectExecute() {
            _dialogService.ShowDialog(nameof(NewProjectUserControl), null, (IDialogResult dialogResult) =>
            {
                if (dialogResult.Result == ButtonResult.OK)
                {
                    try
                    {
                        string newProjectName = dialogResult.Parameters.GetValue<string>("projectName");
                        _workspace.Add(newProjectName);
                        TabViewModel tabViewModel = new TabViewModel()
                        {
                            Header = newProjectName,
                            ProjectViewModel = new(_dialogService, _workspace.WorkspacePoco.ProjectDictionary[newProjectName], newProjectName) { Workspace = _workspace},
                        };
                        Tabs.Add(tabViewModel);
                        MakeTreeItemList();
                        MakeTabsList();
                        _workspace.Save();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("�����Ȗ��O�ł�\n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }

                }
            });
        }

        /// <summary>
        /// �v���W�F�N�g���폜
        /// </summary>
        private void DeleteProjectExecute() {
            _dialogService.ShowDialog(nameof(DeleteProjectUserControl), null, (IDialogResult dialogResult) =>
            {
                if (dialogResult.Result == ButtonResult.OK)
                {
                    try
                    {
                        System.Windows.MessageBoxResult result =  System.Windows.MessageBox.Show("�폜�����v���W�F�N�g�̕����͂ł��܂��񂪖{���ɍ폜���Ă���낵���ł��傤���H", 
                            "�x��", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
                        if(result != System.Windows.MessageBoxResult.OK)
                        {
                            return;
                        }
                        string projectName = dialogResult.Parameters.GetValue<string>("projectName");
                        if(projectName == "MainProject")
                        {
                            throw new Exception("MainProject�͍폜�ł��܂���");
                        }                  
                        TabViewModel tabViewModel = new TabViewModel()
                        {
                            Header = projectName,
                            ProjectViewModel = new(_dialogService, _workspace.WorkspacePoco.ProjectDictionary[projectName], projectName) { Workspace = _workspace },
                        };
                        Tabs.Remove(tabViewModel);
                        _workspace.Remove(projectName);
                        MakeTreeItemList();
                        MakeTabsList();
                        _workspace.Save();  
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("�����Ȗ��O�ł�\n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                        return;
                    }

                }
            });
        }


        /// <summary>
        /// ���[�N�X�y�[�X�̐ݒ�
        /// </summary>
        private void BackEditWorkExecute() {
            var p = new NavigationParameters
            {
                { "Setting", _workspace.WorkspacePoco.Setting }
            };
            _regionManager.RequestNavigate("ContentRegion", nameof(EditWorkUserControl),p);
        }

        /// <summary>
        /// ���̉�ʂ��瑼�̉�ʂɈړ�����Ƃ��̑���
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _workspace = navigationContext.Parameters.GetValue<Workspace>("Workspace");
            MakeTreeItemList();
            MakeTabsList();    
        }

        /// <summary>
        /// �A�C�e���c���[�̃��X�g�����
        /// </summary>
        private void MakeTreeItemList()
        {
            WorkspaceItems = new ObservableCollection<TreeItem>();
            TreeItem items = new(_workspace.WorkspacePoco.Setting.Name);
            foreach (var projectKetValuePair in _workspace.WorkspacePoco.ProjectDictionary)
            {
                TreeItem ProjectTree = new(projectKetValuePair.Key);
                foreach (var node in projectKetValuePair.Value.NodeDictionary)
                {
                    ProjectTree.Children.Add(new TreeItem(node.Key));
                }
                items.Children.Add(ProjectTree);
            }
            WorkspaceItems.Add(items);
        }

        /// <summary>
        /// �^�u�̃��X�g�����
        /// </summary>
        private void MakeTabsList()
        {
            Tabs = new ObservableCollection<TabViewModel>();
            foreach (var projectKetValuePair in _workspace.WorkspacePoco.ProjectDictionary)
            {
                Tabs.Add(CreateTabViewModel(projectKetValuePair));
            }
            SelectedTab = Tabs[0];
        }

        /// <summary>
        /// �^�uViewModel�����
        /// </summary>
        private TabViewModel CreateTabViewModel(KeyValuePair<string,Project> projectKetValuePair)
        {
            TabViewModel tabViewModel = new TabViewModel();
            tabViewModel.Header = projectKetValuePair.Key;
            tabViewModel.ProjectViewModel = new(_dialogService, projectKetValuePair.Value,projectKetValuePair.Key) { Workspace = _workspace};
            return tabViewModel;
        }

        /// <summary>
        /// �J�ڂ���ۂ̓C���X�^���X���g���܂킳�Ȃ�
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        /// <returns>�C���X�^���X���g���܂킷���ǂ���</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// ���̉�ʂ��瑼�̉�ʂɈړ�����Ƃ��̑���
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            MessageBoxResult result = MessageBox.Show("���[�N�X�y�[�X��ۑ����܂����H", "�ύX���e�̕ۑ�", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                _workspace.Save();
            }
        }


        private void OnWindowClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("���[�N�X�y�[�X��ۑ����܂����H", "�ύX���e�̕ۑ�", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                _workspace.Save();
            }
        }

        /// <summary>
        /// �I�u�W�F�N�g���p�������Ƃ��̏���
        /// </summary>
        public void Dispose()
        {
            _closingToken?.Dispose();
        }
    }
}

