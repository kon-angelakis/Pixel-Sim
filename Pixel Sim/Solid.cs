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

            if (cur.getElement() != null)
            {
                if (down.getElement() == null)
                { 
                    cur.setElement(null);
                    down.setElement(this);

                }
                //If both are free spots then move randomly
                else if (down_L.getElement() == null && down_R.getElement() == null)
                {
                    cur.setElement(null);
                    if (r.Next(2) < 1)
                        down_L.setElement(this);
                    else
                        down_R.setElement(this);
                }
                else if (down_L.getElement() == null)
                {
                    cur.setElement(null);
                    down_L.setElement(this);
                }
                else if (down_R.getElement() == null)
                {
                    cur.setElement(null);
                    down_R.setElement(this);
                }

            }
        }

    }
}
