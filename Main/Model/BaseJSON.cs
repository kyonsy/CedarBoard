using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Main.Model
{
    abstract class BaseJSON
    {
        /// <summary>
        /// シリアライズ(JSONに情報を書き出す)
        /// </summary>
        /// <param name="file"></param>
        public void Serialize(string file)
        {

        }

        /// <summary>
        /// デシリアライズ(JSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        public void Deserialize(string file) { 

        }
    }
}
