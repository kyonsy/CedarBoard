using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Object
{
    internal sealed class Node
    {

        /// <summary>
        /// ノードの名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// ノードの座標
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// 子ノードが入っている配列のアクセサ
        /// </summary>
        public List<int> ChildNode { get; set; }
    }
}
