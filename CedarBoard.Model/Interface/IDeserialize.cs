using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Interface
{
    internal interface IDeserialize
    {

        /// <summary>
        /// デシリアライズ(JSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        void Deserialize(string file);
    }
}
