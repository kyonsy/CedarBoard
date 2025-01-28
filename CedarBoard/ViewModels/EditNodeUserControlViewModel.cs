// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using Prism.Commands;
using Prism.Dialogs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �m�[�h�̖��O��ҏW������
    /// </summary>
    public class EditNodeUserControlViewModel : BindableBase,IDialogAware
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public EditNodeUserControlViewModel()
        {
            OKButton = new DelegateCommand(OKButtonExecute);
        }
        private string _title = "�m�[�h���̕ҏW";
        private string _nodeName = "";

        /// <summary>
        /// �m�[�h�̐V�K�쐬������������(���m�ɂ̓f�[�^�̓��͂�����������)
        /// </summary>
        public DelegateCommand OKButton { get; }

        /// <summary>
        /// �m�[�h�̖��O
        /// </summary>
        public string NodeName { get { return _nodeName; } set { SetProperty(ref _nodeName, value); } }

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
                { "nodeName", NodeName },
            };
            var result = new DialogResult(ButtonResult.OK) { Parameters = p };
            RequestClose.Invoke(result);
        }
    }
}

