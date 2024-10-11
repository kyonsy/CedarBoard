using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Interface
{
    public interface ISerialize
    {
        /// <summary>
        /// シリアライズ(JSONに情報を書き出す)
        /// </summary>
        /// <param name="file"></param>
        void SetData(string file);
    }
}
