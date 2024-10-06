using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model
{
    internal sealed class Node
    {

        /// <summary>
        /// ノードの名前
        /// </summary>
        private String Name { get; set; }
        /// <summary>
        /// ノードの座標(要素数は2)
        /// </summary>
        private int[] Point {  get; set; }
       
        /// <summary>
        /// 子ノードが入っている配列のアクセサ
        /// </summary>
        private List<int> ChildNode {  get; set; }
    }
}
