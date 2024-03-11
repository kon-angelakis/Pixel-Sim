using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal abstract class Solid : Element
    {
        protected bool fall_direction;

        public override void ChangeCell(Cell current)
        {
            if (current.Down != null && current.Down.GetElement() is None)
            {
                GameLogic.SwapCell(current, current.Down);
            }
            else if (current.Down_L != null && current.Down_R != null && current.Down_L.GetElement() is None && current.Down_R.GetElement() is None)
            {
                if (fall_direction)
                    GameLogic.SwapCell(current, current.Down_L);
                else
                    GameLogic.SwapCell(current, current.Down_R);
            }
            else if (current.Down_L != null && current.Down_L.GetElement() is None)
            {
                GameLogic.SwapCell(current, current.Down_L);
            }
            else if (current.Down_R != null && current.Down_R.GetElement() is None)
            {
                GameLogic.SwapCell(current, current.Down_R);
            }
        }
    }
}
