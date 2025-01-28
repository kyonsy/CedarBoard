// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
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
    /// ウィンドウが閉じる際のイベントの定義
    /// </summary>
    public class WindowClosingEvent: PubSubEvent<CancelEventArgs>
    {
    }
}


