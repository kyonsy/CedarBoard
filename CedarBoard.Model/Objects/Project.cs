using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CedarBoard.Model.Interface;

namespace CedarBoard.Model.Objects
{
    public sealed class Project : ISerialize,IDeserialize
    {
        /// <summary>
        /// Nodeのリスト
        /// </summary>
        public List<Node> Node { get; set; }


        /// <summary>
        /// 新しいノードを追加する
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
        }

        public void Deserialize(string file)
        {
            throw new NotImplementedException();
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

        public void Serialize(string file)
        {
            throw new NotImplementedException();
        }
    }
}
