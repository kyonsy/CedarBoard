// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// �ڍׂ� LICENSE �t�@�C�����Q�Ƃ��Ă��������B
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// �E�B���h�E������ۂ̃C�x���g�̒�`
    /// </summary>
    public class WindowClosingEvent: PubSubEvent<CancelEventArgs>
    {
    }
}


