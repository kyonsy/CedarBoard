// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using CedarBoard.Model;
using CedarBoard.Model.Poco;
using CedarBoard.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ��i��ҏW����
    /// </summary>
    public class EditWorkUserControlViewModel : BindableBase, INavigationAware
    {
        //�t�B�[���h
        private IRegionManager _regionManager;
        private WorkspaceSelector _workspaceSelector;
        private string _name;
        private string _firstName;
        private string _author;
        private string _editorPath;
        private string _memo;
        NavigationContext _navigationContext;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public EditWorkUserControlViewModel(IRegionManager regionManager, WorkspaceSelector workspaceSelector)
        {
            _workspaceSelector = workspaceSelector;
            _regionManager = regionManager;
            BackHome = new DelegateCommand(BackHomeExecute);
            SaveSetting = new DelegateCommand(SaveSettingExecute);
        }

        // �f���Q�[�g
        /// <summary>
        /// �z�[����ʂ֖߂�
        /// </summary>
        public DelegateCommand BackHome { get; }

        /// <summary>
        /// �V�K�쐬
        /// </summary>
        public DelegateCommand SaveSetting { get; }

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
        /// �g���G�f�B�^�̃p�X
        /// </summary>
        public string EditorPath { get { return _editorPath; } set { SetProperty(ref _editorPath, value); } }

        /// <summary>
        /// ����
        /// </summary>
        public string Memo { get { return _memo; } set { SetProperty(ref _memo, value); } }


        // ���\�b�h
        /// <summary>
        /// �C���X�^���X�͎g���܂킳�Ȃ�
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        /// <summary>
        /// ���̉�ʂ���i�r�Q�[�g�������̓���
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// ���̉�ʂ��炱�̉�ʂɃi�r�Q�[�g�������̓���
        /// </summary>
        /// <param name="navigationContext">�i�r�Q�[�V����������̃p�����[�^</param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationContext = navigationContext;
            Setting setting = navigationContext.Parameters.GetValue<Setting>("Setting");
            Name = setting.Name;
            _firstName = Name;
            Author = setting.Author;
            EditorPath = setting.Editor;
            Memo = setting.Message;
        }

        /// <summary>
        /// �z�[����ʂ֖߂�
        /// </summary>
        private void BackHomeExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(HomeUserControl));
        }

        /// <summary>
        /// ���[�N�X�y�[�X�̐ݒ��ۑ�����
        /// </summary>
        private void SaveSettingExecute()
        {
            Workspace workspace = _navigationContext.Parameters.GetValue<Workspace>("Workspace");
            workspace.WorkspacePoco.Setting = workspace.WorkspacePoco.Setting with
            {
                Author = Author,
                Editor = EditorPath,
                Message = Memo
            };
            workspace.Save();
            _workspaceSelector.Rename(_firstName, Name);
            BackHomeExecute();
        }
    }
}

