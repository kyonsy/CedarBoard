using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CedarBoard.Model.Object;

namespace CedarBoard.Model
{
    internal sealed class Project : JSONBase
    {
        /// <summary>
        /// Nodeのリスト
        /// </summary>
        private List<Node> Node { get; set; }


        /// <summary>
        /// 新しいノードを追加する
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
        }

        /// <summary>
        /// 指定されたノードを削除する
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {

        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Replace(Node node, int index)
        {

        }
    }
}
