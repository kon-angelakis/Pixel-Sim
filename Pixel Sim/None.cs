using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal class None : Element
    {
        public None() { color = Color.Transparent; }

        public override void ChangeCell(Cell current, Cell[,] grid) { }
    }
}
