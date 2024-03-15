using Microsoft.Xna.Framework.Input;
using Pixel_Sim.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim.Elements.Abstraction
{
    internal abstract class Liquid : Element
    {
        protected bool flow_direction;
        public override void ChangeCell(Cell current, Cell[,] grid)
        {
            if (current.Down != null && current.Down.Element is None)
            {
                GridLogic.SwapCell(grid, current, current.Down);
            }
            else
            {

                if (flow_direction)
                {
                    if (current.Left != null && current.Left.Element is None)
                    {
                        GridLogic.SwapCell(grid, current, current.Left);
                    }
                    else if (current.Right != null && current.Right.Element is None)
                    {
                        GridLogic.SwapCell(grid, current, current.Right);
                        flow_direction = !flow_direction;
                    }
        

                }
                else
                {
                    if (current.Right != null && current.Right.Element is None)
                    {
                        GridLogic.SwapCell(grid, current, current.Right);
                    }
                    else if (current.Left != null && current.Left.Element is None)
                    {
                        GridLogic.SwapCell(grid, current, current.Left);
                        flow_direction = !flow_direction;
                    }
     
                }
            }


        }
    }
}
