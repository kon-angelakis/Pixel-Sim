using Microsoft.Xna.Framework;
using Pixel_Sim.Elements.Abstraction;
using Pixel_Sim.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements
{
    internal class Water : Liquid
    {
        public Water(bool flow_direction)
        {
            IsFlammable = false;
            this.flow_direction = flow_direction;
        }

        public override void ChangeCell(Cell current, Cell[,] grid)
        {
            base.ChangeCell(current, grid);
            color = new Color(50, 20, r.Next(190, 220));
        }
    }
}
