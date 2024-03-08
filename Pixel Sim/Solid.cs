using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_Sim
{
    internal abstract class Solid : Element
    {
        private bool falls;
        public override void UpdatePosition(Cell cur, Cell left, Cell right, Cell down, Cell down_L, Cell down_R, Random r)
        {

            if (cur.GetElement() != null)
            {
                if (down != null && down.GetElement() == null)
                {
                    cur.SetElement(null);
                    down.SetElement(this);

                }
                //If both are free spots then move randomly
                else if (down_L != null && down_R != null && down_L.GetElement() == null && down_R.GetElement() == null)
                {
                    cur.SetElement(null);
                    if (r.Next(2) < 1)
                        down_L.SetElement(this);
                    else
                        down_R.SetElement(this);
                }
                else if (down_L != null && down_L.GetElement() == null)
                {
                    cur.SetElement(null);
                    down_L.SetElement(this);
                }
                else if (down_R != null && down_R.GetElement() == null)
                {
                    cur.SetElement(null);
                    down_R.SetElement(this);
                }

            }
        }

    }
}
