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
using System.Windows;
using System.Windows.Forms;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �V�K�쐬���
    /// </summary>
    public class NewEntryUserControlViewModel : BindableBase,IDisposable
    {
        // �t�B�[���h
        private IRegionManager _regionManager;
        private WorkspaceSelector _workspaceSelector;
        private string _name = "����";
        private string _author = "���Ȃ�";
        private string _path = "�p�X��I�����Ă�������";
        private string _editor = "notepad";
        private string _message = "�����ɍ�i�̃������������I";

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public NewEntryUserControlViewModel(IRegionManager regionManager, WorkspaceSelector workspaceSelector)
        {
            _workspaceSelector = workspaceSelector;
            _regionManager = regionManager;
            BackHome = new DelegateCommand(BackHomeExecute);
            NewEntry = new DelegateCommand(NewEntryExecute);
            ReferPath = new DelegateCommand(ReferPathExecute);
        }


        // �f���Q�[�g
        /// <summary>
        /// �z�[����ʂ֖߂�
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// �V�K�쐬
        /// </summary>
        public DelegateCommand NewEntry { get; }

        /// <summary>
        /// �Q��
        /// </summary>
        public DelegateCommand ReferPath { get; }

        // �v���p�e�B
        /// <summary>
        /// ��i��
        /// </summary>
        public string Name { get { return _name; } set { SetProperty(ref _name, value); } }

        /// <summary>
        /// ��Җ�
        /// </summary>
        public string Author { get { return _author; } set { SetProperty(ref _author, value); } }

        /// <summary>
        /// �p�X
        /// </summary>
        public string Path { get { return _path; } set { SetProperty(ref _path, value); } }

        /// <summary>
        /// �g���G�f�B�^�̃p�X
        /// </summary>
        public string Editor { get { return _editor; } set { SetProperty(ref _editor, value); } }

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        public string Message { get { return _message; } set { SetProperty(ref _message, value); } }


        // ���\�b�h
        /// <summary>
        /// �z�[����ʂ֖߂�
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }

        /// <summary>
        /// �V�������[�N�X�y�[�X���쐬����
        /// </summary>
        private void NewEntryExecute() {
            try
            {
                if(Path == "�p�X��I�����Ă�������")
                {
                    throw new Exception("�p�X���ݒ肳��Ă��܂���");
                }
                _workspaceSelector.Add(new()
                {
                    Name = Name,
                    Author = Author,
                    Editor = Editor,
                    Message = Message,
                    CreatedDate = DateTime.Now.ToString(),
                    UpdatedDate = DateTime.Now.ToString(),
                    Encode = "UTF-8",
                    Language = "ja",
                    Format = "default",
                }, Path);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("�����Ȑݒ�����n���܂���. �^�C�g�������߂Ă���p�X��ݒ肵�Ă�������. \n�G���[���b�Z�[�W: " + ex.Message, "�G���[", System.Windows.MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            _workspaceSelector.Save();
            var p = new NavigationParameters()
            {
                {"Workspace",_workspaceSelector.GetWorkSpace(Name) }
            };
            _regionManager.RequestNavigate("ContentRegion", nameof(WorkspaceUserControl),p);
        }

        /// <summary>
        /// �G�N�X�v���[�����Q�Ƃ���
        /// </summary>
        private void ReferPathExecute()
        {
            string path = "";
            using (var folderDialog = new FolderBrowserDialog()) {
                folderDialog.Description = "�t�H���_��I�����Ă�������";
                if(folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderDialog.SelectedPath + "\\" +Name;
                }
            };
            Path = path;

        }

        /// <summary>
        /// �I�u�W�F�N�g���p�������Ƃ��̏���
        /// </summary>
        public void Dispose()
        {
            
        }
    }
}

