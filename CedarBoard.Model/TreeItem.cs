using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CedarBoard.Model
{
    /// <summary>
    /// 階層構造をモデル
    /// </summary>
    public class TreeItem
    {
        /// <summary>
        /// アイテムの名前
        /// </summary>
        public string Name {  get; set; }

        /// <summary>
        /// 子要素
        /// </summary>
        public ObservableCollection<TreeItem> Children { get; set; }

        /// <summary>
        /// アイテムが下に開いているか
        /// </summary>
        public bool IsExpanded {  get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">ツリーの根のアイテム</param>
        public TreeItem(string name)
        {
            Name = name;
            Children = new ObservableCollection<TreeItem>();
        }
    }
}
