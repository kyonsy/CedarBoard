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

