// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �^�u�̃r���[���f��
    /// </summary>
    public record TabViewModel
    {
        /// <summary>
        /// �w�b�_�[�G���A
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// DataContext�ɓ����ViewModel
        /// </summary>
        public ProjectUserControlViewModel ProjectViewModel {  get; set; }
    }
}

