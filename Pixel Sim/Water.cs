using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal class Water : Liquid
    {
        public Water(bool flow_direction)
        {
            color = new Color(50, 20, r.Next(190, 220));
            this.flow_direction = flow_direction;
        }
    }
}
