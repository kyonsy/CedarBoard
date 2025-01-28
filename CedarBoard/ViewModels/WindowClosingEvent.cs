// Copyright (c) 2025 Kyoshiro Kaji
// MIT License
// 詳細は LICENSE ファイルを参照してください。
using Prism.Events;
using System.ComponentModel;

namespace CedarBoard.ViewModels
{
    /// <summary>
    /// ウィンドウが閉じる際のイベントの定義
    /// </summary>
    public class WindowClosingEvent : PubSubEvent<CancelEventArgs>
    {
    }
}


