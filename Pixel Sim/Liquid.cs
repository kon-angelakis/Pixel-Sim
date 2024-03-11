using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal abstract class Liquid : Element
    {
        protected bool flow_direction;
        public override void ChangeCell(Cell current)
        {
            if (current.Down != null && current.Down.GetElement() is None)
            {
                GameLogic.SwapCell(current, current.Down);
            }
            else
            {
                if (flow_direction)
                {
                    if (current.Left != null && current.Left.GetElement() is None)
                    {
                        GameLogic.SwapCell(current, current.Left);
                    }else if (current.Right != null && current.Right.GetElement() is None )
                    {
                        GameLogic.SwapCell(current, current.Right);
                        flow_direction = !flow_direction;
                    }
                }
                else
                {
                    if (current.Right != null && current.Right.GetElement() is None)
                    {
                        GameLogic.SwapCell(current, current.Right);
                    }
                    else if (current.Left != null && current.Left.GetElement() is None)
                    {
                        GameLogic.SwapCell(current, current.Left);
                        flow_direction = !flow_direction;
                    }
                }
            }
        }
    }
}
