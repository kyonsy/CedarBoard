// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �v���W�F�N�g����ς���_�C�A���O
    /// </summary>
    public class ChangeProjectNameUserControlViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ChangeProjectNameUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }

        private string _title = "�v���W�F�N�g���̕ύX";
        private string _projectName = "";
        private string _newProjectName = "";

        /// <summary>
        /// �m�[�h�̐V�K�쐬������������(���m�ɂ̓f�[�^�̓��͂�����������)
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        ///�@�v���W�F�N�g�̖��O
        /// </summary>
        public string ProjectName { get { return _projectName; } set { SetProperty(ref _projectName, value); } }

        /// <summary>
        /// �V�����v���W�F�N�g�̖��O
        /// </summary>
        public string NewProjectName { get { return _newProjectName; } set { SetProperty(ref _newProjectName, value); } }

        /// <summary>
        /// �^�C�g��
        /// </summary>
        public string Title { get { return _title; } set { SetProperty(ref _title, value); } }

        /// <summary>
        /// ����Ƃ��̃��X�i�[
        /// </summary>
        public DialogCloseListener RequestClose { get; set; }


        /// <summary>
        /// �_�C�A���O�����邩�ǂ���
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// �_�C�A���O������Ƃ�
        /// </summary>
        public void OnDialogClosed()
        {

        }

        /// <summary>
        /// �_�C�A���O���J���Ƃ�
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        private void OKButtonExecute()
        {
            var p = new DialogParameters
            {
                { "projectName", ProjectName },
                {"newProjectName",NewProjectName }
            };
            var result = new DialogResult(ButtonResult.OK) { Parameters = p };
            RequestClose.Invoke(result);
        }
    }
}

