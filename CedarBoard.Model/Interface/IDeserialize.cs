using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Interface
{
    public interface IDeserialize
    {

        /// <summary>
        /// デシリアライズ(JSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        void GetData(string file);
    }
}
