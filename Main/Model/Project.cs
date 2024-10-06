using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Main.Model
{
    internal sealed class Project
    {
        /// <summary>
        /// Nodeのリスト
        /// </summary>
        private List<Node> Node { get; set; }

        /// <summary>
        /// シリアライズ(JSONにProjectの情報を書き出す)
        /// </summary>
        /// <param name="file"></param>
        public void Serialize(string file)
        {

        }

        /// <summary>
        /// デシリアライズ(ProjectにJSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        public void Deserialize(string file) {

        }

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
        public void Remove(int index) {
            
        }

        /// <summary>
        /// 指定されたノードを変更する
        /// </summary>
        /// <param name="node"></param>
        /// <param name="index"></param>
        public void Replace(Node node,int index)
        {

        }
    }
}
