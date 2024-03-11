using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal class Sand : Solid
    {
        private bool submerged_direction;
        public Sand(bool fall_direction)
        {
            this.color = Color.Gold; 
            this.fall_direction = fall_direction;
        }

        public override void ChangeCell(Cell current)
        {
            submerged_direction = r.NextDouble() < 0.5f;
            base.ChangeCell(current);
            if (current.Down != null && current.Down.GetElement() is Liquid)
            {
                if (current.Down_L != null && current.Down_L.GetElement() is Liquid && submerged_direction)
                {
                    GameLogic.SwapCell(current, current.Down_L);
                }
                else if (current.Down_R != null && current.Down_R.GetElement() is Liquid && !submerged_direction)
                {
                    GameLogic.SwapCell(current, current.Down_R);
                }
                else
                {
                    GameLogic.SwapCell(current, current.Down);
                }
            }
        }
    }
}
