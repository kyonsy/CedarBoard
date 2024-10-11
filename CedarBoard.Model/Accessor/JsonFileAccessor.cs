using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace CedarBoard.Model.Accessor
{
    public abstract class JsonFileAccessor
    {
        /// <summary>
        /// シリアライズ(JSONに情報を書き出す)
        /// </summary>
        /// <param name="file"></param>
        public void Serialize(string file)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(file, json);
        }

        /// <summary>
        /// デシリアライズ(JSONの情報を読み込む)
        /// </summary>
        /// <param name="file"></param>
        public void Deserialize(string file)
        {

        }
    }
}
