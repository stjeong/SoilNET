using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public class ModelTexture
    {
        uint _textureID;
        public uint ID
        {
            get { return _textureID; }
        }

        public ModelTexture(uint id)
        {
            this._textureID = id;
        }


    }
}
