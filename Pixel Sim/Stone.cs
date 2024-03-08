using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal class Stone : Solid
    {
        public Stone() { this.color = Color.Gray; }

        public override void UpdatePosition(Cell cur, Cell left, Cell right, Cell down, Cell down_L, Cell down_R, Random r)
        {
    
        }
    }
}
