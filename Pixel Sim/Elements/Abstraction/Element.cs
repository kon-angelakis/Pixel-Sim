using Microsoft.Xna.Framework;
using Pixel_Sim.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements.Abstraction
{
    internal abstract class Element
    {
        protected Random r = new Random();

        protected Color color;

        public bool IsFlammable;

        public double IgnitionChance;

        public Color Color { get { return color; } }

        public abstract void ChangeCell(Cell current, Cell[,] grid);

    }
}
