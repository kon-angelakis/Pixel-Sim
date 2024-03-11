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
            this.color = new Color(66, 192, 255);
            this.flow_direction = flow_direction; 
        }
    }
}
