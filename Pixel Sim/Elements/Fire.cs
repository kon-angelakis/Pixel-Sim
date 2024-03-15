using Microsoft.Xna.Framework;
using Pixel_Sim.Elements.Abstraction;
using Pixel_Sim.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements
{
    internal class Fire : Solid //Maybe extends just Element will see
    {

        private double extinguishChance = 0.03f;
        private List<Color> fire_colors = new List<Color>();
        public Fire()
        {
            fire_colors.Add(new Color(255, 0, 0));
            fire_colors.Add(new Color(255, 90, 0));
            fire_colors.Add(new Color(255, 154, 0));
            fire_colors.Add(new Color(255, 232, 8));
            
        }

        public override void ChangeCell(Cell current, Cell[,] grid)
        {
            this.color = fire_colors[r.Next(0, fire_colors.Count)];

            foreach (Cell neighbour in current.Neighbours)
            {
                if (neighbour != null)
                    if (neighbour.Element.IsFlammable)
                        if (r.NextDouble() < neighbour.Element.IgnitionChance)
                            GridLogic.SpreadFire(neighbour);
            }
            if (r.NextDouble() < extinguishChance)
                current.Reset();
        }
    }
}
