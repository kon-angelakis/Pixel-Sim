using Microsoft.Xna.Framework;
using Pixel_Sim.Elements.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements
{
    internal class Stone : NonFallingSolid
    {
        public Stone()
        {
            int c = r.Next(50, 100);
            color = new Color(c, c, c);
            IsFlammable = false;

        }

    }
}
