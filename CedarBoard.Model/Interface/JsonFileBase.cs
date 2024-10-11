using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedarBoard.Model.Interface
{
    public abstract class JsonFileBase
    {
        public void Serialize(string file,ISerialize serializer)
        {

        }

        public void Deserialize(string file,IDeserialize deserializer) { 

        }
    }
}
