using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal abstract class Liquid : Element
    {
        private double viscocity;
        private bool flammable;

        public override void UpdatePosition(Cell cur, Cell left, Cell right, Cell down, Cell down_L, Cell down_R, Random r)
        {


            if (down != null && down.GetElement() == null)
            {
                // If empty, move the liquid downward
                cur.SetElement(null);
                down.SetElement(this);
            }
            else
            {
                if (left != null && left.GetElement() == null)
                {
                    // Check left
                    cur.SetElement(null);
                    left.SetElement(this);
                }
                else if (right != null && right.GetElement() == null)
                {
                    // Check right
                    cur.SetElement(null);
                    right.SetElement(this);
                }
            }



        }

    }

}
