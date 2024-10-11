using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CedarBoard.Model.Interface;

namespace CedarBoard.Model.Objects
{
    public sealed class Selector : ISerialize,IDeserialize
    {
        /// <summary>
        /// ワークスペースのパス
        /// </summary>
        public List<string> Paths { get; set; }


        /// <summary>
        /// 新しいワークスペースを追加して返す
        /// </summary>
        /// <param name="path"></param>
        /// <param name="setting"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkSpace Add(string path, Setting setting)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定されたワークスペースを削除する
        /// </summary>
        /// <param name="path"></param>
        public void Remove(string path)
        {
        }

        /// <summary>
        /// 指定されたワークスペースを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public WorkSpace GetWorkSpace(string path)
        {
            throw new NotImplementedException();
        }

        public void Serialize(string file)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(string file)
        {
            throw new NotImplementedException();
        }
    }
}
