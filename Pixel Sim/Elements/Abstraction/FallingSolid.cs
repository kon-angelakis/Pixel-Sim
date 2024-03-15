using Pixel_Sim.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements.Abstraction
{
    internal abstract class FallingSolid : Solid
    {
        protected bool fall_direction;

        public override void ChangeCell(Cell current, Cell[,] grid)
        {
            if (current.Down != null && current.Down.Element is None)
            {
                GridLogic.SwapCell(grid, current, current.Down);
            }
            else if (current.Down_L != null && current.Down_R != null && current.Down_L.Element is None && current.Down_R.Element is None)
            {
                if (fall_direction)
                    GridLogic.SwapCell(grid, current, current.Down_L);
                else
                    GridLogic.SwapCell(grid, current, current.Down_R);
            }
            else if (current.Down_L != null && current.Down_L.Element is None)
            {
                GridLogic.SwapCell(grid, current, current.Down_L);
            }
            else if (current.Down_R != null && current.Down_R.Element is None)
            {
                GridLogic.SwapCell(grid, current, current.Down_R);
            }
        }
    }
}
