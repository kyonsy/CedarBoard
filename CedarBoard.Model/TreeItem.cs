// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CedarBoard.Model
{
    /// <summary>
    /// �K�w�\�������f��
    /// </summary>
    public class TreeItem
    {
        /// <summary>
        /// �A�C�e���̖��O
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// �q�v�f
        /// </summary>
        public ObservableCollection<TreeItem> Children { get; set; }

        /// <summary>
        /// �A�C�e�������ɊJ���Ă��邩
        /// </summary>
        public bool IsExpanded {  get; set; }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="name">�c���[�̍��̃A�C�e��</param>
        public TreeItem(string name)
        {
            Name = name;
            Children = new ObservableCollection<TreeItem>();
        }
    }
}

