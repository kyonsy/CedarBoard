// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �m�[�h�̃r���[���f��
    /// </summary>
    public class NodeUserControlViewModel : BindableBase
    {
        private string _name;
        private string _message;
        private double _canvasTop;


        /// <summary>
        /// �쐬����
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// �m�[�h�̖��O
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }


        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private double _canvasLeft;

        /// <summary>
        /// �L�����o�X�̍�(X���W)
        /// </summary>
        public double CanvasLeft
        {
            get => _canvasLeft;
            set => SetProperty(ref _canvasLeft, value);
        }

        /// <summary>
        /// �L�����o�X�̏�(Y���W)
        /// </summary>
        public double CanvasTop
        {
            get => _canvasTop;
            set => SetProperty(ref _canvasTop, value);
        }

        /// <summary>
        /// �e�L�X�g�G�f�B�^���J���R�}���h
        /// </summary>
        public DelegateCommand OpenTextEditorCommand { get; }

        /// <summary>
        /// �m�[�h��ҏW����R�}���h
        /// </summary>
        public DelegateCommand EditNodeCommand { get; }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public NodeUserControlViewModel()
        {
            OpenTextEditorCommand = new DelegateCommand(OpenTextEditor);
            EditNodeCommand = new DelegateCommand(EditNode);
        }

        /// <summary>
        /// �q�m�[�h�̃��X�g
        /// </summary>
        public List<string> Children { get; set; } = new List<string>();

        /// <summary>
        /// �e�L�X�g�G�f�B�^���J��
        /// </summary>
        public void OpenTextEditor()
        {

        }

        /// <summary>
        /// �m�[�h���폜����
        /// </summary>
        public void EditNode()
        {

        }
    }
}

