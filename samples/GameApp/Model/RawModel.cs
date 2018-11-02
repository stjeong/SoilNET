using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp.Model
{
    public class RawModel
    {
        uint vaoID;
        public uint VaoID { get { return vaoID; } }

        int vertexCount;
        public int VertexCount { get { return vertexCount; } }

        public RawModel(uint vaoID, int vertexCount)
        {
            this.vaoID = vaoID;
            this.vertexCount = vertexCount;
        }
    }
}
