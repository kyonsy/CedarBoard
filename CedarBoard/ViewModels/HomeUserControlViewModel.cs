// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �z�[�����
    /// </summary>
    public class HomeUserControlViewModel : BindableBase, INavigationAware
    {
        //�t�B�[���h
        private string _title = "CedarBoard";
        WorkspaceSelector _workspaceSelector;
        private IRegionManager _regionManager;

        /// <summary>
        /// �R���X�g���N�^�B�ŏ��̓z�[����ʂɑJ�ڂ���
        /// </summary>
        public HomeUserControlViewModel(WorkspaceSelector workspaceSelector, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _workspaceSelector = workspaceSelector;
            DictionaryItems = new ObservableCollection<KeyValuePair<string, string>>(
                workspaceSelector.SelectorPoco.PathDictionary);
            NewEntry = new DelegateCommand(NewEntryExecute);
            EditWork = new DelegateCommand(EditWorkExecute);
            DeleteWork = new DelegateCommand(DeleteWorkExecute);
            OpenWork = new DelegateCommand(OpenWorkExecute);
            OpenFile = new DelegateCommand(OpenFileExecute);
        }

        //�f���Q�[�g
        /// <summary>
        /// �V�K�쐬��ʂւ̑J��
        /// </summary>
        public DelegateCommand NewEntry { get; }

        /// <summary>
        /// ��i��ҏW����
        /// </summary>
        public DelegateCommand EditWork { get; }

        /// <summary>
        /// ��i���폜����
        /// </summary>
        public DelegateCommand DeleteWork { get; }

        /// <summary>
        /// ��i���J��
        /// </summary>
        public DelegateCommand OpenWork { get; }


        /// <summary>
        /// �t�@�C�����J��
        /// </summary>
        public DelegateCommand OpenFile { get; }

        // �v���p�e�B
        /// <summary>
        /// �^�C�g���̃v���p�e�B
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// �\������郊�X�g
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> _dictionaryItems;

        /// <summary>
        /// �\������郊�X�g�̃v���p�e�B
        /// </summary>
        public ObservableCollection<KeyValuePair<string, string>> DictionaryItems
        {
            get { return _dictionaryItems; }
            set { SetProperty(ref _dictionaryItems, value); }
        }

        /// <summary>
        /// ���[�U�[���I�����Ă����i
        /// </summary>
        private KeyValuePair<string, string>? _selectedKeyValuePair;

        /// <summary>
        /// ���[�U�[���I�����Ă����i�̃v���p�e�B
        /// </summary>
        public KeyValuePair<string, string>? SelectedKeyValuePair { get { return _selectedKeyValuePair; } set { SetProperty(ref _selectedKeyValuePair, value); } }

        /// <summary>
        /// ���[�U�[���_�u���N���b�N������i
        /// </summary>
        private KeyValuePair<string, string> _clickedKeyValuePair;

        /// <summary>
        /// ���[�U�[���_�u���N���b�N������i�̃v���p�e�B
        /// </summary>
        public KeyValuePair<string, string> ClickedKeyValuePair { get { return _clickedKeyValuePair; } set { SetProperty(ref _clickedKeyValuePair, value); } }

        // ���\�b�h
        /// <summary>
        /// �V�K�쐬��ʂւ̑J�ڂ��s��
        /// </summary>
        public void NewEntryExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(NewEntryUserControl));
        }

        /// <summary>
        /// ��i��ҏW����
        /// </summary>
        public void EditWorkExecute()
        {
            if (SelectedKeyValuePair is not null)
            {
                Workspace workspace = _workspaceSelector.GetWorkSpace(SelectedKeyValuePair.Value.Key);
                var p = new NavigationParameters
                {
                    { "Setting", workspace.WorkspacePoco.Setting },
                    { "Path", SelectedKeyValuePair.Value.ToString()},
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(EditWorkUserControl), p);
            }
        }

        /// <summary>
        /// ��i���폜����
        /// </summary>
        public void DeleteWorkExecute()
        {
            if (SelectedKeyValuePair is not null)
            {
                var result = System.Windows.MessageBox.Show("�{���ɍ폜���Ă���낵���ł��傤���H", "�x��", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == System.Windows.MessageBoxResult.OK)
                {
                    _workspaceSelector.Remove(SelectedKeyValuePair.Value.Key);
                }
                // ��ʂ������[�h����
                _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
            }
        }

        /// <summary>
        /// ���[�N�X�y�[�X���J��
        /// </summary>
        public void OpenWorkExecute()
        {
            try
            {
                if (SelectedKeyValuePair is null) return;
                Workspace workspace = _workspaceSelector.GetWorkSpace(SelectedKeyValuePair.Value.Key);
                var p = new NavigationParameters
                {
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl), p);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("�����ȃ��[�N�X�y�[�X�ł��B���[�N�X�y�[�X�̏ꏊ��ς����ꍇ�A�u�J���v���������x�o�^���Ă�������\n�G���[�F" + ex.ToString()
                    , "�����ȃ��[�N�X�y�[�X", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// ���̉�ʂ���J�ڂ��Ă����Ƃ�
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// �C���X�^���X��ێ����Ȃ�
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// ���̉�ʂ��瑼�̉�ʂ֑J�ڂ���Ƃ�
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void OpenFileExecute()
        {
            try
            {
                string path = "";
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "�t�H���_��I�����Ă�������";
                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        path = folderDialog.SelectedPath;
                    }
                    else
                    {
                        return;
                    }
                };
                if (!FileExistsInDirectory(path, "workspace.json"))
                {
                    throw new Exception("workspace.json is not");
                }
                string worksaceName = Path.GetFileName(path);
                _workspaceSelector.SelectorPoco.PathDictionary.Add(worksaceName, path);
                _workspaceSelector.Save();
                Workspace workspace = _workspaceSelector.GetWorkSpace(worksaceName);
                var p = new NavigationParameters
                {
                    {"Workspace",workspace }
                };
                _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl), p);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBoxResult result = System.Windows.MessageBox.Show("�����ȃ��[�N�X�y�[�X�ł��B���[�N�X�y�[�X�̏ꏊ��ς����ꍇ�A�u�J���v���������x�o�^���Ă�������\n�G���[�F" + ex.ToString()
                    , "�����ȃ��[�N�X�y�[�X", System.Windows.MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool FileExistsInDirectory(string directoryPath, string fileName)
        {
            // �p�X���������Ċ��S�ȃt�@�C���p�X�𐶐�
            string fullPath = Path.Combine(directoryPath, fileName);

            // �t�@�C���̑��݊m�F
            return File.Exists(fullPath);
        }
    }
}

