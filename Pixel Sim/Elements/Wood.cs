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
    internal class Wood : NonFallingSolid
    {
        public Wood() 
        { 
            this.color = new Color(r.Next(40, 60), 15, 5);
            IsFlammable = true;
            IgnitionChance = 0.04f;
        }

    }
}
