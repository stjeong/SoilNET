using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp.Model
{
    public class TextureModel
    {
        RawModel _rawModel;
        public RawModel RawModel
        {
            get { return _rawModel; }
        }

        ModelTexture _texture;
        public ModelTexture Texture
        {
            get { return _texture; }
        }

        public TextureModel(RawModel model, ModelTexture texture)
        {
            this._rawModel = model;
            this._texture = texture;
        }
    }
}
