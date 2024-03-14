using Microsoft.Xna.Framework;
using Pixel_Sim.Logic;
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
            color = new Color(245, r.Next(150, 210), 66);
            this.fall_direction = fall_direction;
        }

        public override void ChangeCell(Cell current, Cell[,] grid)
        {
            submerged_direction = r.NextDouble() < 0.5f;
            base.ChangeCell(current, grid);

            //Submerged behaviour to still make sand hills under a liquid
            if (current.Down != null && current.Down.Element is Liquid)
            {
                if (current.Down_L != null && current.Down_L.Element is Liquid && submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_L);
                }
                else if (current.Down_R != null && current.Down_R.Element is Liquid && !submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_R);
                }
                else
                {
                    GridLogic.SwapCell(grid, current, current.Down);
                }
            }
            else if (current.Down_L != null && current.Down_L.Element is Liquid)
            {
                if (current.Down_L != null && current.Down_L.Element is Liquid && submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_L);
                }
                else if (current.Down_R != null && current.Down_R.Element is Liquid && !submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_R);
                }
                else
                {
                    GridLogic.SwapCell(grid, current, current.Down);
                }
            }
            else if (current.Down_R != null && current.Down_R.Element is Liquid)
            {
                if (current.Down_L != null && current.Down_L.Element is Liquid && submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_L);
                }
                else if (current.Down_R != null && current.Down_R.Element is Liquid && !submerged_direction)
                {
                    GridLogic.SwapCell(grid, current, current.Down_R);
                }
                else
                {
                    GridLogic.SwapCell(grid, current, current.Down);
                }
            }

        }
    }
}
