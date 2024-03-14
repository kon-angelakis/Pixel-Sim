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
        public Stone()
        {
            int c = r.Next(50, 100);
            color = new Color(c, c, c);

        }

        public override void ChangeCell(Cell current, Cell[,] grid)
        {

        }
    }
}
