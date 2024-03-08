using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal abstract class Element
    {
        public Microsoft.Xna.Framework.Color color;

        public Microsoft.Xna.Framework.Color GetColor() { return (this.color); }
        public abstract void UpdatePosition(Cell cur, Cell left, Cell right, Cell down, Cell down_L, Cell down_R, Random r);
                  
        
    }
}
